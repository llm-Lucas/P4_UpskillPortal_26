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
    public class EstadosFormadorData : IEstadosFormadorData
    {

        private string _connectionString;

        public EstadosFormadorData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<EstadosFormador> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<EstadosFormador>("SELECT * FROM EstadosFormador ORDER BY Id").ToList();
            }
        }
        public EstadosFormador GetById(int estadosFormador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM EstadosFormador WHERE Id = @Id";
                return connection.Query<EstadosFormador>(sql, new { Id = estadosFormador }).FirstOrDefault();
            }
        }

        public void Create(EstadosFormador estadosFormador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO EstadosFormador (Id, ListaEstadoId, Data, Observacoes)
                                VALUES (@Id, @ListaEstadoId, @Data, @Observacoes)";
                connection.Execute(sql, estadosFormador);
            }
        }

        public void Remove(EstadosFormador estadosFormador)
        {
        }

        public void Remove(int estadosFormador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM EstadosFormador WHERE Id = @Id";
                connection.Execute(sql, new { Id = estadosFormador });

            }
        }

        public void Update(EstadosFormador estadosFormador)
        {

        }
    }
}

