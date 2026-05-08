using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Curso precisa de uma designação.")]
        public string Nome { get; set; }
        public double DuracaoHoras { get; set; }
        public string Objetivos { get; set; }

        public Dictionary<Modulo, double> Modulos { get; set; } = new Dictionary<Modulo, double>();
        public List<Formador> Coordenadores { get; set; } = new List<Formador>();
    }
}