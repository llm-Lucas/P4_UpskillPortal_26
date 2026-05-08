using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.ViewModels
{
	/// <summary>
	/// Classe para validação de formulários para PortaUpskill.Data.Models.Curso
	/// </summary>
	public class CursoViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Nome { get; set; }

		[Required]
		public double DuracaoHoras { get; set; }

        public string Objetivos { get; set; }

        public Curso CreateModel()
		{
			return new Curso
			{
				Id = this.Id,
				Nome = this.Nome,
				DuracaoHoras = this.DuracaoHoras,
				Objetivos = this.Objetivos
			};
		}

		public void FromModel(Curso curso)
		{
			Id = curso.Id;
			Nome = curso.Nome;
			DuracaoHoras = curso.DuracaoHoras;
			Objetivos = curso.Objetivos;
		}
	}
}
