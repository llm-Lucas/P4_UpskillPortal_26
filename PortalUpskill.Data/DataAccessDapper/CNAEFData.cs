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
    public class CNAEFData : ICNAEFData
    {
        private string _connectionString;

        public CNAEFData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<CNAEF> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CNAEF>("SELECT * FROM CNAEF ORDER BY CodigoCNAEF").ToList();
            }
        }
        public CNAEF GetById(int cnaef)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM CNAEF WHERE CodigoCNAEF = @CodigoCNAEF";
                return connection.Query<CNAEF>(sql, new { CodigoCNAEF = cnaef }).FirstOrDefault();
            }
        }

        public void Create(CNAEF cnaef)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO CNAEF (AreaFormacao, CodigoCNAEF)
                                VALUES (@AreaFormacao, @CodigoCNAEF)";
                connection.Execute(sql, cnaef);
            }
        }

        public void Remove(CNAEF cnaef)
        {
        }

        public void Remove(int cnaef)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM CNAEF WHERE CodigoCNAEF = @CodigoCNAEF";
                connection.Execute(sql, new { CodigoCNAEF = cnaef });

            }
        }

        public void Update(CNAEF cnaef)
        {

        }
    }
}
