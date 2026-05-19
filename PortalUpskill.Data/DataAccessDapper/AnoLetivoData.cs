using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using PortalUpskill.Data.Models;


namespace PortalUpskill.Data.DataAccessDapper
{
    public class AnoLetivoData :IAnoLetivoData
    {
     private string _connectionString;

        public AnoLetivoData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public List<AnoLetivo> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Id, Nome FROM AnoLetivo ORDER BY Id DESC";
                return connection.Query<AnoLetivo>(sql).ToList();
            }
        }
    }
}
