using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
	public class FormadorData : IFormadorData
	{
		private string _connectionString;

		public FormadorData(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("Default");
		}

		public List<Formador> GetAll()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				var lookup = new Dictionary<int, Formador>();

				string sql = @"SELECT DISTINCT p.*, f.*, ef.*, lef.Id, lef.Nome, m.Id, m.Nome FROM Formador AS f
								INNER JOIN Pessoa AS p
									ON f.PessoaId = p.Id
								INNER JOIN EstadoFormador AS ef
									ON ef.PessoaId = p.Id
								INNER JOIN ListaEstadosFormador AS lef
									ON lef.Id = ef.ListaEstadoId
								LEFT JOIN FormadorModulo AS fm
									ON p.Id = fm.FormadorId
								LEFT JOIN Modulo m
									ON fm.ModuloId = m.Id
								WHERE f.EstadoId = ef.ListaEstadoId";

				return connection.Query<Formador, Estado, Modulo, Formador>(
					sql, (formador, estado, modulo) =>
					{
						Formador formadorEntry;

						if (!lookup.TryGetValue(formador.Id, out formadorEntry))
						{
							formadorEntry = formador;
							formadorEntry.Estado = estado;
							formadorEntry.Modulos = new List<Modulo>();
							lookup.Add(formadorEntry.Id, formadorEntry);
						}
						if (modulo != null)
						{
							formadorEntry.Modulos.Add(modulo);
						}
						return formadorEntry;
					}, splitOn: "PessoaId, PessoaId, Id, Id")
					.Distinct()
					.ToList();
			}

		}

		//public List<Formador> GetAll()
		//{
		//	using (var connection = new SqlConnection(_connectionString))
		//	{
		//		var lookup = new Dictionary<int, Formador>();

		//		string sql = @"SELECT DISTINCT p.*, f.*, lef.Id, lef.Nome FROM Formador AS f
		//						INNER JOIN Pessoa AS p
		//							ON f.PessoaId = p.Id
		//						INNER JOIN EstadoFormador AS ef
		//							ON ef.PessoaId = p.Id
		//						INNER JOIN ListaEstadosFormador AS lef
		//							ON lef.Id = ef.ListaEstadoId
		//						WHERE f.EstadoId = ef.ListaEstadoId";
		//		return connection.Query<Formador, Estado, Formador>(sql,
		//		(formador, estado) =>
		//		{
		//			formador.Estado = estado;
		//			return formador;
		//		}, splitOn: "Id").ToList();
		//	}
		//}

	public List<Turma> GetTurmaByIdFormador(int formadorId)
{
    using (var connection = new SqlConnection(_connectionString))
    {
        string sql = @"SELECT DISTINCT f.PessoaId, t.*, c.*, al.Id, al.Nome FROM Formador AS f
                        INNER JOIN Pessoa AS p
                            ON f.PessoaId = p.Id
                        LEFT JOIN FormadorModulo AS fm
                            ON p.Id = fm.FormadorId
                        INNER JOIN FormadorModuloTurma fmt
                            ON fmt.FormadorModuloId = fm.Id
                        INNER JOIN Turma as t
                            ON t.Id = fmt.TurmaId
                        LEFT JOIN Curso AS c
                            ON c.Id = t.CursoId
                        LEFT JOIN AnoLetivo AS al
                            ON t.AnoLetivoId = al.Id
                        WHERE p.Id = @Id";

        return connection.Query<Turma, Curso, AnoLetivo, Turma>(sql, (turma, curso, anoLetivo) =>
        {
            turma.Curso = curso;
            turma.AnoLetivo = anoLetivo;
            return turma;
        }, new { Id = formadorId }, splitOn: "Id, Id, Id").ToList();
    }
}

        public List<Turma> GetTurmaByIdCoordenador(int coordenadorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT DISTINCT pl.PessoaId, t.*, c.*, al.Id, al.Nome FROM Pessoal AS pl
                        INNER JOIN Pessoa AS p
                            ON pl.PessoaId = p.Id
                        LEFT JOIN CursoCoordenador AS cc
                            ON p.Id = cc.PessoalId
                        LEFT JOIN Curso c
                            ON c.Id = cc.CursoId
                        LEFT JOIN Turma as t
                            ON t.CursoId = c.Id
                        LEFT JOIN AnoLetivo AS al
                            ON t.AnoLetivoId = al.Id
                        WHERE p.Id = @Id";

                return connection.Query<Turma, Curso, AnoLetivo, Turma>(sql, (turma, curso, anoLetivo) =>
                {
                    if (turma.Nome == null)
                    {
                        turma.Nome = "Sem turma associada";
                    }
                    turma.Curso = curso;
                    turma.AnoLetivo = anoLetivo;
                    return turma;
                }, new { Id = coordenadorId }, splitOn: "Id, Id, Id").ToList();
            }
        }

        public Formador GetById(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				var lookup = new Dictionary<int, Formador>();

				string sql = @"SELECT DISTINCT p.*, f.*, ef.*, lef.Id, lef.Nome, m.Id, m.Nome FROM Formador AS f
								INNER JOIN Pessoa AS p
									ON f.PessoaId = p.Id
								INNER JOIN EstadoFormador AS ef
									ON ef.PessoaId = p.Id
								INNER JOIN ListaEstadosFormador AS lef
									ON lef.Id = ef.ListaEstadoId
								LEFT JOIN FormadorModulo AS fm
									ON p.Id = fm.FormadorId
								LEFT JOIN Modulo m
									ON fm.ModuloId = m.Id
								WHERE p.Id = @Id AND f.EstadoId = ef.ListaEstadoId";

				return connection.Query<Formador, Estado, Modulo, Formador>(
				  sql, (formador, estado, modulo) =>
				  {
					  Formador formadorEntry;

					  if (!lookup.TryGetValue(formador.Id, out formadorEntry))
					  {
						  formadorEntry = formador;
						  formadorEntry.Estado = estado;
						  formadorEntry.Modulos = new List<Modulo>();
						  lookup.Add(formadorEntry.Id, formadorEntry);
					  }
					  if (modulo != null)
					  {
						  formadorEntry.Modulos.Add(modulo);
					  }
					  return formadorEntry;
				  }, new { Id = id }, splitOn: "PessoaId, PessoaId, Id, Id").FirstOrDefault();
			}
		}

		public List<Formador> GetCoordByCurso(int cursoId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"SELECT * FROM Formador AS f
								INNER JOIN Pessoa AS p
									ON f.PessoaId = p.Id
								LEFT JOIN CursoCoordenador AS cc
									ON p.Id = cc.PessoalId
								WHERE cc.CursoId = @CursoId";
				return connection.Query<Formador>(sql, new { CursoId = cursoId }).ToList();
			}
		}

		//public Formador GetById(int id)
		//{
		//	using (var connection = new SqlConnection(_connectionString))
		//	{
		//		string sql = @"SELECT DISTINCT p.*, f.*, ef.*, lef.Id, lef.Nome FROM Formador AS f
		//						INNER JOIN Pessoa AS p
		//							ON f.PessoaId = p.Id
		//						INNER JOIN EstadoFormador AS ef
		//							ON ef.PessoaId = p.Id
		//						INNER JOIN ListaEstadosFormador AS lef
		//							ON lef.Id = ef.ListaEstadoId
		//						WHERE p.Id = @Id AND f.EstadoId = ef.ListaEstadoId";
		//		return connection.Query<Formador, Estado, Formador>(sql, 
		//		(formador, estado) =>
		//              {
		//			formador.Estado = estado;
		//			return formador;
		//              },new { Id = id }, splitOn: "Id").FirstOrDefault();
		//	}
		//}

		public List<Formador> GetFormadoresByTurma(int turmaId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"SELECT DISTINCT f.*, p.*, lef.* FROM Formador AS f
								INNER JOIN Pessoa AS p
									ON p.Id = f.PessoaId
								INNER JOIN ListaEstadosFormador as lef
									ON lef.Id = f.EstadoId
								LEFT JOIN FormadorModulo AS fm
									ON fm.FormadorId = p.Id
								LEFT JOIN FormadorModuloTurma AS fmt
									ON fmt.FormadorModuloId = fm.Id
								LEFT JOIN Turma AS t
									ON t.Id = fmt.TurmaId
								WHERE t.Id = @TurmaId";
				return connection.Query<Formador, Estado, Formador>(sql, (formador, estado) =>
				{
					formador.Estado = estado;
					return formador;
				}, new { TurmaId = turmaId }, splitOn: "Id").ToList();
			}
		}

		public void Create(Formador formador)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				//é necessário abrir a conexao quando é usada uma transaction
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						//se a primeira query funcionar e a segunda por algum motivo falhar, a "transaction" faz com que os dados introduzidos da primeira query nao sejam gravados na bd
						//ou seja, so faz commit aos dados introduzidos quando TODAS as queries executarem sem erros

						string sql = @"INSERT INTO Pessoa (Nome, DataNascimento, Email, Password, Sexo, NIF, CC, ContactoTelemovel, ContactoTelefone, Morada, CP, CodigoCNAEF, HabilitacoesLiterarias, Nacionalidade, Foto, CV, PerfilId)
										VALUES (@Nome, @DataNascimento, @Email, @Password, @Sexo, @NIF, @CC, @ContactoTelemovel, @ContactoTelefone, @Morada, @CP, @CodigoCNAEF, @HabilitacoesLiterarias, @Nacionalidade, @Foto, @CV, @PerfilId)
										SELECT CAST(SCOPE_IDENTITY() as int)";

						//var id guarda o id da pessoa ao executar a primeira query (sql), para que (na segunda query) possa ser introduzido o id da pessoa na tabela formador
						//para isto funcionar, é necessário adicionar o SELECT CAST na primeira query
						var id = connection.ExecuteScalar<int>(sql, formador, transaction: transaction);
						sql = @"INSERT INTO Formador (PessoaId, CCP, DocenteEnsSuperior, EstadoId)
								VALUES (" + id + ", @CCP, @DocenteEnsSuperior, @EstadoId)";
						connection.Execute(sql, formador, transaction: transaction);

						sql =  @"INSERT INTO Pessoal (PessoaId, Funcao)
								VALUES (" + id + ", @Funcao)";
						connection.Execute(sql, new { Funcao = formador.Funcao }, transaction: transaction);

						sql = @"INSERT INTO EstadoFormador (PessoaId, ListaEstadoId, Data, Observacoes)
								VALUES (@PessoaId, @ListaEstadoId, @Data, 'Inserção')";
						connection.Execute(sql, new { PessoaId = id, ListaEstadoId = formador.Estado.Id, Data = DateTime.Now }, transaction);
						transaction.Commit();
					}
					catch
					{
						//caso haja algum erro ao executar as queries de cima, a conexão é fechada
						connection.Close();
						throw;
					}
				}
			}
		}

		public int CreateReturnId(Formador formador)
		{
			var idFormador = 0;

			using (var connection = new SqlConnection(_connectionString))
			{

				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						//se a primeira query funcionar e a segunda por algum motivo falhar, a "transaction" faz com que os dados introduzidos da primeira query nao sejam gravados na bd
						//ou seja, so faz commit aos dados introduzidos quando TODAS as queries executarem sem erros

						string sql = @"INSERT INTO Pessoa (Nome, DataNascimento, Email, Password, Sexo, NIF, CC, ContactoTelemovel, ContactoTelefone, Morada, CP, CodigoCNAEF, HabilitacoesLiterarias, Nacionalidade, Foto, CV, PerfilId)
										VALUES (@Nome, @DataNascimento, @Email, @Password, @Sexo, @NIF, @CC, @ContactoTelemovel, @ContactoTelefone, @Morada, @CP, @CodigoCNAEF, @HabilitacoesLiterarias, @Nacionalidade, @Foto, @CV, @PerfilId)
										SELECT CAST(SCOPE_IDENTITY() as int)";

						//var id guarda o id da pessoa ao executar a primeira query (sql), para que (na segunda query) possa ser introduzido o id da pessoa na tabela formador
						//para isto funcionar, é necessário adicionar o SELECT CAST na primeira query
						idFormador = connection.ExecuteScalar<int>(sql, formador, transaction: transaction);
						sql = @"INSERT INTO Formador (PessoaId, CCP, DocenteEnsSuperior, EstadoId)
								VALUES (" + idFormador + ", @CCP, @DocenteEnsSuperior, @EstadoId)";
						connection.Execute(sql, formador, transaction: transaction);

						sql = @"INSERT INTO Pessoal (PessoaId, Funcao)
								VALUES (" + idFormador + ", @Funcao)";
						connection.Execute(sql, new { Funcao = formador.Funcao }, transaction: transaction);

						sql = @"INSERT INTO EstadoFormador (PessoaId, ListaEstadoId, Data, Observacoes)
								VALUES (@PessoaId, @ListaEstadoId, @Data, 'Inserção')";
						connection.Execute(sql, new { PessoaId = idFormador, ListaEstadoId = formador.Estado.Id, Data = DateTime.Now }, transaction);
						transaction.Commit();
					}
					catch
					{
						connection.Close();
						throw;
					}
				}
			}
			return idFormador;
		}

		public void Remove(Formador formador)
		{
			Remove(formador.Id);
		}

		public void Remove(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"DELETE FROM EstadoFormador WHERE PessoaId = @Id
								DELETE FROM Formador WHERE PessoaId = @Id
								DELETE FROM Pessoa WHERE Id = @Id";
				connection.Execute(sql, new { Id = id });
			}
		}

		public void Update(Formador formador)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				int? idPessoal;

				using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
						string sql = @"UPDATE Pessoa
								SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, Password = @Password, Sexo = @Sexo, NIF = @NIF, CC = @CC, ContactoTelemovel = @ContactoTelemovel, ContactoTelefone = @ContactoTelefone, 
								Morada = @Morada, CP = @CP, CodigoCNAEF = @CodigoCNAEF, HabilitacoesLiterarias = @HabilitacoesLiterarias, Nacionalidade = @Nacionalidade, Foto = @Foto, CV = @CV, PerfilId = @PerfilId
								WHERE Id = @Id";
						connection.Execute(sql, formador, transaction: transaction);

						sql = @"UPDATE Formador
								SET CCP = @CCP, DocenteEnsSuperior = @DocenteEnsSuperior, EstadoId = @EstadoId
								WHERE PessoaId = @Id";
						connection.Execute(sql, formador, transaction: transaction);

						sql = @"SELECT PessoaId FROM Pessoal
                               WHERE PessoaId = @Id";
						idPessoal = (int?)connection.ExecuteScalar(sql, new { Id = formador.Id }, transaction: transaction);

						if (idPessoal == null)
                        {
							sql = @"INSERT INTO Pessoal (PessoaId, Funcao)
								VALUES (@Id, @Funcao)";
							connection.Execute(sql, new { Id = formador.Id, Funcao = formador.Funcao }, transaction: transaction);
						}
                        else
                        {
							sql = @"UPDATE Pessoal
								SET Funcao = @Funcao
								WHERE PessoaId = @Id";
							connection.Execute(sql, new { Id = formador.Id, Funcao = formador.Funcao }, transaction: transaction);
						}							
						transaction.Commit();
					}
					catch
                    {
						connection.Close();
						throw;
					}
                }
			}
		}

		public void UpdateHistEstado(Formador formador)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"INSERT INTO EstadoFormador (PessoaId, ListaEstadoId, Data, Observacoes)
							VALUES (@PessoaId, @ListaEstadoId, @Data, @Observacoes)";
				connection.Execute(sql, new { PessoaId = formador.Id, ListaEstadoId = formador.EstadoId, Data = DateTime.Now, Observacoes = formador.EstadosFormador.Observacoes });
			}
		}

		public List<EstadosFormador> ObterHistoricoDoFormador(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"SELECT ef.*, lef.* FROM Formador AS f
								INNER JOIN Pessoa as P
								ON f.PessoaId = p.Id
								LEFT JOIN EstadoFormador AS ef
								ON ef.PessoaId = p.Id
								LEFT JOIN ListaEstadosFormador AS lef
								ON lef.Id = ef.ListaEstadoId
								WHERE p.Id = @Id
								ORDER BY ef.Data";
				return connection.Query<EstadosFormador, Estado, EstadosFormador>(sql,
					(estadosFormador, estado) =>
					{
						estadosFormador.Estado = estado;
						return estadosFormador;

					}, new { Id = id }, splitOn: "Id").ToList();
			}
		}

		public void RemoveModulos(Formador formador, List<Modulo> modulosToRemove)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"DELETE FROM FormadorModulo
								WHERE FormadorId = @FormadorId AND ModuloId = @ModuloId";

				foreach (var modulo in modulosToRemove)
				{
					connection.Execute(sql, new { FormadorId = formador.Id, ModuloId = modulo.Id });
				}
			}
		}

		public void InsertModulos(Formador formador, List<Modulo> modulosToInsert)
		{
			using (var connection = new SqlConnection(_connectionString))
			{

				string sql = "INSERT INTO FormadorModulo (FormadorId, ModuloId) VALUES (@FormadorId, @ModuloId)";
				foreach (var modulo in modulosToInsert)
				{
					connection.Execute(sql, new { FormadorId = formador.Id, ModuloId = modulo.Id });
				}
			}
		}

	}
}