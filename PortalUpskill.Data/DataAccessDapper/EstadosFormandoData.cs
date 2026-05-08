using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class EstadosFormandoData : IEstadosFormandoData
    {
        private string _connectionString;

        public EstadosFormandoData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<EstadosFormando> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<EstadosFormando>("SELECT * FROM EstadosFormando ORDER BY Id").ToList();
            }
        }
        public EstadosFormando GetById(int estadosFormando)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM EstadosFormando WHERE Id = @Id";
                return connection.Query<EstadosFormando>(sql, new { Id = estadosFormando }).FirstOrDefault();
            }
        }

        public void Create(EstadosFormando estadosFormando)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO EstadosFormando (Id, ListaEstadoId, Data, Observacoes)
                                VALUES (@Id, @ListaEstadoId, @Data, @Observacoes)";
                connection.Execute(sql, estadosFormando);
            }
        }

        public void Remove(EstadosFormando estadosFormando)
        {
        }

        public void Remove(int estadosFormando)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM EstadosFormando WHERE Id = @Id";
                connection.Execute(sql, new { Id = estadosFormando });

            }
        }

        public void Update(EstadosFormando estadosFormando)
        {

        }
        
    }
}
