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
    public class ModuloData : IModuloData
    {
        private string _connectionString;

        public ModuloData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Modulo> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Modulo>("SELECT * FROM Modulo").ToList();
            }
        }

        public List<Modulo> GetByIdFormadorIdTurma(int idf, int idt)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT fm.FormadorId, md.*  FROM FormadorModulo AS fm 

                                        LEFT JOIN Formador As f
                                        ON f.PessoaId = fm.FormadorId

                                        LEFT JOIN Modulo AS md
                                        ON md.Id = fm.ModuloId

                                        LEFT JOIN FormadorModuloTurma AS fmd
                                        ON fmd.FormadorModuloId = fm.Id

                                        INNER JOIN Turma AS t
                                        ON t.Id = fmd.TurmaId

                                        WHERE FormadorId=@idf AND t.Id=@idt";

                return connection.Query<Modulo>(sql, new { idf = idf, idt = idt }).ToList();
            }
        }

        public List<Modulo> GetModulosComFormadorByTurma(int idTurma)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT m.*, p.Id, p.Nome FROM FormadorModulo AS fm 
                                LEFT JOIN Formador As f
                                    ON f.PessoaId = fm.FormadorId
								LEFT JOIN Pessoa AS p
								    ON p.Id = f.PessoaId
                                LEFT JOIN Modulo AS m
                                    ON m.Id = fm.ModuloId
                                LEFT JOIN FormadorModuloTurma AS fmd
                                    ON fmd.FormadorModuloId = fm.Id
                                INNER JOIN Turma AS t
                                    ON t.Id = fmd.TurmaId
                                WHERE t.Id = @TurmaId";

                return connection.Query<Modulo, Formador, Modulo>(sql, (modulo, formador) =>
                {
                    modulo.Formador = formador;
                    return modulo;
                }, new { TurmaId = idTurma }, splitOn: "Id").ToList();
            }
        }

        public Modulo GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Modulo WHERE Id = @Id";
                return connection.Query<Modulo>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public Modulo GetByIdWithFormador(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var lookup = new Dictionary<int, Modulo>();

                string sql = @"SELECT m.*, p.Id, p.Nome FROM Modulo AS m
                                LEFT JOIN FormadorModulo AS fm
                                    ON m.Id = fm.ModuloId
                                LEFT JOIN Formador AS f
                                    ON fm.FormadorId = f.PessoaId
                                LEFT JOIN Pessoa AS p
                                    ON f.PessoaId = p.Id
                                WHERE m.Id = @Id";

                return connection.Query<Modulo, Formador, Modulo>(
                    sql, (modulo, formador) =>
                    {
                        Modulo moduloEntry;

                        if (!lookup.TryGetValue(modulo.Id, out moduloEntry))
                        {
                            moduloEntry = modulo;
                            moduloEntry.Formadores = new List<Formador>();
                            lookup.Add(moduloEntry.Id, moduloEntry);
                        }
                        if (formador != null)
                        {
                            moduloEntry.Formadores.Add(formador);
                        }
                        return moduloEntry;
                    }, new { Id = id }, splitOn: "Id").FirstOrDefault();
            }
        }

        /// <summary>
        /// Retorna a combinação de que formadores estão a lecionar que módulos para uma turma
        /// </summary>
        /// <returns>
        ///     Dictionary<int, int> em que as chaves são os Id dos módulos e os valores são os formadores.
        ///     Se não existir formador para um dado módulo o valor para essa chave será zero.
        /// </returns>
        public Dictionary<int, ModuloFormadorHora> GetModuloFormadorByTurma(Turma turma)
        {
            var modulos = GetModulosByCurso((int)turma.CursoId);
            Dictionary<int, ModuloFormadorHora> moduloFormador = new Dictionary<int, ModuloFormadorHora>();

            foreach (var modulo in modulos)
            {
                moduloFormador.Add(modulo.Id, new ModuloFormadorHora { FormadorId = 0, Horas = modulo.Horas });
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT ModuloId, FormadorId, fmt.Horas FROM FormadorModuloTurma as fmt
                                INNER JOIN FormadorModulo AS fm
	                                on fmt.FormadorModuloId = fm.Id
                                WHERE TurmaId = @TurmaId";

                var result = connection.Query<int, int, decimal?, Tuple<int, int, double>>(
                    sql,
                    (moduloId, formadorId, horas) =>
                    {
                        return new Tuple<int, int, double>(moduloId, formadorId, (double)(horas ?? 0));
                    },
                    new { TurmaId = turma.Id }, splitOn: "FormadorId, Horas");

                foreach (var row in result)
                {
                    if (moduloFormador.ContainsKey(row.Item1))
                    {
                        moduloFormador[row.Item1].FormadorId = row.Item2;
                        moduloFormador[row.Item1].Horas = row.Item3;
                    }
                }
            }

            return moduloFormador;
        }

        public List<Modulo> GetModulosByCurso(int cursoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var lookup = new Dictionary<int, Modulo>();

                string sql = @"SELECT DISTINCT m.*, f.*, p.*, cm.Horas FROM Modulo AS m   
                                LEFT JOIN CursoModulo AS cm
                                ON cm.ModuloId = m.Id
                                LEFT JOIN FormadorModulo AS FM
                                ON m.Id = fm.ModuloId
                                LEFT JOIN Formador AS f
                                ON fm.FormadorId = f.PessoaId
                                LEFT JOIN Pessoa AS p
                                ON f.PessoaId = p.Id
                                WHERE cm.CursoId = @CursoId";

                return connection.Query<Modulo, Formador, Modulo>(
                    sql, (modulo, formador) =>
                    {
                        Modulo moduloEntry;

                        if (!lookup.TryGetValue(modulo.Id, out moduloEntry))
                        {
                            moduloEntry = modulo;
                            moduloEntry.Formadores = new List<Formador>();
                            lookup.Add(moduloEntry.Id, moduloEntry);
                        }
                        if (formador != null)
                        {
                            moduloEntry.Formadores.Add(formador);
                        }
                        return moduloEntry;
                    }, new { @CursoId = cursoId }, splitOn: "PessoaId")
                    .Distinct()
                    .ToList();
            }
        }

        public void Create(Modulo modulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Modulo (Nome, Horas, Objetivos, ConteudosProgramaticos, SistemaAvaliacao, Bibliografia, SoftwareHardware)
                               VALUES(@Nome, @Horas, @Objetivos, @ConteudosProgramaticos, @SistemaAvaliacao, @Bibliografia, @SoftwareHardware)";
                connection.Execute(sql, modulo);
            }
        }

        public void Remove(Modulo modulo)
        {
            Remove(modulo.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Modulo WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });

            }
        }

        public void Update(Modulo modulo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Modulo
                               SET Nome = @Nome, Horas = @Horas, Objetivos = @Objetivos, ConteudosProgramaticos = @ConteudosProgramaticos, SistemaAvaliacao = @SistemaAvaliacao, Bibliografia = @Bibliografia, SoftwareHardware = @SoftwareHardware
                               WHERE Id = @Id";
                connection.Execute(sql, modulo);
            }
        }

        public void RemoveFormadores(Modulo modulo, List<Formador> formadoresToRemove)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM FormadorModulo
							    WHERE FormadorId = @FormadorId AND ModuloId = @ModuloId";

                foreach (var formador in formadoresToRemove)
                {
                    connection.Execute(sql, new { FormadorId = formador.Id, ModuloId = modulo.Id });
                }
            }
        }

        public void InsertFormadores(Modulo modulo, List<Formador> formadoresToInsert)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO FormadorModulo (FormadorId, ModuloId)
                                VALUES (@FormadorId, @ModuloId)";

                foreach (var formador in formadoresToInsert)
                {
                    connection.Execute(sql, new { FormadorId = formador.Id, ModuloId = modulo.Id });
                }
            }

        }

    }
}