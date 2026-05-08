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
	public class FormandoData : IFormandoData
	{
		private string _connectionString;

		public FormandoData(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("Default");
		}
		public List<Formando> GetAll()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"SELECT DISTINCT p.*, lef.Id, lef.Nome, t.*, c.* FROM Formando AS f
								LEFT JOIN Pessoa as P
									ON f.PessoaId = p.Id
								LEFT JOIN EstadoFormando AS ef
									ON ef.PessoaId = p.Id
								LEFT JOIN ListaEstadosFormando AS lef
									ON lef.Id = ef.ListaEstadoId 
								LEFT JOIN TurmaFormando AS tf
									ON p.Id = tf.FormandoId
								LEFT JOIN Turma AS t
									ON tf.TurmaId = t.Id
								LEFT JOIN Curso AS c
									ON t.CursoId = c.Id
								WHERE f.EstadoId = ef.ListaEstadoId";
				return connection.Query<Formando, Estado, Turma, Curso, Formando>(sql,
					(formando, estado, turma, curso) =>
					{
						formando.Estado = estado;
						formando.Turma = turma;
						if(formando.Turma != null)
                        {
							formando.Turma.Curso = curso;
						}						
						return formando;

					}, splitOn: "Id, Id, Id").ToList();
			}
		}

		public List<Formando> GetAllByTurma(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"SELECT DISTINCT p.*, af.*, lef.Id, lef.Nome, t.* FROM Formando AS f
								LEFT JOIN AvaliacaoFinal AS af
									ON f.PessoaId = af.FormandoId
								LEFT JOIN Pessoa as P
									ON f.PessoaId = p.Id
								LEFT JOIN EstadoFormando AS ef
									ON ef.PessoaId = p.Id
								LEFT JOIN ListaEstadosFormando AS lef
									ON lef.Id = ef.ListaEstadoId 
								LEFT JOIN TurmaFormando AS tf
									ON p.Id = tf.FormandoId
								LEFT JOIN Turma AS t
									ON tf.TurmaId = t.Id
								WHERE t.Id = @Id AND f.EstadoId = ef.ListaEstadoId";
				return connection.Query<Formando, AvaliacaoFinal, Estado, Turma, Formando>(sql,
					(formando, avaliacaoFinal, estado, turma) =>
					{
						formando.Estado = estado;
						formando.Turma = turma;
						formando.AvaliacaoFinal = avaliacaoFinal;
						return formando;

					}, new { Id = id }, splitOn: "Id, Id, Id").ToList();
			}
		}

		public List<Formando> GetAllByTurmaWithAvaliacao(int turmaId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				var lookup = new Dictionary<int, Formando>();

				string sql = @"SELECT DISTINCT p.*, am.*, af.*, lef.Id, lef.Nome, t.* FROM Formando AS f
                                LEFT JOIN AvaliacaoFinal AS af
                                    ON f.PessoaId = af.FormandoId
                                LEFT JOIN AvaliacaoModular AS am
                                    ON f.PessoaId = am.FormandoId
                                LEFT JOIN Pessoa as P
                                    ON f.PessoaId = p.Id
                                LEFT JOIN EstadoFormando AS ef
                                    ON ef.PessoaId = p.Id
                                LEFT JOIN ListaEstadosFormando AS lef
                                    ON lef.Id = ef.ListaEstadoId 
                                LEFT JOIN TurmaFormando AS tf
                                    ON p.Id = tf.FormandoId
                                LEFT JOIN Turma AS t
                                    ON tf.TurmaId = t.Id
                                WHERE t.Id = @Id AND f.EstadoId = ef.ListaEstadoId
								ORDER BY am.ModuloId";
				return connection.Query<Formando, AvaliacaoModular, AvaliacaoFinal, Estado, Turma, Formando>(sql,
					(formando, avaliacaoModular, avaliacaoFinal, estado, turma) =>
					{
						Formando formandoEntry;

						if (!lookup.TryGetValue(formando.Id, out formandoEntry))
                        {
							formandoEntry = formando;
							formandoEntry.DictAvaliacaoModular = new Dictionary<int, AvaliacaoModular>();
							formandoEntry.AvaliacaoFinal = avaliacaoFinal;
							formandoEntry.Estado = estado;
							formandoEntry.Turma = turma;			
							lookup.Add(formandoEntry.Id, formandoEntry);
						}
						if (avaliacaoModular != null)
						{
							formandoEntry.DictAvaliacaoModular.Add(avaliacaoModular.ModuloId, avaliacaoModular);
						}
						return formandoEntry;
					}, new { Id = turmaId }, splitOn: "Id, Id, Id, Id").Distinct()
					.ToList();
			}
		}

        public List<Formando> GetAllByTurmaComFaltas(int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Query to get formandos with their total justified/unjustified absence durations
                string sql = @"
            SELECT 
                p.Id, p.Nome, p.Email, 
                lef.Id, lef.Nome, 
                t.Id, t.Nome, 
                c.Id, c.DuracaoHoras,
                SUM(CASE WHEN f.Justificada = 1 THEN f.Duracao ELSE 0 END) AS TotalFaltasJustificadas,
                SUM(CASE WHEN f.Justificada = 0 THEN f.Duracao ELSE 0 END) AS TotalFaltasInjustificadas
				FROM Formando AS form
				INNER JOIN Pessoa as p ON form.PessoaId = p.Id
				LEFT JOIN Falta AS f ON f.FormandoId = p.Id
				LEFT JOIN EstadoFormando AS ef ON ef.PessoaId = p.Id
				LEFT JOIN ListaEstadosFormando AS lef ON lef.Id = ef.ListaEstadoId 
				LEFT JOIN TurmaFormando AS tf ON p.Id = tf.FormandoId
				LEFT JOIN Turma AS t ON tf.TurmaId = t.Id
				LEFT JOIN Curso AS c ON c.Id = t.CursoId
				WHERE t.Id = @TurmaId AND form.EstadoId = ef.ListaEstadoId
				GROUP BY p.Id, p.Nome, p.Email, lef.Id, lef.Nome, t.Id, t.Nome, c.Id, c.DuracaoHoras";

                var formandos = connection.Query<Formando, Estado, Turma, Curso, Formando>(sql,
                    (formando, estado, turma, curso) =>
                    {
                        formando.Estado = estado;
                        formando.Turma = turma;
                        formando.Turma.Curso = curso;
                        return formando;
                    },
                    new { TurmaId = turmaId },
                    splitOn: "Id, Id, Id").ToList();

                // Get the aggregated durations
                var faltasData = connection.Query<(int FormandoId, int TotalFaltasJustificadas, int TotalFaltasInjustificadas)>(
                    @"SELECT 
                f.FormandoId,
                SUM(CASE WHEN f.Justificada = 1 THEN f.Duracao ELSE 0 END) AS TotalFaltasJustificadas,
                SUM(CASE WHEN f.Justificada = 0 THEN f.Duracao ELSE 0 END) AS TotalFaltasInjustificadas
				  FROM Falta f
				  INNER JOIN TurmaFormando tf ON f.FormandoId = tf.FormandoId
				  WHERE tf.TurmaId = @TurmaId
				  GROUP BY f.FormandoId",
                    new { TurmaId = turmaId });

                // Map the durations to formandos
                foreach (var formando in formandos)
                {
                    var faltaData = faltasData.FirstOrDefault(f => f.FormandoId == formando.Id);
                    if (faltaData != default)
                    {
                        formando.FaltaJustificadas = new Falta
                        {
                            Duracao = faltaData.TotalFaltasJustificadas,
                            Justificada = true
                        };
                        formando.FaltaInjustificadas = new Falta
                        {
                            Duracao = faltaData.TotalFaltasInjustificadas,
                            Justificada = false
                        };
                    }
                }

                return formandos;
            }
        }

        public Formando GetById(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"SELECT DISTINCT p.*, f.*, lef.Id, lef.Nome, t.*, c.* FROM Formando AS f
								LEFT JOIN Pessoa as P
									ON f.PessoaId = p.Id
								LEFT JOIN EstadoFormando AS ef
									ON ef.PessoaId = p.Id
								LEFT JOIN ListaEstadosFormando AS lef
									ON lef.Id = ef.ListaEstadoId 
								LEFT JOIN TurmaFormando AS tf
									ON p.Id = tf.FormandoId
								LEFT JOIN Turma AS t
									ON tf.TurmaId = t.Id
								LEFT JOIN Curso AS c
									ON t.CursoId = c.Id
								WHERE p.Id = @Id AND f.EstadoId = ef.ListaEstadoId";
				return connection.Query<Formando, Estado, Turma, Curso, Formando>(sql,
					(formando, estado, turma, curso) =>
					{
						formando.Estado = estado;
						formando.Turma = turma;
						if (formando.Turma != null)
                        {
							formando.Turma.Curso = curso;
						}
							return formando;

					}, new { Id = id }, splitOn: "Id, Id, Id").FirstOrDefault();
			}
		}

		public void Create(Formando formando)
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
						//ou seja, so faz commit aos dados introduzidos quando as duas queries executarem sem erros

						string sql = @"INSERT INTO Pessoa (Nome, DataNascimento, Email, Password, Sexo, NIF, CC, ContactoTelemovel, ContactoTelefone, Morada, CP, CodigoCNAEF, HabilitacoesLiterarias, Nacionalidade, Foto, CV, PerfilId)
										VALUES (@Nome, @DataNascimento, @Email, @Password, @Sexo, @NIF, @CC, @ContactoTelemovel, @ContactoTelefone, @Morada, @CP, @CodigoCNAEF, @HabilitacoesLiterarias, @Nacionalidade, @Foto, @CV, @PerfilId)
										SELECT CAST(SCOPE_IDENTITY() as int)";

						//var id guarda o id da pessoa ao executar a primeira query (sql), para que (na segunda query) possa ser introduzido o id da pessoa na tabela formando
						//para isto funcionar, é necessário adicionar o SELECT CAST na primeira query
						var id = connection.ExecuteScalar<int>(sql, formando, transaction: transaction);
						sql = @"INSERT INTO Formando (PessoaId, IBAN, Bolsa, EstadoId)
								VALUES (" + id + ", @IBAN, @Bolsa, @EstadoId)";
						connection.Execute(sql, formando, transaction: transaction);
						sql = @"INSERT INTO EstadoFormando (PessoaId, ListaEstadoId, Data, Observacoes)
								VALUES(@PessoaId, @ListaEstadoId, @Data, 'Inserção')";
						connection.Execute(sql, new { PessoaId = id, ListaEstadoId = formando.Estado.Id, Data = DateTime.Now }, transaction);
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

		public void Create(List<Formando> formandos)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				//é necessário abrir a conexao quando é usada uma transaction
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						foreach (var formando in formandos)
						{
							//se a primeira query funcionar e a segunda por algum motivo falhar, a "transaction" faz com que os dados introduzidos da primeira query nao sejam gravados na bd
							//ou seja, so faz commit aos dados introduzidos quando as duas queries executarem sem erros

							string sql = @"INSERT INTO Pessoa (Nome, DataNascimento, Email, Password, Sexo, NIF, CC, ContactoTelemovel, ContactoTelefone, Morada, CP, CodigoCNAEF, HabilitacoesLiterarias, Nacionalidade, Foto, CV, PerfilId)
										VALUES (@Nome, @DataNascimento, @Email, @Password, @Sexo, @NIF, @CC, @ContactoTelemovel, @ContactoTelefone, @Morada, @CP, @CodigoCNAEF, @HabilitacoesLiterarias, @Nacionalidade, @Foto, @CV, @PerfilId)
										SELECT CAST(SCOPE_IDENTITY() as int)";

							//var id guarda o id da pessoa ao executar a primeira query (sql), para que (na segunda query) possa ser introduzido o id da pessoa na tabela formando
							//para isto funcionar, é necessário adicionar o SELECT CAST na primeira query
							var id = connection.ExecuteScalar<int>(sql, formando, transaction: transaction);
							sql = @"INSERT INTO Formando (PessoaId, IBAN, Bolsa, EstadoId)
								VALUES (" + id + ", @IBAN, @Bolsa, @EstadoId)";
							connection.Execute(sql, formando, transaction: transaction);
							sql = @"INSERT INTO EstadoFormando (PessoaId, ListaEstadoId, Data, Observacoes)
								VALUES(@PessoaId, @ListaEstadoId, @Data, 'Inserção')";
							connection.Execute(sql, new { PessoaId = id, ListaEstadoId = formando.Estado.Id, Data = DateTime.Now }, transaction);
						}
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

		public int CreateReturnId(Formando formando)
		{
			var idFormando = 0;

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
						idFormando = connection.ExecuteScalar<int>(sql, formando, transaction: transaction);
						sql = @"INSERT INTO Formando (PessoaId, IBAN, Bolsa, EstadoId)
								VALUES (" + idFormando + ", @IBAN, @Bolsa, @EstadoId)";
						connection.Execute(sql, formando, transaction: transaction);

						sql = @"INSERT INTO EstadoFormando (PessoaId, ListaEstadoId, Data, Observacoes)
								VALUES (@PessoaId, @ListaEstadoId, @Data, 'Inserção')";
						connection.Execute(sql, new { PessoaId = idFormando, ListaEstadoId = formando.Estado.Id, Data = DateTime.Now }, transaction);
						transaction.Commit();
					}
					catch
					{
						connection.Close();
						throw;
					}
				}
			}
			return idFormando;
		}

		public void CreateAvaliacaoModular(List<Formando> formandos, int idModulo, int formadorId)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"INSERT INTO AvaliacaoModular (FormandoId, NotaFinal, Comentarios, ModuloId, FormadorId, CursoId)
								VALUES (@FormandoId, @NotaFinal, @Comentarios, @ModuloId, @FormadorId, @CursoId);";
				foreach (var formando in formandos)
				{
					connection.Execute(sql, new
					{
						FormandoId = formando.Id,
						NotaFinal = formando.DictAvaliacaoModular[idModulo].NotaFinal, 
						Comentarios = formando.DictAvaliacaoModular[idModulo].Comentarios,
						ModuloId = idModulo, FormadorId = formadorId, 
						CursoId = formando.Turma.CursoId
					});
				}
			}
		}

		public void UpdateAvaliacaoModular(List<Formando> formandos, int idModulo)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"UPDATE AvaliacaoModular
								SET NotaFinal = @NotaFinal, Comentarios = @Comentarios
								WHERE FormandoId = @FormandoId AND ModuloId = @ModuloId AND CursoId = @CursoId;";
				foreach (var formando in formandos)
				{
					connection.Execute(sql, new
					{
						FormandoId = formando.Id,
						NotaFinal = formando.DictAvaliacaoModular[idModulo].NotaFinal,
						Comentarios = formando.DictAvaliacaoModular[idModulo].Comentarios,
						ModuloId = idModulo,
						CursoId = formando.Turma.CursoId
					});
				}
			}
		}

		public void CreateAvaliacaoFinal(List<Formando> formandos)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"INSERT INTO AvaliacaoFinal (FormandoId, CursoId, NotaFinal)
								VALUES (@FormandoId, @CursoId, @NotaFinal);";
				foreach (var formando in formandos)
				{
					connection.Execute(sql, new
					{
						FormandoId = formando.Id,
						CursoId = formando.Turma.CursoId,
						NotaFinal = formando.AvaliacaoFinal.NotaFinal
					});
				}
			}
		}

		public void UpdateAvaliacaoFinal(List<Formando> formandos)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"UPDATE AvaliacaoFinal
								SET NotaFinal = @NotaFinal
								WHERE FormandoId = @FormandoId AND CursoId = @CursoId;";
				foreach (var formando in formandos)
				{
					connection.Execute(sql, new
					{
						FormandoId = formando.Id,
						CursoId = formando.Turma.CursoId,
						NotaFinal = formando.AvaliacaoFinal.NotaFinal
					});
				}
			}
		}

		public void Remove(Formando formando)
		{
			Remove(formando.Id);
		}
		public void Remove(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"DELETE FROM EstadoFormando WHERE PessoaId = @Id
								DELETE FROM Formando WHERE PessoaId = @Id
								DELETE FROM Pessoa WHERE Id = @Id";
				connection.Execute(sql, new { Id = id });
			}
		}

		public void Update(Formando formando)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"UPDATE Pessoa
								SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, Password = @Password, Sexo = @Sexo, NIF = @NIF, CC = @CC, ContactoTelemovel = @ContactoTelemovel, ContactoTelefone = @ContactoTelefone, 
								Morada = @Morada, CP = @CP, CodigoCNAEF = @CodigoCNAEF, HabilitacoesLiterarias = @HabilitacoesLiterarias, Nacionalidade = @Nacionalidade, Foto = @Foto, CV = @CV
								WHERE Id = @Id
							 UPDATE Formando
								SET IBAN = @IBAN, Bolsa = @Bolsa, EstadoId = @EstadoId
								WHERE PessoaId = @Id";
				connection.Execute(sql, formando);
			}
		}

		public void UpdateHistEstado(Formando formando)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"INSERT INTO EstadoFormando (PessoaId, ListaEstadoId, Data, Observacoes)
							VALUES (@PessoaId, @ListaEstadoId, @Data, @Observacoes)";
				connection.Execute(sql, new { PessoaId = formando.Id, ListaEstadoId = formando.EstadoId, Data = DateTime.Now, Observacoes = formando.EstadosFormando.Observacoes });
			}
		}

		public List<EstadosFormando> ObterHistoricoDoFormando(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"SELECT ef.*, lef.* FROM Formando AS f
								INNER JOIN Pessoa as P
								ON f.PessoaId = p.Id
								LEFT JOIN EstadoFormando AS ef
								ON ef.PessoaId = p.Id
								LEFT JOIN ListaEstadosFormando AS lef
								ON lef.Id = ef.ListaEstadoId
								WHERE p.Id = @Id
								ORDER BY ef.Data";
				return connection.Query<EstadosFormando, Estado, EstadosFormando>(sql,
					(estadosFormando, estado) =>
					{
						estadosFormando.Estado = estado;
						return estadosFormando;

					}, new { Id = id }, splitOn: "Id").ToList();
			}
		}
	}
}