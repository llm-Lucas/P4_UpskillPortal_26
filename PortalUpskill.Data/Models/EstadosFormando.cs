using System;
namespace PortalUpskill.Data.Models
{
    public class EstadosFormando
    {
        public int Id { get; set; }
        public int ListaEstadoId { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }

		public Estado Estado { get; set; }
	}
}
