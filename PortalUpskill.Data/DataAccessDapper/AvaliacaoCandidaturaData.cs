using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class AvaliacaoCandidaturaData : IAvaliacaoCandidaturaData
    {
        private string _connectionString;

        public AvaliacaoCandidaturaData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public AvaliacaoCandidatura GetByCandidatura(int candidaturaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT * FROM AvaliacaoCandidatura 
                               WHERE CandidaturaId = @CandidaturaId";
                return connection.QueryFirstOrDefault<AvaliacaoCandidatura>(sql, new { CandidaturaId = candidaturaId });
            }
        }

        public void Create(AvaliacaoCandidatura avaliacao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO AvaliacaoCandidatura 
                               (CandidaturaId, NotaPsicometrica, NotaIngles, PassouEntrevista, Observacoes, DataAvaliacao)
                               VALUES (@CandidaturaId, @NotaPsicometrica, @NotaIngles, @PassouEntrevista, @Observacoes, @DataAvaliacao)";
                connection.Execute(sql, avaliacao);
            }
        }

        public void Update(AvaliacaoCandidatura avaliacao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE AvaliacaoCandidatura 
                               SET NotaPsicometrica = @NotaPsicometrica,
                                   NotaIngles = @NotaIngles,
                                   PassouEntrevista = @PassouEntrevista,
                                   Observacoes = @Observacoes,
                                   DataAvaliacao = @DataAvaliacao
                               WHERE CandidaturaId = @CandidaturaId";
                connection.Execute(sql, avaliacao);
            }
        }
    }
}