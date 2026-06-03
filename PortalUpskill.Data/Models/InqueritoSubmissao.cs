using System;
using System.Collections.Generic;

namespace PortalUpskill.Data.Models
{
    public class InqueritoSubmissao
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public int CursoId { get; set; }
        public DateTime DataSubmissao { get; set; }

        public int? AvaliacaoGeral { get; set; }
        public string ComentarioGeral { get; set; }

        public List<InqueritoModulo> Modulos { get; set; } = new List<InqueritoModulo>();
        public List<InqueritoFormador> Formadores { get; set; } = new List<InqueritoFormador>();
    }
}