using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class PessoaData : IPessoaData
    {
        private string _connectionString;

        public PessoaData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<Pessoa> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>("SELECT * FROM Pessoa").ToList();
            }
        }
        public Pessoa GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Pessoa WHERE Id = @Id";
                return connection.Query<Pessoa>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public Pessoa GetByEmail(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT * FROM Pessoa AS p
                        INNER JOIN Perfil AS pf
                            ON p.PerfilId = pf.Id
                        WHERE p.Email = @Email";

                return connection.Query<Pessoa, Perfil, Pessoa>(
                    sql,
                    (pessoa, perfil) =>
                    {
                        pessoa.Perfil = perfil;
                        pessoa.PerfilId = perfil?.Id; // ← CORREÇÃO: atribui manualmente o PerfilId
                        return pessoa;
                    },
                    new { Email = email },
                    splitOn: "PerfilId").FirstOrDefault();
            }
        }

        public void Create(Pessoa pessoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Pessoa (Nome, DataNascimento, Email, Password, Sexo, NIF, CC, ContactoTelemovel, ContactoTelefone, Morada, CP, CodigoCNAEF, HabilitacoesLiterarias, Nacionalidade, Foto, PerfilId, CV)
                                VALUES (@Nome, @DataNascimento, @Email, @Password, @Sexo, @NIF, @CC, @ContactoTelemovel, @ContactoTelefone, @Morada, @CP, @CodigoCNAEF, @HabilitacoesLiterarias, @Nacionalidade, @Foto, @PerfilId, @CV)";
                connection.Execute(sql, pessoa);
            }
        }

        public void Remove(Pessoa pessoa)
        {
            Remove(pessoa.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Pessoa WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public void Update(Pessoa pessoa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Pessoa 
                                SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, Password = @Password, Sexo = @Sexo, NIF = @NIF, CC = @CC, ContactoTelemovel = @ContactoTelemovel, ContactoTelefone = @ContactoTelefone, 
                                Morada = @Morada, CP = @CP, CodigoCNAEF = @CodigoCNAEF, HabilitacoesLiterarias = @HabilitacoesLiterarias, Nacionalidade = @Nacionalidade, Foto = @Foto, PerfilId = @PerfilId, CV = @CV
                                WHERE Id = @Id";
                connection.Execute(sql, pessoa);
            }
        }

        public void UpdatePassword(Pessoa pessoa, string newPass)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Pessoa 
                               SET Password = @NewPass
                               WHERE Id = @Id";
                connection.Execute(sql, new { Id = pessoa.Id, NewPass = newPass });
            }
        }
    }
}
