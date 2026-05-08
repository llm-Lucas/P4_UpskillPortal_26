using PortalUpskill.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PortalUpskill.App.ViewModels
{
    public class FormadorCoordenadorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime? DataNascimento { get; set; }

        [Required, DataType(DataType.EmailAddress), EmailAddress]
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

        public bool CCP { get; set; }

        public bool DocenteEnsSuperior { get; set; }

        public bool EhFormador { get; set; } = false;

        public string Funcao { get; set; }
        public Estado Estado { get; set; }

        public Perfil Perfil { get; set; }

        public int? PerfilId { get; set; } = null;

        public int EstadoId { get; set; }

        public CoordenadorFormador CreateModelPessoa()
        {
            return new CoordenadorFormador
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
                Perfil = this.Perfil,
                PerfilId = this.PerfilId,
                CCP = this.CCP,
                DocenteEnsSuperior = this.DocenteEnsSuperior,
                EstadoId = this.EstadoId,
                Estado = this.Estado,
                Funcao = this.Funcao
            };
        }

        public void FromModelPessoa(CoordenadorFormador pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.Nome;
            DataNascimento = pessoa.DataNascimento;
            Email = pessoa.Email;
            Password = pessoa.Password;
            Sexo = pessoa.Sexo;
            NIF = pessoa.NIF;
            CC = pessoa.CC;
            ContactoTelemovel = pessoa.ContactoTelemovel;
            ContactoTelefone = pessoa.ContactoTelefone;
            Morada = pessoa.Morada;
            CP = pessoa.CP;
            CodigoCNAEF = pessoa.CodigoCNAEF;
            HabilitacoesLiterarias = pessoa.HabilitacoesLiterarias;
            Nacionalidade = pessoa.Nacionalidade;
            Foto = pessoa.Foto;
            CV = pessoa.CV;
            Perfil = pessoa.Perfil;
            PerfilId = pessoa.PerfilId;
            CCP = pessoa.CCP;
            DocenteEnsSuperior = pessoa.DocenteEnsSuperior;
            EstadoId = pessoa.EstadoId;
            Estado = pessoa.Estado;
            Funcao = pessoa.Funcao;
        }
    }
}