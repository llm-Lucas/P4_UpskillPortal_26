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
                string sql = @"SELECT * FROM Aula AS a
                                INNER JOIN Formador as f 
                                    ON a.FormadorId = f.PessoaId
								INNER JOIN Pessoa as p
									on f.PessoaId = p.Id
                                WHERE TurmaId = @TurmaId";
                return connection.Query<Aula, Formador, Aula>(sql,
                    (aula, formador) =>
                    {
                        aula.Formador = formador;
                        return aula;
                    }
                    ,new { TurmaId = TurmaId }).Distinct()
                    .ToList();
            }
        }

        public List<Aula> GetByTurmaFormador(int TurmaId, int FormadorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT * FROM Aula AS a
                                INNER JOIN Formador as f 
                                    ON a.FormadorId = f.PessoaId
								INNER JOIN Pessoa as p
									on f.PessoaId = p.Id
                                WHERE a.TurmaId = @TurmaId AND a.FormadorId = @FormadorId";
                return connection.Query<Aula, Formador, Aula>(sql,
                    (aula, formador) =>
                    {
                        aula.Formador = formador;
                        return aula;
                    }
                    , new { TurmaId = TurmaId, FormadorId = FormadorId }).Distinct()
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
