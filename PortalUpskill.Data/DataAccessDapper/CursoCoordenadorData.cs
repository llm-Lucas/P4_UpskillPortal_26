using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using PortalUpskill.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class CursoCoordenadorData : ICursoCoordenadorData
    {
        private string _connectionString;

        public CursoCoordenadorData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<Pessoa> GetCoordenadoresByCurso(int cursoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT p.* FROM CursoCoordenador cc
                               INNER JOIN Pessoa p ON p.Id = cc.PessoalId
                               WHERE cc.CursoId = @CursoId";
                return connection.Query<Pessoa>(sql, new { CursoId = cursoId }).ToList();
            }
        }
        //Associar Coordenador a um Curso
        public List<Curso> GetCursosByCoordenador(int coordenadorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT c.* FROM CursoCoordenador cc
                       INNER JOIN Curso c ON c.Id = cc.CursoId
                       WHERE cc.PessoalId = @CoordenadorId";
                return connection.Query<Curso>(sql, new { CoordenadorId = coordenadorId }).ToList();
            }
        }

        public void InsertCursoCoordenador(int cursoId, int coordenadorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO CursoCoordenador (CursoId, PessoalId) VALUES (@CursoId, @PessoalId)";
                connection.Execute(sql, new { CursoId = cursoId, PessoalId = coordenadorId });
            }
        }

        public void RemoveCursoCoordenador(int cursoId, int coordenadorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM CursoCoordenador WHERE CursoId = @CursoId AND PessoalId = @PessoalId";
                connection.Execute(sql, new { CursoId = cursoId, PessoalId = coordenadorId });
            }
        }
    }
}