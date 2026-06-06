using System;

namespace PortalUpskill.Data.Models
{
    public class AvaliacaoCandidatura
    {
        public int Id { get; set; }
        public int CandidaturaId { get; set; }
        public decimal? NotaPsicometrica { get; set; }
        public string NotaIngles { get; set; }
        public bool? PassouEntrevista { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataAvaliacao { get; set; }
    }
}