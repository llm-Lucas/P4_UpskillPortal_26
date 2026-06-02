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
                // 1. Corrigido: Adicionado o "FROM Falta f" e organizada a seleção (f.*, a.*, m.*)
                string sql = @"
        SELECT f.*, a.*, m.* FROM Falta f
        INNER JOIN Aula a ON f.AulaId = a.Id
        INNER JOIN Modulo m ON a.ModuloId = m.Id
        WHERE f.FormandoId = @FormandoId
        ORDER BY f.HoraInicio DESC";

                // 2. Corrigido: Usar o mapeamento de múltiplos objetos <Falta, Aula, Modulo, Falta>
                return connection.Query<Falta, Aula, Modulo, Falta>(
                    sql,
                    (falta, aula, modulo) =>
                    {
                        falta.Aula = aula;
                        if (falta.Aula != null)
                        {
                            falta.Aula.Modulo = modulo;
                        }
                        return falta;
                    },
                    new { FormandoId = formandoId },
                    splitOn: "Id,Id" // Indica ao Dapper para dividir os objetos sempre que encontrar a coluna 'Id'
                ).ToList();
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

        public List<Falta> GetFaltasPendentes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // 1. O SQL precisa de selecionar f.*, a.* e m.* e fazer os JOINs
                string sql = @"
        SELECT f.*, a.*, m.* FROM Falta f
        INNER JOIN Aula a ON f.AulaId = a.Id
        INNER JOIN Modulo m ON a.ModuloId = m.Id
        WHERE f.Estado = 'Pendente' OR f.Estado IS NULL OR f.Estado = ''
        ORDER BY f.HoraInicio DESC";

                // 2. Usar o Query<Falta, Aula, Modulo, Falta> para ligar os objetos em memória
                return connection.Query<Falta, Aula, Modulo, Falta>(
                    sql,
                    (falta, aula, modulo) =>
                    {
                        falta.Aula = aula;
                        if (falta.Aula != null)
                        {
                            falta.Aula.Modulo = modulo;
                        }
                        return falta;
                    },
                    splitOn: "Id,Id" // Diz ao Dapper onde começa a separação de colunas de cada tabela
                ).ToList();
            }
        }

        public void SubmeterJustificacao(int faltaId, string caminhoAnexo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Falta SET Anexo = @Anexo, Estado = 'Pendente' WHERE Id = @Id";
                connection.Execute(sql, new { Id = faltaId, Anexo = caminhoAnexo });
            }
        }

        public void AtualizarEstadoFalta(int faltaId, string estado, bool justificada, string observacoes)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Se for rejeitada (Injustificada), limpamos o anexo e gravamos a observação/motivo
                string sql = estado == "Injustificada"
                    ? "UPDATE Falta SET Estado = @Estado, Justificada = @Justificada, Observacoes = @Observacoes, Anexo = NULL WHERE Id = @Id"
                    : "UPDATE Falta SET Estado = @Estado, Justificada = @Justificada, Observacoes = @Observacoes WHERE Id = @Id";

                connection.Execute(sql, new { Id = faltaId, Estado = estado, Justificada = justificada, Observacoes = observacoes });
            }
        }

        public void ProcessarValidacao(int faltaId, string novoEstado, string observacoes)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Falta 
                       SET Estado = @Estado, 
                           Observacoes = @Observacoes, 
                           Justificada = @Justificada 
                       WHERE Id = @Id";

                bool justificada = (novoEstado == "Justificada");

                connection.Execute(sql, new { Id = faltaId, Estado = novoEstado, Observacoes = observacoes, Justificada = justificada });
            }
        }
    }
}
