using System;
using System.Collections.Generic;

namespace PortalUpskill.Data.Models
{
    public class AvaliacaoFinal
    {
        public int Id { get; set; }
        public int FormandoId { get; set; }
        public Formando Formando { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public double NotaFinal { get; set; }
        public bool Validou { get; set; }

        public List<Formando> Formandos { get; set; } = new List<Formando>();
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
