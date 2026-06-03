using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using PortalUpskill.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class CandidaturaData : ICandidaturaData
    {
        private string _connectionString;

        public CandidaturaData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Candidatura> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT c.*, 
                                      p.Id, p.Nome, p.Email, p.ContactoTelemovel,
                                      c1.Id, c1.Nome,
                                      c2.Id, c2.Nome,
                                      ec.Id, ec.Nome
                               FROM Candidatura c
                               INNER JOIN Pessoa p ON p.Id = c.PessoaId
                               INNER JOIN Curso c1 ON c1.Id = c.PrimeiraOpcaoId
                               LEFT JOIN Curso c2 ON c2.Id = c.SegundaOpcaoId
                               INNER JOIN EstadoCandidatura ec ON ec.Id = c.EstadoId
                               ORDER BY c.DataCriacao DESC";

                return connection.Query<Candidatura, Pessoa, Curso, Curso, EstadoCandidatura, Candidatura>(
                    sql, (candidatura, pessoa, primeiraOpcao, segundaOpcao, estado) =>
                    {
                        candidatura.Pessoa = pessoa;
                        candidatura.PrimeiraOpcao = primeiraOpcao;
                        candidatura.SegundaOpcao = segundaOpcao;
                        candidatura.Estado = estado;
                        return candidatura;
                    }, splitOn: "Id, Id, Id, Id").ToList();
            }
        }

        public Candidatura GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT c.*, 
                                      p.Id, p.Nome, p.Email, p.ContactoTelemovel,
                                      c1.Id, c1.Nome,
                                      c2.Id, c2.Nome,
                                      ec.Id, ec.Nome
                               FROM Candidatura c
                               INNER JOIN Pessoa p ON p.Id = c.PessoaId
                               INNER JOIN Curso c1 ON c1.Id = c.PrimeiraOpcaoId
                               LEFT JOIN Curso c2 ON c2.Id = c.SegundaOpcaoId
                               INNER JOIN EstadoCandidatura ec ON ec.Id = c.EstadoId
                               WHERE c.Id = @Id";

                return connection.Query<Candidatura, Pessoa, Curso, Curso, EstadoCandidatura, Candidatura>(
                    sql, (candidatura, pessoa, primeiraOpcao, segundaOpcao, estado) =>
                    {
                        candidatura.Pessoa = pessoa;
                        candidatura.PrimeiraOpcao = primeiraOpcao;
                        candidatura.SegundaOpcao = segundaOpcao;
                        candidatura.Estado = estado;
                        return candidatura;
                    }, new { Id = id }, splitOn: "Id, Id, Id, Id").FirstOrDefault();
            }
        }

        public int Create(Candidatura candidatura)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Candidatura 
                        (PessoaId, PrimeiraOpcaoId, SegundaOpcaoId, Observacoes, EstadoId,
                         Foto, CV, CertificadoHabilitacoes, CCFrente, CCVerso, SituacaoProfissional, TermosAceites)
                       VALUES 
                        (@PessoaId, @PrimeiraOpcaoId, @SegundaOpcaoId, @Observacoes, @EstadoId,
                         @Foto, @CV, @CertificadoHabilitacoes, @CCFrente, @CCVerso, @SituacaoProfissional, @TermosAceites)
                       SELECT CAST(SCOPE_IDENTITY() as int)";
                return connection.ExecuteScalar<int>(sql, candidatura);
            }
        }

        public void UpdateEstado(int candidaturaId, int estadoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Candidatura SET EstadoId = @EstadoId WHERE Id = @Id";
                connection.Execute(sql, new { Id = candidaturaId, EstadoId = estadoId });
            }
        }
        public void Update(int id, int primeiraOpcaoId, int? segundaOpcaoId, string observacoes, string foto, string cv, string cert, string ccFrente, string ccVerso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Candidatura 
                       SET PrimeiraOpcaoId = @PrimeiraOpcaoId,
                           SegundaOpcaoId = @SegundaOpcaoId,
                           Observacoes = @Observacoes,
                           Foto = @Foto,
                           CV = @CV,
                           CertificadoHabilitacoes = @Cert,
                           CCFrente = @CCFrente,
                           CCVerso = @CCVerso
                       WHERE Id = @Id";
                connection.Execute(sql, new { Id = id, PrimeiraOpcaoId = primeiraOpcaoId, SegundaOpcaoId = segundaOpcaoId, Observacoes = observacoes, Foto = foto, CV = cv, Cert = cert, CCFrente = ccFrente, CCVerso = ccVerso });
            }
        }
        public void Submeter(int candidaturaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Candidatura SET EstadoId = 2 WHERE Id = @Id";
                connection.Execute(sql, new { Id = candidaturaId });
            }
        }
        public void UpdateSituacaoProfissional(int candidaturaId, string situacao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Candidatura SET SituacaoProfissional = @Situacao WHERE Id = @Id";
                connection.Execute(sql, new { Id = candidaturaId, Situacao = situacao });
            }
        }
    }
}