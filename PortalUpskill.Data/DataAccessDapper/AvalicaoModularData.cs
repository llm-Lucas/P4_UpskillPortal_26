using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
    public class AvaliacaoModularData : IAvaliacaoModularData
    {

        private string _connectionString;

        public AvaliacaoModularData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }
        public List<AvaliacaoModular> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<AvaliacaoModular>("SELECT * FROM AvaliacaoModular").ToList();
            }
        }

        public AvaliacaoModular GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM AvalicaoModular WHERE Id = @Id";
                return connection.Query<AvaliacaoModular>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public List<Formando> GetAllByTurmaModulo(int idt, int idm)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT p.Id, p.Nome, am.ModuloId, am.NotaFinal FROM  AvaliacaoModular AS am
                                INNER JOIN Formando as f
                                ON am.FormandoId = f.PessoaId 
                                INNER JOIN Pessoa as p
                                ON p.Id = f.PessoaId
                                INNER JOIN Modulo as m
                                ON m.Id = am.ModuloId
                                INNER JOIN Turma AS t
                                ON am.CursoId = t.CursoId
                                WHERE t.Id = @Idt AND am.ModuloId = @Idm";

                return connection.Query<Formando, AvaliacaoModular, Formando>(sql,
                    (formando, am) =>
                    {
                        formando.AvaliacaoModular = am;
                        return formando;
                    }
                    , new { Idt = idt, Idm = idm }, splitOn: "ModuloId").ToList();

            }
        }

        // reset by turma here?

        public void Create(AvaliacaoModular avalicao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO AvalicaoModular (FormandoId, MediaParametros, PonderacaoParam, MediaTestesTrab, PonderacaoTestesTrab, NotaFinal, Comentarios, ModuloId, DataInicio, DataFim, Validou, FormadorId, CursoId)
                                VALUES (@FormandoId, @MediaParametros, @PonderacaoParam, @MediaTestesTrab, @PonderacaoTestesTrab, @NotaFinal, @Comentarios, @ModuloId, @DataInicio, @DataFim, @Validou, @FormadorId, @CursoId)";
                connection.Execute(sql, avalicao);
            }
        }

        public void Remove(AvaliacaoModular avalicao)
        {
            Remove(avalicao.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM AvalicaoModular WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });

            }
        }

        public void Update(AvaliacaoModular avalicao)
        {

        }

    }
}
