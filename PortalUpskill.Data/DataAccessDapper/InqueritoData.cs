using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class InqueritoData : IInqueritoData
    {
        private string _connectionString;

        public InqueritoData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public bool FormandoJaSubmeteu(int formandoId, int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT COUNT(*) 
                               FROM InqueritoFormandoSubmetido 
                               WHERE FormandoId = @FormandoId 
                               AND TurmaId = @TurmaId";

                int count = connection.ExecuteScalar<int>(sql, new
                {
                    FormandoId = formandoId,
                    TurmaId = turmaId
                });

                return count > 0;
            }
        }

        public int CreateSubmissao(InqueritoSubmissao submissao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO InqueritoSubmissao 
               (TurmaId, CursoId, DataSubmissao, AvaliacaoGeral, ComentarioGeral)
               VALUES 
               (@TurmaId, @CursoId, @DataSubmissao, @AvaliacaoGeral, @ComentarioGeral);
               SELECT CAST(SCOPE_IDENTITY() as int);";

                return connection.ExecuteScalar<int>(sql, submissao);
            }
        }

        public void CreateModulo(InqueritoModulo modulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO InqueritoModulo (InqueritoSubmissaoId, ModuloId, Avaliacao, Comentario)
                               VALUES (@InqueritoSubmissaoId, @ModuloId, @Avaliacao, @Comentario)";

                connection.Execute(sql, modulo);
            }
        }

        public void CreateFormador(InqueritoFormador formador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO InqueritoFormador (InqueritoSubmissaoId, FormadorId, Avaliacao, Comentario)
                               VALUES (@InqueritoSubmissaoId, @FormadorId, @Avaliacao, @Comentario)";

                connection.Execute(sql, formador);
            }
        }

        public void MarcarFormandoComoSubmetido(InqueritoFormandoSubmetido submetido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO InqueritoFormandoSubmetido (FormandoId, TurmaId, DataSubmissao)
                               VALUES (@FormandoId, @TurmaId, @DataSubmissao)";

                connection.Execute(sql, submetido);
            }
        }
        public List<RelatorioInqueritoModulo> GetRelatorioModulos(int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
    SELECT 
        m.Id AS ModuloId,
        m.Nome AS ModuloNome,
        AVG(CAST(im.Avaliacao AS FLOAT)) AS MediaAvaliacao,
        COUNT(*) AS TotalRespostas
    FROM InqueritoModulo im
    INNER JOIN Modulo m ON m.Id = im.ModuloId
    INNER JOIN InqueritoSubmissao s ON s.Id = im.InqueritoSubmissaoId
    WHERE s.TurmaId = @TurmaId
    GROUP BY m.Id, m.Nome
    ORDER BY m.Id";

                return connection.Query<RelatorioInqueritoModulo>(sql, new { TurmaId = turmaId }).ToList();
            }
        }

        public List<RelatorioInqueritoFormador> GetRelatorioFormadores(int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
    SELECT 
        p.Id AS FormadorId,
        p.Nome AS FormadorNome,
        AVG(CAST(ifor.Avaliacao AS FLOAT)) AS MediaAvaliacao,
        COUNT(*) AS TotalRespostas
    FROM InqueritoFormador ifor
    INNER JOIN Pessoa p ON p.Id = ifor.FormadorId
    INNER JOIN InqueritoSubmissao s ON s.Id = ifor.InqueritoSubmissaoId
    WHERE s.TurmaId = @TurmaId
    GROUP BY p.Id, p.Nome
    ORDER BY p.Nome";

                return connection.Query<RelatorioInqueritoFormador>(sql, new { TurmaId = turmaId }).ToList();
            }
        }

        public List<RelatorioInqueritoComentario> GetComentarios(int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
            SELECT 
                s.Id AS Id,
                'Geral' AS Tipo,
                'Avaliação Geral do Curso' AS Nome,
                s.ComentarioGeral AS Comentario
            FROM InqueritoSubmissao s
            WHERE s.TurmaId = @TurmaId
              AND s.ComentarioGeral IS NOT NULL
              AND s.ComentarioGeral <> ''

            UNION ALL

            SELECT 
                im.Id AS Id,
                'Módulo' AS Tipo,
                m.Nome AS Nome,
                im.Comentario
            FROM InqueritoModulo im
            INNER JOIN Modulo m ON m.Id = im.ModuloId
            INNER JOIN InqueritoSubmissao s ON s.Id = im.InqueritoSubmissaoId
            WHERE s.TurmaId = @TurmaId
              AND im.Comentario IS NOT NULL 
              AND im.Comentario <> ''

            UNION ALL

            SELECT 
                ifor.Id AS Id,
                'Formador' AS Tipo,
                p.Nome AS Nome,
                ifor.Comentario
            FROM InqueritoFormador ifor
            INNER JOIN Pessoa p ON p.Id = ifor.FormadorId
            INNER JOIN InqueritoSubmissao s ON s.Id = ifor.InqueritoSubmissaoId
            WHERE s.TurmaId = @TurmaId
              AND ifor.Comentario IS NOT NULL 
              AND ifor.Comentario <> ''

            ORDER BY Tipo, Nome";

                return connection.Query<RelatorioInqueritoComentario>(
                    sql,
                    new { TurmaId = turmaId }).ToList();
            }
        }

        public int GetTotalSubmissoes(int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT COUNT(*) 
               FROM InqueritoSubmissao 
               WHERE TurmaId = @TurmaId";

                return connection.ExecuteScalar<int>(sql, new { TurmaId = turmaId });
            }
        }
        public RelatorioInqueritoGeral GetRelatorioGeral(int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
            SELECT 
                AVG(CAST(AvaliacaoGeral AS FLOAT)) AS MediaAvaliacaoGeral,
                COUNT(*) AS TotalRespostas
            FROM InqueritoSubmissao
            WHERE TurmaId = @TurmaId
              AND AvaliacaoGeral IS NOT NULL";

                return connection.QueryFirstOrDefault<RelatorioInqueritoGeral>(
                    sql,
                    new { TurmaId = turmaId });
            }
        }
    }
}