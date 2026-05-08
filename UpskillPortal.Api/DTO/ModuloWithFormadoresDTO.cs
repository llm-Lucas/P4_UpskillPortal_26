using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.DTO
{
    public class ModuloWithFormadoresDTO
    {
        public List<Formador> Formadores { get; set; }
        public Modulo Modulo { get; set; }
    }

}
