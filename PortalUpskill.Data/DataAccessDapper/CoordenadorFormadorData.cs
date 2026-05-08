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
    public class CoordenadorFormadorData : ICoordenadorFormadorData
    {
        private string _connectionString;

        public CoordenadorFormadorData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<CoordenadorFormador> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT DISTINCT p.*, f.*, lef.Id, lef.Nome FROM Formador AS f
								INNER JOIN Pessoa AS p
									ON f.PessoaId = p.Id
								INNER JOIN EstadoFormador AS ef
									ON ef.PessoaId = p.Id
								INNER JOIN ListaEstadosFormador AS lef
									ON lef.Id = ef.ListaEstadoId
                                INNER JOIN Pessoal AS pe
                                    ON pe.PessoaId = p.Id
								WHERE f.EstadoId = ef.ListaEstadoId";

                return connection.Query<CoordenadorFormador, Estado, CoordenadorFormador>(sql,
                (coordenadorformador, estado) =>
                {
                    coordenadorformador.Estado = estado;
                    return coordenadorformador;
                }, splitOn: "Id").ToList();
            }
        }

        public CoordenadorFormador GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT DISTINCT p.*, f.*, ef.*, lef.Id, lef.Nome FROM Formador AS f
								INNER JOIN Pessoa AS p
									ON f.PessoaId = p.Id
								INNER JOIN EstadoFormador AS ef
									ON ef.PessoaId = p.Id
								INNER JOIN ListaEstadosFormador AS lef
									ON lef.Id = ef.ListaEstadoId
                                INNER JOIN Pessoal AS pe
                                    ON pe.PessoaId = p.Id
								WHERE p.Id = @Id AND f.EstadoId = ef.ListaEstadoId";
                return connection.Query<CoordenadorFormador, Estado, CoordenadorFormador>(sql,
                (coordenadorformador, estado) =>
                {
                    coordenadorformador.Estado = estado;
                    return coordenadorformador;
                }, new { Id = id }, splitOn: "Id").FirstOrDefault();
            }
        }

        public void Create(CoordenadorFormador coordenadorformador)
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
                        var id = connection.ExecuteScalar<int>(sql, coordenadorformador, transaction: transaction);
                        sql = @"INSERT INTO Formador (PessoaId, CCP, DocenteEnsSuperior, EstadoId)
								VALUES (" + id + ", @CCP, @DocenteEnsSuperior, @EstadoId)";
                        connection.Execute(sql, coordenadorformador, transaction: transaction);

                        sql = @"INSERT INTO EstadoFormador (PessoaId, ListaEstadoId, Data, Observacoes)
								VALUES (@PessoaId, @ListaEstadoId, @Data, 'Inserção')";
                        connection.Execute(sql, new { PessoaId = id, ListaEstadoId = coordenadorformador.EstadoId, Data = DateTime.Now }, transaction);

                        sql = @"INSERT INTO Pessoal (PessoaId, Funcao)
								VALUES (" + id + ", @Funcao)";
                        connection.Execute(sql, coordenadorformador, transaction: transaction);
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

        public int CreateReturnId(CoordenadorFormador coordenadorformador)
        {
            var idCoordFormador = 0;

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
                        idCoordFormador = connection.ExecuteScalar<int>(sql, coordenadorformador, transaction: transaction);
                        sql = @"INSERT INTO Formador (PessoaId, CCP, DocenteEnsSuperior, EstadoId)
								VALUES (" + idCoordFormador + ", @CCP, @DocenteEnsSuperior, @EstadoId)";
                        connection.Execute(sql, coordenadorformador, transaction: transaction);

                        sql = @"INSERT INTO EstadoFormador (PessoaId, ListaEstadoId, Data, Observacoes)
								VALUES (@PessoaId, @ListaEstadoId, @Data, 'Inserção')";
                        connection.Execute(sql, new { PessoaId = idCoordFormador, ListaEstadoId = coordenadorformador.EstadoId, Data = DateTime.Now }, transaction);

                        sql = @"INSERT INTO Pessoal (PessoaId, Funcao)
								VALUES (" + idCoordFormador + ", @Funcao)";
                        connection.Execute(sql, coordenadorformador, transaction: transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        connection.Close();
                        throw;
                    }
                }
            }
            return idCoordFormador;
        }

        public void Remove(CoordenadorFormador coordenadorformador)
        {
            Remove(coordenadorformador.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Formador WHERE PessoaId = @Id
								DELETE FROM Pessoa WHERE Id = @Id
                                DELETE FROM Pessoal WHERE PessoaId = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public void Update(CoordenadorFormador coordenadorformador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Pessoa
								SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, Password = @Password, Sexo = @Sexo, NIF = @NIF, CC = @CC, ContactoTelemovel = @ContactoTelemovel, ContactoTelefone = @ContactoTelefone, 
								Morada = @Morada, CP = @CP, CodigoCNAEF = @CodigoCNAEF, HabilitacoesLiterarias = @HabilitacoesLiterarias, Nacionalidade = @Nacionalidade, Foto = @Foto, CV = @CV
								WHERE Id = @Id
							 UPDATE Formador
								SET CCP = @CCP, DocenteEnsSuperior = @DocenteEnsSuperior, EstadoId = @EstadoId
								WHERE PessoaId = @Id";

                connection.Execute(sql, coordenadorformador);
            }
        }

        public void UpdateHistEstado(CoordenadorFormador coordenadorformador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO EstadoFormador (PessoaId, ListaEstadoId, Data, Observacoes)
							VALUES (@PessoaId, @ListaEstadoId, @Data, 'Alterado')";
                connection.Execute(sql, new { PessoaId = coordenadorformador.Id, ListaEstadoId = coordenadorformador.EstadoId, Data = DateTime.Now });
            }
        }
    }
}
