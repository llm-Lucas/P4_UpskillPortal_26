using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class CursoData : ICursoData
    {
        private string _connectionString;

        public CursoData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<Curso> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Curso>("SELECT * FROM Curso").ToList();
            }
        }

        public List<Curso> GetAllWithModulos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Curso>("SELECT * FROM Curso WHERE DuracaoHoras != 0.00").ToList();
            }
        }

        public Curso GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                
                var lookup = new Dictionary<int, Curso>();

                string sql = @"SELECT DISTINCT c.*, cm.Horas, cm.Ordem, m.*, p.* FROM Curso AS c
                                LEFT JOIN CursoModulo AS cm
	                                ON cm.CursoId = c.Id
                                LEFT JOIN Modulo AS m
	                                ON cm.ModuloId = m.Id
                                LEFT JOIN CursoCoordenador as cc
	                                ON cc.CursoId = c.Id
                                LEFT JOIN Pessoal as pl
	                                ON cc.PessoalId = pl.PessoaId
                                LEFT JOIN Pessoa as p
	                                ON p.Id = pl.PessoaId
                                WHERE c.Id = @Id
								ORDER BY cm.Ordem;";
                
                
                return connection.Query<Curso, decimal?, Modulo, Formador, Curso>(
                sql,
                (curso, horas, modulo, pessoa) =>
                {
                    Curso cursoEntry;

                    if (!lookup.TryGetValue(curso.Id, out cursoEntry))
                    {
                        cursoEntry = curso;
                        cursoEntry.Modulos = new Dictionary<Modulo, double>();
                        cursoEntry.Coordenadores = new List<Formador>();
                        lookup.Add(cursoEntry.Id, cursoEntry);
                    }
                    if (modulo != null && horas != null && modulo.Id != 0 && cursoEntry.Modulos.Keys.FirstOrDefault(m => m.Id == modulo.Id) == null)
                    {
                        cursoEntry.Modulos.Add(modulo, (double)horas);
                    }
                    
                    if (pessoa != null && pessoa.Id != 0 && cursoEntry.Coordenadores.FirstOrDefault(p => p.Id == pessoa.Id) == null)
                    {
                        cursoEntry.Coordenadores.Add(pessoa);
                    }

                    return cursoEntry;
                },
                 new { Id = id },
                 splitOn: "Horas, Id, Id")
                     .Distinct()
                     .FirstOrDefault();
            }
        }

        public void Create(Curso curso)
        {
            CreateReturnId(curso);
        }

        public int CreateReturnId(Curso curso)
        {
            var idCurso = 0;
            string sql = @"INSERT INTO Curso (Nome, DuracaoHoras, Objetivos)
                            VALUES (@Nome, @DuracaoHoras, @Objetivos)
                            SELECT CAST(SCOPE_IDENTITY() as int)";
            if (curso.Modulos.Count() == 0)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    idCurso = (int)connection.ExecuteScalar(sql, curso);
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
                            idCurso = (int)connection.ExecuteScalar(sql, curso, transaction: transaction);
                            int ordem = 1;
                            foreach (var moduloHora in curso.Modulos)
                            {
                                sql = @"INSERT INTO CursoModulo (CursoId, ModuloId, Horas, Ordem)
                                        VALUES (@CursoId, @ModuloId, @Horas, @Ordem)";
                                connection.Execute(sql, new { CursoId = idCurso, ModuloId = moduloHora.Key.Id, Horas = moduloHora.Value, Ordem = ordem}, transaction: transaction);
                                ordem++;
                            }
                            transaction.Commit();
                        }
                        catch { connection.Close(); }
                    }

                }
            }
            return idCurso;
        }

        public void Remove(Curso curso)
        {
            Remove(curso.Id);
        }

        public void Remove(int id)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Curso WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public bool RemoveWithReturn(int id)
        {
            bool returnValue = false;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string sql = @"DELETE FROM Curso WHERE Id = @Id";
                    connection.Execute(sql, new { Id = id });

                }
                returnValue = true;
            }
            catch { }
            return returnValue;
        }

        public void Update(Curso curso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Curso 
                               SET Nome = @Nome, DuracaoHoras = @DuracaoHoras, Objetivos = @Objetivos
                               WHERE Id = @Id";
                connection.Execute(sql, curso);
            }
        }

        public void InsertCoordenadores(int cursoId, List<Formador> Coordenadores)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO CursoCoordenador (CursoId, PessoalId) VALUES (@CursoId, @PessoalId)";

                foreach (var coordenador in Coordenadores)
                {
                    connection.Execute(sql, new { CursoId = cursoId, PessoalId = coordenador.Id });
                }
            }
        }

        public void RemoveCoordenadores(int cursoId, List<Formador> coordenadoresToRemove)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM CursoCoordenador
                                WHERE CursoId = @CursoId AND PessoalId = @PessoalId";

                foreach (var coordenador in coordenadoresToRemove)
                {
                    connection.Execute(sql, new { CursoId = cursoId, PessoalId = coordenador.Id });
                }
            }
        }

        public void RemoveModulos(Curso curso, List<Modulo> modulosToRemove)
        {
            using (var connection = new SqlConnection(_connectionString))
            {                
                string sql = "DELETE FROM CursoModulo Where CursoId = @CursoId AND ModuloId = @ModuloId";
                foreach(var modulo in modulosToRemove)
                {
                    connection.Execute(sql, new { CursoId = curso.Id, ModuloId = modulo.Id });
                }
            }
        }
        public void RemoveModulos(Curso curso, Dictionary<Modulo, double> modulosHoraToRemove)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                string sql = "DELETE FROM CursoModulo Where CursoId = @CursoId AND ModuloId = @ModuloId";
                foreach (var mh in modulosHoraToRemove)
                {
                    connection.Execute(sql, new { CursoId = curso.Id, ModuloId = mh.Key.Id });
                }
            }
        }

        public void InsertModulos(Curso curso, List<Modulo> modulosToInsert)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                string sql = "INSERT INTO CursoModulo (CursoId, ModuloId) VALUES (@CursoId, @ModuloId)";
                foreach (var modulo in modulosToInsert)
                {
                    connection.Execute(sql, new { CursoId = curso.Id, ModuloId = modulo.Id });
                }
            }
        }
        public void InsertModulos(Curso curso, Dictionary<Modulo, double> modulosHoraToInsert)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                string sql = "INSERT INTO CursoModulo (CursoId, ModuloId, Horas) VALUES (@CursoId, @ModuloId, @Horas)";
                foreach (var mh in modulosHoraToInsert)
                {
                    connection.Execute(sql, new { CursoId = curso.Id, ModuloId = mh.Key.Id, Horas = mh.Value });
                }
            }
        }

        public void UpdateDuracaoModulos(Curso curso, Dictionary<Modulo, double> modulos)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE CursoModulo
                                SET Horas = @Horas
                                WHERE CursoId = @CursoId AND ModuloId = @ModuloId";

                foreach(var modulo in modulos)
                {
                    connection.Execute(sql, new { CursoId = curso.Id, ModuloId = modulo.Key.Id, Horas = modulo.Value });
                }
            }
        }

        public void UpdateOrdemModulos(Curso curso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE CursoModulo
                                SET Ordem = @Ordem
                                WHERE CursoId = @CursoId AND ModuloId = @ModuloId";

                int ordem = 1;

                foreach (var modulo in curso.Modulos.Keys)
                {
                    connection.Execute(sql, new { CursoId = curso.Id, ModuloId = modulo.Id, Ordem = ordem });
                    ordem++;
                }
            }

        }
    }
}
