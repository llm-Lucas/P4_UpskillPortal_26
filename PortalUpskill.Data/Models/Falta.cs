using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.Models
{
    public class Falta
    {
        public int Id { get; set; }
        public int AulaId { get; set; }
        //public Aula Aula { get; set; }
        public int FormandoId { get; set; }
        //public Formando Formando { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public bool Justificada { get; set; }
        public string Anexo { get; set; }
        public int Duracao { get; set; }

        //public List<Aula> Modulos { get; set; } = new List<Aula>();
        //public List<Formador> Formadores { get; set; } = new List<Formador>();
        //public List<Formando> Formandos { get; set; } = new List<Formando>();

        public bool Equal(Falta falta)
		{
            if (this.Id == falta.Id &&
                this.AulaId == falta.AulaId &&
                this.FormandoId == falta.FormandoId &&
                this.HoraInicio == falta.HoraInicio &&
                this.HoraFim == falta.HoraFim &&
                this.Justificada == falta.Justificada &&
                this.Anexo == falta.Anexo &&
                this.Duracao == falta.Duracao)
			{
                return true;
			}
            else { return false; }
		}
    }
}
