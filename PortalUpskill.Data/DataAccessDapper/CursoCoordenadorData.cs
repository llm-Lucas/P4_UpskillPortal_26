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
    }
}