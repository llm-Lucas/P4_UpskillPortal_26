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
    public class AulaData : IAulaData
    {
        private string _connectionString;

        public AulaData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<Aula> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Aula>("SELECT * FROM Aula").ToList();
            }
        }
        public Aula GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Aula WHERE Id = @Id";
                return connection.Query<Aula>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public List<Aula> GetByTurma(Turma turma) => GetByTurma(turma.Id);

        public List<Aula> GetByTurma(int TurmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT a.*, m.*, t.*, f.*, s.* FROM Aula AS a
                       LEFT JOIN Modulo AS m ON a.ModuloId = m.Id
                       LEFT JOIN Turma AS t ON a.TurmaId = t.Id
                       LEFT JOIN Formador AS f ON a.FormadorId = f.Id
                       LEFT JOIN Sala AS s ON a.SalaId = s.Id
                                WHERE TurmaId = @TurmaId";
                return connection.Query<Aula, Modulo, Turma, Formador, Sala, Aula>(sql,
            (aula, modulo, turma, formador, sala) =>
            {
                aula.Modulo = modulo;
                aula.Turma = turma;
                aula.Formador = formador;
                aula.Sala = sala;
                return aula;
            },
            new { TurmaId = TurmaId },
            splitOn: "Id") 
            .Distinct()
            .ToList();
            }
        }

        public List<Aula> GetByTurmaFormador(int TurmaId, int FormadorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT a.*, m.*, t.*, f.*, s.* FROM Aula AS a
                       LEFT JOIN Modulo AS m ON a.ModuloId = m.Id
                       LEFT JOIN Turma AS t ON a.TurmaId = t.Id
                       LEFT JOIN Formador AS f ON a.FormadorId = f.Id
                       LEFT JOIN Sala AS s ON a.SalaId = s.Id
                                WHERE a.TurmaId = @TurmaId AND a.FormadorId = @FormadorId";
                return connection.Query<Aula, Modulo, Turma, Formador, Sala, Aula>(sql,
             (aula, modulo, turma, formador, sala) =>
             {
                 aula.Modulo = modulo;
                 aula.Turma = turma;
                 aula.Formador = formador;
                 aula.Sala = sala;
                 return aula;
             },
             new { TurmaId = TurmaId },
             splitOn: "Id")
             .ToList();
            }
        }

        public void Create(Aula aula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Aula (Sumario, DuracaoHoras, HoraInicio, HoraFim, SalaId, TurmaId, FormadorId, ModuloId)
                                VALUES (@Sumario, @DuracaoHoras, @HoraInicio, @HoraFim, @SalaId, @TurmaId, @FormadorId, @ModuloId)";
                connection.Execute(sql, aula);
            }
        }

        public void Remove(Aula aula)
        {
            Remove(aula.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM AULA WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });

            }
        }

        public void Update(Aula aula)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Aula SET Sumario = @Sumario
                                WHERE Id = @Id";
                connection.Execute(sql, new { Id = aula.Id, Sumario = aula.Sumario });

            }
        }
    }
}
