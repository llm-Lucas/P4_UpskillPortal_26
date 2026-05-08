using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class FuncoesData : IFuncoesData
    {

        private string _connectionString;

        public FuncoesData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public void Create(Funcoes entity)
        {
            throw new NotImplementedException();
        }

        public List<Funcoes> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcoes>("SELECT * FROM Funcoes").ToList();
            }
        }

        public Funcoes GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Funcoes entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Funcoes entity)
        {
            throw new NotImplementedException();
        }
    }
}
