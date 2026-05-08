using System;
using System.Collections.Generic;

namespace PortalUpskill.Data.Models
{
    public class AvaliacaoModular
    {
        public int Id { get; set; }
        public int FormandoId { get; set; }
        public Formando Formando { get; set; }
        public double NotaFinal { get; set; }
        public string Comentarios { get; set; }
        public int ModuloId { get; set; }
        public Modulo Modulo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Validou { get; set; }
        public int FormadorId { get; set; }
        public Formador Formador { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public List<Formando> Formandos { get; set; } = new List<Formando>();
        public List<Modulo> Modulos { get; set; } = new List<Modulo>();
        public List<Formador> Formadores { get; set; } = new List<Formador>();
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}