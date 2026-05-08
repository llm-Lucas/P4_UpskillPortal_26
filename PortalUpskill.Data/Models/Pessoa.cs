using System;

namespace PortalUpskill.Data.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
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

        public Perfil Perfil { get; set; }
        public int? PerfilId { get; set; }
        public string Funcao { get; set; }
    }
}
