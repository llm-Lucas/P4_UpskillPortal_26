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
    public class ListaEstadosFormandoData : IListaEstadosFormandoData
    {
        private string _connectionString;

        public ListaEstadosFormandoData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<ListaEstadosFormando> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<ListaEstadosFormando>("SELECT * FROM ListaEstadosFormando ORDER BY Id").ToList();
            }
        }
        public ListaEstadosFormando GetById(int listaEstadosFormando)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM ListaEstadosFormando WHERE Id = @Id";
                return connection.Query<ListaEstadosFormando>(sql, new { Id = listaEstadosFormando }).FirstOrDefault();
            }
        }

        public void Create(ListaEstadosFormando listaEstadosFormando)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO ListaEstadosFormando (Id, Nome)
                                VALUES (@Id, @Nome)";
                connection.Execute(sql, listaEstadosFormando);
            }
        }

        public void Remove(ListaEstadosFormando listaEstadosFormando)
        {
        }

        public void Remove(int listaEstadosFormando)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM ListaEstadosFormando WHERE Id = @Id";
                connection.Execute(sql, new { Id = listaEstadosFormando });

            }
        }

        public void Update(ListaEstadosFormando listaEstadosFormando)
        {

        }

    }
}
