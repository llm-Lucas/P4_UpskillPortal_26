using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.Models
{
    public class Modulo
    {
        public MarkupString ConteudosProgramaticosHTML
        {
            get
            {
                return (MarkupString)ConteudosProgramaticos; // or new MarkupString(html) }
            }
            set { }
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Horas { get; set; }
        public string Objetivos { get; set; }
        public string ConteudosProgramaticos { get; set; }
        public string SistemaAvaliacao { get; set; }
        public string Bibliografia { get; set; }
        public string SoftwareHardware { get; set; }

		public Formador Formador { get; set; }
		public List<AvaliacaoModular> Avaliacoes { get; set; } = new List<AvaliacaoModular>();
        public List<Formador> Formadores { get; set; } = new List<Formador>();
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
