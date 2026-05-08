using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.Models
{
    public class Aula
    {
        public int Id { get; set; }
        public string Sumario { get; set; }
        public decimal? DuracaoHoras
        {
            get
            {
                return (decimal?)(HoraFim - HoraInicio).TotalHours;
            }
        }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }

        public int? TurmaId { get; set; }
        public int? SalaId { get; set; }
        public int? FormadorId { get; set; }
        public int? ModuloId { get; set; }
        public Turma Turma { get; set; }
        public Formador Formador { get; set; }
    }
}
