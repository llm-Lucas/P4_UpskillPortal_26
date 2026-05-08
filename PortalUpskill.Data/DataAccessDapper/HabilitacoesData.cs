using Dapper;
using Microsoft.Extensions.Configuration;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
	public class HabilitacoesData : IHabilitacoesData
	{
		private string _connectionString;

		public HabilitacoesData(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("Default");
		}
		public List<Habilitacoes> GetAll()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				return connection.Query<Habilitacoes>("SELECT * FROM Habilitacoes").ToList();
			}
		}
		public Habilitacoes GetById(int codigo)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = "SELECT * FROM Habilitacoes WHERE Codigo = @Codigo";
				return connection.Query<Habilitacoes>(sql, new { Codigo = codigo }).FirstOrDefault();
			}
		}

		public void Create(Habilitacoes habilitacoes)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"INSERT INTO Habilitacoes (Codigo, HabilitacoesLiterarias)
                                VALUES (@Codigo, @HabilitacoesLiterarias)";
				connection.Execute(sql, habilitacoes);
			}
		}

		public void Remove(Habilitacoes habilitacoes)
		{
			Remove(habilitacoes.Codigo);
		}

		public void Remove(int codigo)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"DELETE FROM Habilitacoes WHERE Codigo = @Codigo";
				connection.Execute(sql, new { Codigo = codigo });

			}
		}

		public void Update(Habilitacoes habilitacoes)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				string sql = @"UPDATE Habilitacoes 
                               SET HabilitacoesLiterarias = @HabilitacoesLiterarias
                               WHERE Codigo = @Codigo";
				connection.Execute(sql, habilitacoes);
			}
		}
	}
}
