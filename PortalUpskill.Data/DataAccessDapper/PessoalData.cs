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
    public class PessoalData : IPessoalData
    {
        private string _connectionString;

        public PessoalData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Pessoal> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoal>("SELECT * FROM Pessoal, Pessoa WHERE dbo.Pessoa.Id = dbo.Pessoal.PessoaId").ToList();
            }
        }

        public Pessoal GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Pessoal, Pessoa WHERE dbo.Pessoa.Id = dbo.Pessoal.PessoaId AND dbo.Pessoal.PessoaId = @Id";
                return connection.Query<Pessoal>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public void Create(Pessoal pessoal)
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

                        string sql = @"INSERT INTO Pessoa (Nome, DataNascimento, Email, Password, Sexo, NIF, CC, ContactoTelemovel, ContactoTelefone, Morada, CP, CodigoCNAEF, HabilitacoesLiterarias, Nacionalidade, Foto, CV)
										VALUES (@Nome, @DataNascimento, @Email, @Password, @Sexo, @NIF, @CC, @ContactoTelemovel, @ContactoTelefone, @Morada, @CP, @CodigoCNAEF, @HabilitacoesLiterarias, @Nacionalidade, @Foto, @CV)
										SELECT CAST(SCOPE_IDENTITY() as int)";

                        //var id guarda o id da pessoa ao executar a primeira query (sql), para que (na segunda query) possa ser introduzido o id da pessoa na tabela Pessoal
                        //para isto funcionar, é necessário adicionar o SELECT CAST na primeira query
                        var id = connection.ExecuteScalar<int>(sql, pessoal, transaction: transaction);
                        sql = @"INSERT INTO Pessoal (PessoaId, Funcao)
								VALUES (" + id + ", @Funcao)";
                        connection.Execute(sql, pessoal, transaction: transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        //caso haja algum erro ao executar as queries de cima, a conexão é fechada
                        connection.Close();
                        //throw;
                    }
                }
            }
        }

        public int CreateReturnId(Pessoal pessoal)
        {
            var idPessoal = 0;

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
                        idPessoal = connection.ExecuteScalar<int>(sql, pessoal, transaction: transaction);
                        sql = @"INSERT INTO Pessoal (PessoaId, Funcao)
								VALUES (" + idPessoal + ", @Funcao)";
                        connection.Execute(sql, pessoal, transaction: transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        connection.Close();
                        throw;
                    }
                }
            }
            return idPessoal;
        }

        public void Remove(Pessoal pessoal)
        {
            Remove(pessoal.Id);
        }
        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Pessoal WHERE PessoaId = @Id
								DELETE FROM Pessoa WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
        public void Update(Pessoal pessoal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Pessoa
								SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, Password = @Password, Sexo = @Sexo, NIF = @NIF, CC = @CC, ContactoTelemovel = @ContactoTelemovel, ContactoTelefone = @ContactoTelefone, 
								Morada = @Morada, CP = @CP, CodigoCNAEF = @CodigoCNAEF, HabilitacoesLiterarias = @HabilitacoesLiterarias, Nacionalidade = @Nacionalidade, Foto = @Foto, CV = @CV
								WHERE Id = @Id
							 UPDATE Pessoal
								SET Funcao = @Funcao
								WHERE PessoaId = @Id";
                connection.Execute(sql, pessoal);
            }
        }
    }
}
