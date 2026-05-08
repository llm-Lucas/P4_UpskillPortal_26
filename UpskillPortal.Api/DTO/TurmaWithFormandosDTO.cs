using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.DTO
{
    public class TurmaWithFormandosDTO
    {
        public Turma Turma { get; set; }
        public List<Formando> Formandos { get; set; }
    }
}
