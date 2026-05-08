using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.ViewModels
{
    /// <summary>
    /// Classe para validação de formulários para PortaUpskill.Data.Models.Pessoal
    /// </summary>
    public class PessoalViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        [Required, DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "Endereço de email inválido.")]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Sexo { get; set; }

        public string NIF { get; set; }

        public string CC { get; set; }

        public string ContactoTelemovel { get; set; }

        public string ContactoTelefone { get; set; }

        public string Morada { get; set; }

        public string CP { get; set; }

        public string CodigoCNAEF { get; set; }

        public int HabilitacoesLiterarias { get; set; }

        public string Nacionalidade { get; set; }

        public string Foto { get; set; }

        public string CV { get; set; }

        [Required]
        public string Funcao { get; set; } = "Administrador";
           
        public Perfil Perfil { get; set; }

        public int? PerfilId { get; set; } = null;

        /// <summary>
        /// Cria um novo objecto Pessoal, com os valores desta instância  
        /// </summary>
        /// <returns>Novo objecto modelo Pessoal</returns>
        public Pessoal CreateModel()
        {
            return new Pessoal
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
                Funcao = this.Funcao,
                Perfil = this.Perfil,
                PerfilId = this.PerfilId
            };
        }

        /// <summary>
        /// Faz mapping de um objecto Pessoal para esta instância.
        /// Os parametros anteriores serão substituidos.
        /// </summary>
        /// <param name="pessoal">Modelo a copiar</param>
        public void FromModel(Pessoal pessoal)
        {
            Id = pessoal.Id;
            Nome = pessoal.Nome;
            DataNascimento = pessoal.DataNascimento;
            Email = pessoal.Email;
            Password = pessoal.Password;
            Sexo = pessoal.Sexo;
            NIF = pessoal.NIF;
            CC = pessoal.CC;
            ContactoTelemovel = pessoal.ContactoTelemovel;
            ContactoTelefone = pessoal.ContactoTelefone;
            Morada = pessoal.Morada;
            CP = pessoal.CP;
            CodigoCNAEF = pessoal.CodigoCNAEF;
            HabilitacoesLiterarias = pessoal.HabilitacoesLiterarias;
            Nacionalidade = pessoal.Nacionalidade;
            Foto = pessoal.Foto;
            CV = pessoal.CV;
            Funcao = pessoal.Funcao;
            Perfil = pessoal.Perfil;
            PerfilId = pessoal.PerfilId;
        }
    }
}
