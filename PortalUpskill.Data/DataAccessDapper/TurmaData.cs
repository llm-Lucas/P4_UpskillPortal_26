using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class TurmaData : ITurmaData
    {
        private string _connectionString;

        public TurmaData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Turma> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var lookup = new Dictionary<int, Turma>();

                string sql = @"SELECT * FROM Turma AS t
                                LEFT JOIN TurmaFormando AS tf
	                                ON tf.TurmaId = t.Id
                                LEFT JOIN Formando AS f
	                                ON f.PessoaId = tf.FormandoId
                                LEFT JOIN Pessoa as p
	                                ON p.Id = f.PessoaId
                                LEFT JOIN Curso AS c
	                                ON t.CursoId = c.Id";

                return connection.Query<Turma, Formando, Curso, Turma>(
                sql, (turma, formando, curso) =>
                {
                    Turma turmaEntry;

                    if (!lookup.TryGetValue(turma.Id, out turmaEntry))
                    {
                        turmaEntry = turma;
                        turmaEntry.Formandos = new List<Formando>();
                        lookup.Add(turmaEntry.Id, turmaEntry);
                    }
                    if (formando.Id != 0)
                    {
                        turmaEntry.Formandos.Add(formando);
                    }
                    if (curso != null)
                    {
                        turmaEntry.Curso = curso;
                    }
                    return turmaEntry;
                }, splitOn: "PessoaId, Id").Distinct().ToList();
            }
        }

        public Turma GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var lookup = new Dictionary<int, Turma>();

                string sql = @"SELECT * FROM Turma AS t
                                LEFT JOIN TurmaFormando AS tf
	                                ON tf.TurmaId = t.Id
                                LEFT JOIN Formando AS f
	                                ON f.PessoaId = tf.FormandoId
                                LEFT JOIN Pessoa as p
	                                ON p.Id = f.PessoaId
                                LEFT JOIN Curso AS c
	                                ON t.CursoId = c.Id
                                WHERE t.Id = @Id";

                return connection.Query<Turma, Formando, Curso, Turma>(
                sql, (turma, formando, curso) =>
                {
                    Turma turmaEntry;

                    if (!lookup.TryGetValue(turma.Id, out turmaEntry))
                    {
                        turmaEntry = turma;
                        turmaEntry.Formandos= new List<Formando>();
                        lookup.Add(turmaEntry.Id, turmaEntry);
                    }
                    if (formando.Id != 0)
                    {
                        turmaEntry.Formandos.Add(formando);
                    }
                    if (curso != null)
                    {
                        turmaEntry.Curso = curso;
                    }
                    return turmaEntry;
                },
                 new { Id = id },
                 splitOn: "PessoaId, Id")
                     .Distinct()
                     .FirstOrDefault();
            }
        }
       
        public List<Turma> GetByCurso(int cursoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Turma WHERE CursoId = @CursoId";
                return connection.Query<Turma>(sql, new { CursoId = cursoId }).ToList();
            }
        }

        public List<Formando> GetByTurma(int turmaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM TurmaFormando WHERE TurmaId = @TurmaId";
                return connection.Query<Formando>(sql, new { TurmaId = turmaId }).ToList();
            }
        }

        public void Create(Turma turma)
        {
            CreateReturnId(turma);
        }

        public int CreateReturnId(Turma turma)
        {
            var idturma = 0;
            string sql = @"INSERT INTO Turma (Nome, DataInicioCurso, DataFimCurso, CursoId,
                                                HorarioSincronoInicio, HorarioSincronoFim,
                                                HorarioAssincronoInicio, HorarioAssincronoFim, TempoLectivo)
                                    VALUES (@Nome, @DataInicioCurso, @DataFimCurso, @CursoId,
                                                @HorarioSincronoInicio, @HorarioSincronoFim,
                                                @HorarioAssincronoInicio, @HorarioAssincronoFim, @TempoLectivo)
                                    SELECT CAST(SCOPE_IDENTITY() as int);";
            if (turma.Formandos.Count() == 0)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    idturma = (int)connection.ExecuteScalar(sql, turma);
                }
            }
            else
            {
                using (var connection = new SqlConnection(_connectionString))
                {

                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            idturma =(int)connection.ExecuteScalar(sql, turma, transaction: transaction);

                            foreach (var formando in turma.Formandos)
                            {
                                sql = @"INSERT INTO TurmaFormando (TurmaId, FormandoId)
                                        VALUES (" + idturma + ", " + formando.Id + ")";
                                connection.Execute(sql, transaction: transaction);
                            }

                            transaction.Commit();
                        }
                        catch { connection.Close(); }
                    }
                }
            }
            return idturma;
        }

        public int CreateReturnId(Turma turma, Dictionary<int, ModuloFormadorHora> ModFor)
        {
            int idturma = 0;
            int idformadormodulo = 0;
            int idmodulo = 0;
            int idformador = 0;
            double horas;

            string sql = @"INSERT INTO Turma (Nome, DataInicioCurso, DataFimCurso, CursoId,
                                        HorarioSincronoInicio, HorarioSincronoFim,
                                        HorarioAssincronoInicio, HorarioAssincronoFim, TempoLectivo)
                            VALUES (@Nome, @DataInicioCurso, @DataFimCurso, @CursoId,
                                        @HorarioSincronoInicio, @HorarioSincronoFim,
                                        @HorarioAssincronoInicio, @HorarioAssincronoFim, @TempoLectivo)
                            SELECT CAST(SCOPE_IDENTITY() as int);";

            if (turma.Formandos.Count() == 0 && ModFor.Select(i => i.Value.FormadorId).Where(i => i != 0).Count() == 0)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    idturma = (int)connection.ExecuteScalar(sql, turma);
                }
            }
            else
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            idturma = (int)connection.ExecuteScalar(sql, turma, transaction: transaction);

                            if (turma.Formandos.Count() != 0)
                            {
                                foreach (var formando in turma.Formandos)
                                {
                                    sql = @"INSERT INTO TurmaFormando (TurmaId, FormandoId)
                                        VALUES (" + idturma + ", " + formando.Id + ")";
                                    connection.Execute(sql, transaction: transaction);
                                }
                            }
                            foreach(var item in ModFor)
                            {
                                idmodulo = item.Key;
                                idformador = item.Value.FormadorId;
                                horas = item.Value.Horas;

                                if(idformador != 0)
                                {
                                    sql = @"SELECT Id FROM FormadorModulo
                                        WHERE ModuloId =" + idmodulo + "AND FormadorId =" + idformador;

                                    idformadormodulo = (int)connection.ExecuteScalar(sql, transaction: transaction);

                                    sql = @"INSERT INTO FormadorModuloTurma (TurmaId, FormadorModuloId, Horas)
			                            VALUES (" + idturma + ",  " + idformadormodulo + ", " + horas + ")";
                                    connection.Execute(sql, transaction: transaction);
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            connection.Close();
                            throw;
                        }
                    }
                }
            }
            return idturma;
        }

        public void Remove(Turma turma)
        {
            Remove(turma.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Turma  WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });

                sql = @"DELETE FROM TurmaFormando Where TurmaId = @Id";
                connection.Execute(sql, new { Id = id });
            }

        }

        public void Update(Turma turma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Turma
                               SET Nome = @Nome, DataInicioCurso = @DataInicioCurso, DataFimCurso = @DataFimCurso, CursoId = @CursoId,
                                HorarioSincronoInicio = @HorarioSincronoInicio, HorarioSincronoFim = @HorarioSincronoFim,
                                HorarioAssincronoInicio = @HorarioAssincronoInicio, HorarioAssincronoFim = @HorarioAssincronoFim, TempoLectivo = @TempoLectivo
                                WHERE Id = @Id";
                connection.Execute(sql, turma);
            }
        }

        public void Update(Turma turma, Dictionary<int, ModuloFormadorHora> ModFor)
        {
            int idformadormodulo = 0;
            int idmodulo = 0;
            int idformador = 0;
            double horas;

            string sql = @"UPDATE Turma
                               SET Nome = @Nome, DataInicioCurso = @DataInicioCurso, DataFimCurso = @DataFimCurso, CursoId = @CursoId,
                                HorarioSincronoInicio = @HorarioSincronoInicio, HorarioSincronoFim = @HorarioSincronoFim,
                                HorarioAssincronoInicio = @HorarioAssincronoInicio, HorarioAssincronoFim = @HorarioAssincronoFim, TempoLectivo = @TempoLectivo
                                WHERE Id = @Id";
            if (ModFor.Select(i => i.Value.FormadorId).Where(i => i != 0).Count() == 0)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Execute(sql, turma);
                }
            }
            else
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            connection.Execute(sql, turma, transaction: transaction);

                            sql = @"DELETE FROM FormadorModuloTurma WHERE TurmaId =" + turma.Id;
                            connection.Execute(sql, transaction: transaction);

                            foreach(var item in ModFor)
                            {
                                idmodulo = item.Key;
                                idformador = item.Value.FormadorId;
                                horas = item.Value.Horas;
                                if (idformador != 0)
                                {
                                    sql = @"SELECT Id FROM FormadorModulo
                                        WHERE ModuloId =" + idmodulo + "AND FormadorId =" + idformador;

                                    idformadormodulo = (int)connection.ExecuteScalar(sql, transaction: transaction);

                                    sql = @"INSERT INTO FormadorModuloTurma (TurmaId, FormadorModuloId, Horas)
			                            VALUES (" + turma.Id + ",  " + idformadormodulo + ", " + horas + ")";
                                    connection.Execute(sql, transaction: transaction);
                                }
                            }
                            transaction.Commit();
                        }
                        catch
                        {
                            connection.Close();
                            throw;
                        }
                    }
                }
            }

        }

        public void AddToCurso(Curso curso, List<Turma> turmasToAdd)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Turma
                               SET CursoId = @CursoId
                                WHERE Id = @Id";
                foreach (var turma in turmasToAdd)
                {
                    connection.Execute(sql, new { Id = turma.Id, CursoId = curso.Id });
                }
            }
        }

        public void RemoveFromCurso(Curso curso, List<Turma> turmasToRemove)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Turma
                               SET CursoId = NULL
                                WHERE Id = @Id";
                foreach (var turma in turmasToRemove)
                {
                    connection.Execute(sql, turma);
                }
            }
        }

        public void RemoveFormandos(Turma turma, List<Formando> formandosToRemove)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                string sql = "DELETE FROM TurmaFormando Where FormandoId = @FormandoId AND TurmaId = @TurmaId";
                foreach (var formando in formandosToRemove)
                {
                    connection.Execute(sql, new { FormandoId = formando.Id, TurmaId = turma.Id });
                }
            }
        }

        public void InsertFormandos(Turma turma, List<Formando> formandosToInsert)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                string sql = "INSERT INTO TurmaFormando (FormandoId, TurmaId) VALUES (@FormandoId, @TurmaId)";
                foreach (var formando in formandosToInsert)
                {
                    connection.Execute(sql, new { FormandoId = formando.Id, TurmaId = turma.Id });
                }
            }
        }

       
    }
}
