using System;

namespace PortalUpskill.Data.Models
{
    public class InqueritoFormandoSubmetido
    {
        public int Id { get; set; }
        public int FormandoId { get; set; }
        public int TurmaId { get; set; }
        public DateTime DataSubmissao { get; set; }
    }
}