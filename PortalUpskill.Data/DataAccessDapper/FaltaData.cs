using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class FaltaData : IFaltaData
    {
        private string _connectionString;

        // INICIO #008
        // Metodo para a tabela no /DetalhesFormando que mostra as datas das faltas justificadas e injustificadas
        public List<Falta> GetByFormandoId(int formandoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                SELECT * 
                FROM Falta 
                WHERE FormandoId = @FormandoId
                ORDER BY HoraInicio DESC";

                return connection.Query<Falta>(sql, new { FormandoId = formandoId }).ToList();
            }
        }
        // FIM

        public FaltaData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Falta> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Falta>("SELECT * FROM Falta").ToList();
            }
        }

        public Falta GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Falta WHERE Id = @Id";
                return connection.Query<Falta>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public List<Falta> GetByAulaId(int aulaId)
		{
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT AulaId, FormandoId, HoraInicio, HoraFim, Justificada, Anexo, Duracao  FROM Falta WHERE AulaId = @AulaId";
                return connection.Query<Falta>(sql, new { AulaId = aulaId }).ToList();
            }
        }

        public void Create(Falta falta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Falta (AulaId, FormandoId, HoraInicio, HoraFim, Justificada, Anexo, Duracao)
                                VALUES (@AulaId, @FormandoId, @HoraInicio, @HoraFim, @Justificada, @Anexo, @Duracao)";
                connection.Execute(sql, falta);
            }
        }

        public void Create(List<Falta> faltas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Falta (AulaId, FormandoId, HoraInicio, HoraFim, Justificada, Anexo, Duracao)
                                VALUES (@AulaId, @FormandoId, @HoraInicio, @HoraFim, @Justificada, @Anexo, @Duracao)";
                foreach (var falta in faltas)
				{
                    connection.Execute(sql, falta);
                }
            }
        }

        public void Remove(Falta falta)
        {
            Remove(falta.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Falta WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });

            }
        }
        public void Remove(List<Falta> faltas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Falta WHERE FormandoId = @FormandoId AND AulaId = @AulaId";
                foreach (var falta in faltas)
                {
                    connection.Execute(sql, falta);
                }
            }
        }

        public void Update(Falta falta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Falta 
                               SET AulaId = @AulaId, FormandoId = @FormandoId, HoraInicio = @HoraInicio, HoraFim = @HoraFim, Justificada = @Justificada, Anexo = @Anexo, Duracao = @Duracao
                               WHERE Id = @Id";
                connection.Execute(sql, falta);
            }
        }

        public void Update(List<Falta> faltas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Falta 
                               SET AulaId = @AulaId, FormandoId = @FormandoId, HoraInicio = @HoraInicio, HoraFim = @HoraFim, Justificada = @Justificada, Anexo = @Anexo, Duracao = @Duracao
                               WHERE FormandoId = @FormandoId AND AulaId = @AulaId";
				foreach (var falta in faltas)
				{
                    connection.Execute(sql, falta);
                }
            }
        }
    }
}
