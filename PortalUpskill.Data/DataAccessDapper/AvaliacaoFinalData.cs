using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class AvaliacaoFinalData : IAvaliacaoFinalData
    {
        private string _connectionString;

        public AvaliacaoFinalData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<AvaliacaoFinal> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<AvaliacaoFinal>("SELECT * FROM AvaliacaoFinal").ToList();
            }
        }

        public AvaliacaoFinal GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM AvaliacaoFinal WHERE Id = @Id";
                return connection.Query<AvaliacaoFinal>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public void Create(AvaliacaoFinal avalicaofinal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO AvaliacaoFinal (FormandoId,  CursoId, DataInicio, DataFim,  NotaFinal, Validou)
                                VALUES (@FormandoId,  @CursoId, @DataInicio, @DataFim,  @NotaFinal, @Validou)";
                connection.Execute(sql, avalicaofinal);
            }
        }

        public void Remove(AvaliacaoFinal avalicaofinal)
        {
            Remove(avalicaofinal.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM AvaliacaoFinal WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });

            }
        }
            public void Update(AvaliacaoFinal avalicaofinal)
            {
               
            }


        }
    }
