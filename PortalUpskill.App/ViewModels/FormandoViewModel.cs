using PortalUpskill.Data.Models;
using PortalUpskill.App.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.ViewModels
{
	/// <summary>
	/// Classe para validação de formulários para PortaUpskill.Data.Models.Formando
	/// </summary>
	public class FormandoViewModel
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

		public string IBAN { get; set; }

		public bool Bolsa { get; set; }

		[RequiredPositiveInt]
		public int EstadoId { get; set; } = 1;

		public Perfil Perfil { get; set; }

		public int? PerfilId { get; set; } = null;

		/// <summary>
		/// Cria um novo objecto Formando, com os valores desta instância  
		/// </summary>
		/// <returns>Novo objecto modelo Formando</returns>
		public Formando CreateModel()
		{			
			var novoFormando = new Formando
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
				IBAN = this.IBAN,
				Bolsa = this.Bolsa,
				EstadoId = this.EstadoId,
				Estado = new Estado(),
				Perfil = this.Perfil,
				PerfilId = this.PerfilId,
				EstadosFormando = new EstadosFormando()
			};

			novoFormando.Estado.Id = EstadoId;
			return novoFormando;
		}

		/// <summary>
		/// Faz mapping de um objecto Formando para esta instância.
		/// Os parametros anteriores serão substituidos.
		/// </summary>
		/// <param name="formando">Modelo a copiar</param>
		public void FromModel(Formando formando)
		{
			Id = formando.Id;
			Nome = formando.Nome;
			DataNascimento = formando.DataNascimento;
			Email = formando.Email;
			Password = formando.Password;
			Sexo = formando.Sexo;
			NIF = formando.NIF;
			CC = formando.CC;
			ContactoTelemovel = formando.ContactoTelemovel;
			ContactoTelefone = formando.ContactoTelefone;
			Morada = formando.Morada;
			CP = formando.CP;
			CodigoCNAEF = formando.CodigoCNAEF;
			HabilitacoesLiterarias = formando.HabilitacoesLiterarias;
			Nacionalidade = formando.Nacionalidade;
			Foto = formando.Foto;
			CV = formando.CV;
			IBAN = formando.IBAN;
			Bolsa = formando.Bolsa;
			EstadoId = formando.EstadoId;
			Perfil = formando.Perfil;
			PerfilId = formando.PerfilId;
		}
	}
}
