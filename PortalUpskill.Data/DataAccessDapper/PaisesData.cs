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
    public class PaisesData : IPaisesData
    {
        private string _connectionString;

        public PaisesData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<Paises> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Paises>("SELECT * FROM Paises").ToList();
            }
        }

        public Paises GetById(int numcode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Paises WHERE numcode = @numcode";
                return connection.Query<Paises>(sql, new { numcode = numcode }).FirstOrDefault();
            }
        }

        public Paises GetById(string iso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Paises WHERE iso = @iso";
                return connection.Query<Paises>(sql, new { iso = iso }).FirstOrDefault();
            }
        }

        public void Create(Paises paises)
        {

        }

        public void Remove(Paises paises)
        {

        }

        public void Remove(int iso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM Paises WHERE iso = @iso";
                connection.Execute(sql, new { iso = iso });

            }
        }

        public void Update(Paises paises)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

            }
        }
    }
}
