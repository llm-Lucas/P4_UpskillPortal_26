using System.Collections.Generic;

namespace PortalUpskill.Data.Models
{
    public class Formador : Pessoa
    {
        public bool CCP { get; set; }
        public bool DocenteEnsSuperior { get; set; }
		public int EstadoId { get; set; }
        public Estado Estado { get; set; }
		public EstadosFormador EstadosFormador { get; set; }

        public List<Modulo> Modulos { get; set; } = new List<Modulo>();
    }
}