using System;

namespace PortalUpskill.Data.Models
{
    public class Candidatura
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int PrimeiraOpcaoId { get; set; }
        public Curso PrimeiraOpcao { get; set; }
        public int? SegundaOpcaoId { get; set; }
        public Curso SegundaOpcao { get; set; }
        public string Observacoes { get; set; }
        public int EstadoId { get; set; }
        public EstadoCandidatura Estado { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Foto { get; set; }
        public string CV { get; set; }
        public string CertificadoHabilitacoes { get; set; }
        public string CCFrente { get; set; }
        public string CCVerso { get; set; }
        public string SituacaoProfissional { get; set; }
        public bool TermosAceites { get; set; }
    }
}