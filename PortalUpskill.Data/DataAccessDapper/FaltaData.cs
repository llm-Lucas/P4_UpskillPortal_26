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
    public class FaltaData : IFaltaData
    {
        private string _connectionString;

        public FaltaData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        // ── Leitura ─────────────────────────────────────────────

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
                return connection.Query<Falta>(
                    "SELECT * FROM Falta WHERE Id = @Id",
                    new { Id = id }).FirstOrDefault();
            }
        }

        public List<Falta> GetByAulaId(int aulaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT AulaId, FormandoId, HoraInicio, HoraFim,
                                      Justificada, Anexo, Duracao
                               FROM Falta WHERE AulaId = @AulaId";
                return connection.Query<Falta>(sql, new { AulaId = aulaId }).ToList();
            }
        }

        /// <summary>
        /// Devolve as faltas do formando com a Aula e o Módulo incluídos,
        /// para que a PaginaFaltasFormando consiga mostrar data e módulo de cada falta.
        /// </summary>
        public List<Falta> GetByFormandoId(int formandoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                    SELECT f.*, a.*, m.*
                    FROM Falta f
                    INNER JOIN Aula   a ON f.AulaId   = a.Id
                    INNER JOIN Modulo m ON a.ModuloId = m.Id
                    WHERE f.FormandoId = @FormandoId
                    ORDER BY f.HoraInicio DESC";

                return connection.Query<Falta, Aula, Modulo, Falta>(
                    sql,
                    (falta, aula, modulo) =>
                    {
                        falta.Aula = aula;
                        if (falta.Aula != null)
                            falta.Aula.Modulo = modulo;
                        return falta;
                    },
                    new { FormandoId = formandoId },
                    splitOn: "Id,Id"
                ).ToList();
            }
        }

        /// <summary>
        /// Devolve todas as faltas com Estado = 'Pendente', com Aula e Módulo incluídos.
        /// Usado em ValidarJustificacoes pelo admin/coordenador.
        /// </summary>
        public List<Falta> GetFaltasPendentes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
                    SELECT f.*, a.*, m.*
                    FROM Falta f
                    INNER JOIN Aula   a ON f.AulaId   = a.Id
                    INNER JOIN Modulo m ON a.ModuloId = m.Id
                    WHERE f.Estado = 'Pendente'
                    ORDER BY f.HoraInicio DESC";

                return connection.Query<Falta, Aula, Modulo, Falta>(
                    sql,
                    (falta, aula, modulo) =>
                    {
                        falta.Aula = aula;
                        if (falta.Aula != null)
                            falta.Aula.Modulo = modulo;
                        return falta;
                    },
                    splitOn: "Id,Id"
                ).ToList();
            }
        }

        // ── Escrita ─────────────────────────────────────────────

        public void Create(Falta falta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Falta
                                   (AulaId, FormandoId, HoraInicio, HoraFim,
                                    Justificada, Anexo, Duracao)
                               VALUES
                                   (@AulaId, @FormandoId, @HoraInicio, @HoraFim,
                                    @Justificada, @Anexo, @Duracao)";
                connection.Execute(sql, falta);
            }
        }

        public void Create(List<Falta> faltas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Falta
                                   (AulaId, FormandoId, HoraInicio, HoraFim,
                                    Justificada, Anexo, Duracao)
                               VALUES
                                   (@AulaId, @FormandoId, @HoraInicio, @HoraFim,
                                    @Justificada, @Anexo, @Duracao)";
                foreach (var falta in faltas)
                    connection.Execute(sql, falta);
            }
        }

        public void Update(Falta falta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Falta
                               SET AulaId      = @AulaId,
                                   FormandoId  = @FormandoId,
                                   HoraInicio  = @HoraInicio,
                                   HoraFim     = @HoraFim,
                                   Justificada = @Justificada,
                                   Anexo       = @Anexo,
                                   Duracao     = @Duracao
                               WHERE Id = @Id";
                connection.Execute(sql, falta);
            }
        }

        public void Update(List<Falta> faltas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Falta
                               SET AulaId      = @AulaId,
                                   FormandoId  = @FormandoId,
                                   HoraInicio  = @HoraInicio,
                                   HoraFim     = @HoraFim,
                                   Justificada = @Justificada,
                                   Anexo       = @Anexo,
                                   Duracao     = @Duracao
                               WHERE FormandoId = @FormandoId AND AulaId = @AulaId";
                foreach (var falta in faltas)
                    connection.Execute(sql, falta);
            }
        }

        public void Remove(Falta falta) => Remove(falta.Id);

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Falta WHERE Id = @Id", new { Id = id });
            }
        }

        public void Remove(List<Falta> faltas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Falta WHERE FormandoId = @FormandoId AND AulaId = @AulaId";
                foreach (var falta in faltas)
                    connection.Execute(sql, falta);
            }
        }

        // ── Fluxo de justificação ────────────────────────────────

        /// <summary>
        /// Chamado quando o formando confirma a submissão no painel de preview.
        /// Grava o caminho do anexo, a observação escrita pelo formando,
        /// e define o Estado como 'Pendente' para revisão pelo admin/coordenador.
        /// </summary>
        public void SubmeterJustificacao(int faltaId, string caminhoAnexo, string observacoes)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Falta
                               SET Anexo      = @Anexo,
                                   Observacoes = @Observacoes,
                                   Estado      = 'Pendente'
                               WHERE Id = @Id";
                connection.Execute(sql, new { Id = faltaId, Anexo = caminhoAnexo, Observacoes = observacoes });
            }
        }

        /// <summary>
        /// Chamado quando o formando cancela uma submissão ainda em estado 'Pendente'.
        /// Limpa o anexo e a observação, e repõe o Estado a NULL
        /// para que o formando possa recomeçar o processo.
        /// A remoção física do ficheiro do disco é feita no Razor antes de chamar este método.
        /// </summary>
        public void CancelarJustificacao(int faltaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Falta
                               SET Anexo       = NULL,
                                   Observacoes = NULL,
                                   Estado      = NULL
                               WHERE Id = @Id AND Estado = 'Pendente'";
                connection.Execute(sql, new { Id = faltaId });
            }
        }

        /// <summary>
        /// Chamado pelo admin/coordenador em ValidarJustificacoes.
        /// Define o estado final da falta (Justificada/Injustificada),
        /// atualiza o campo booleano Justificada (compatível com os cálculos
        /// de percentagem existentes em todo o projeto),
        /// e grava as observações de feedback.
        /// Se rejeitada, o anexo é limpo (já não serve propósito).
        /// </summary>
        public void AtualizarEstadoFalta(int faltaId, string estado, bool justificada, string observacoes)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = estado == "Injustificada"
                    ? @"UPDATE Falta
                        SET Estado      = @Estado,
                            Justificada = @Justificada,
                            Observacoes = @Observacoes,
                            Anexo       = NULL
                        WHERE Id = @Id"
                    : @"UPDATE Falta
                        SET Estado      = @Estado,
                            Justificada = @Justificada,
                            Observacoes = @Observacoes
                        WHERE Id = @Id";

                connection.Execute(sql, new
                {
                    Id = faltaId,
                    Estado = estado,
                    Justificada = justificada,
                    Observacoes = observacoes
                });
            }
        }
    }
}