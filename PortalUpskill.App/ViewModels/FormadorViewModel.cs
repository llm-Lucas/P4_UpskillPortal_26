using PortalUpskill.Data.Models;
using PortalUpskill.App.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace PortalUpskill.App.ViewModels
{
    /// <summary>
    /// Classe para validação de formulários para PortaUpskill.Data.Models.Formador
    /// </summary>
    public class FormadorViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Nome { get; set; }

		[Required]
		public DateTime? DataNascimento { get; set; }

		[Required, DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Endereço de email inválido.")]
		public string Email { get; set; }
		
		public string Password { get; set; }

		[Required]
		public string Sexo { get; set; }

		[Required]
		public string NIF { get; set; }

		[Required]
		public string CC { get; set; }

		[Required]
		public string ContactoTelemovel { get; set; }

		public string ContactoTelefone { get; set; }

		[Required]
		public string Morada { get; set; }

		[Required]
		public string CP { get; set; }
		
		public string CodigoCNAEF { get; set; }

		[Required]
		public int HabilitacoesLiterarias { get; set; }

		[Required]
		public string Nacionalidade { get; set; }

		public string Foto { get; set; }
		public string CV { get; set; }

		[Required]
		public bool CCP { get; set; }

		public bool DocenteEnsSuperior { get; set; }

		[RequiredPositiveInt]
		public int EstadoId { get; set; } = 1;

		public Perfil Perfil { get; set; }

		public int? PerfilId { get; set; } = null;

		public string Funcao { get; set; }

		/// <summary>
		/// Cria um novo objecto Formador, com os valores desta instância  
		/// </summary>
		/// <returns>Novo objecto modelo Formador</returns>
		public Formador CreateModel()
		{
			Formador novoF = new Formador
			{
				Id = this.Id,
				Nome = this.Nome,
				DataNascimento = this.DataNascimento,
				Email = this.Email,
				Password = this.Password,
				Sexo = this.Sexo,
				NIF = this.NIF,
				CC = this.CC,
				ContactoTelemovel = this.ContactoTelemovel,
				ContactoTelefone = this.ContactoTelefone,
				Morada = this.Morada,
				CP = this.CP,
				CodigoCNAEF = this.CodigoCNAEF,
				HabilitacoesLiterarias = this.HabilitacoesLiterarias,
				Nacionalidade = this.Nacionalidade,
				Foto = this.Foto,
				CV = this.CV,
				CCP = this.CCP,
				DocenteEnsSuperior = this.DocenteEnsSuperior,
				Estado = new Estado(),
				EstadoId = EstadoId,
				Perfil = this.Perfil,
				PerfilId = this.PerfilId,
				Funcao = this.Funcao,
				EstadosFormador = new EstadosFormador()
			};

			novoF.Estado.Id = EstadoId;
			return novoF;
		}

		/// <summary>
		/// Faz mapping de um objecto Formador para esta instância.
		/// Os parametros anteriores serão substituidos.
		/// </summary>
		/// <param name="formador">Modelo a copiar</param>
		public void FromModel(Formador formador)
		{
			Id = formador.Id;
			Nome = formador.Nome;
			DataNascimento = formador.DataNascimento;
			Email = formador.Email;
			Password = formador.Password;
			Sexo = formador.Sexo;
			NIF = formador.NIF;
			CC = formador.CC;
			ContactoTelemovel = formador.ContactoTelemovel;
			ContactoTelefone = formador.ContactoTelefone;
			Morada = formador.Morada;
			CP = formador.CP;
			CodigoCNAEF = formador.CodigoCNAEF;
			HabilitacoesLiterarias = formador.HabilitacoesLiterarias;
			Nacionalidade = formador.Nacionalidade;
			Foto = formador.Foto;
			CV = formador.CV;
			CCP = formador.CCP;
			DocenteEnsSuperior = formador.DocenteEnsSuperior;
            EstadoId = formador.Estado.Id;
			Perfil = formador.Perfil;
			PerfilId = formador.PerfilId;
			Funcao = formador.Funcao;
		}
	}
}