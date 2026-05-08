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
    public class ListaEstadosFormadorData : IListaEstadosFormadorData
    {
        private string _connectionString;

        public ListaEstadosFormadorData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<ListaEstadosFormador> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<ListaEstadosFormador>("SELECT * FROM ListaEstadosFormador ORDER BY Id").ToList();
            }
        }
        public ListaEstadosFormador GetById(int listaEstadosFormador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM ListaEstadosFormador WHERE Id = @Id";
                return connection.Query<ListaEstadosFormador>(sql, new { Id = listaEstadosFormador }).FirstOrDefault();
            }
        }

        public void Create(ListaEstadosFormador listaEstadosFormador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO ListaEstadosFormador (Id, Nome)
                                VALUES (@Id, @Nome)";
                connection.Execute(sql, listaEstadosFormador);
            }
        }

        public void Remove(ListaEstadosFormador listaEstadosFormador)
        {
        }

        public void Remove(int listaEstadosFormador)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM ListaEstadosFormador WHERE Id = @Id";
                connection.Execute(sql, new { Id = listaEstadosFormador });

            }
        }

        public void Update(ListaEstadosFormador listaEstadosFormador)
        {

        }

    }

}
