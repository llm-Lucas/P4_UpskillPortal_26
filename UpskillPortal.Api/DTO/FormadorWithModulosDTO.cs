using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.DTO
{
    public class FormadorWithModulosDTO
    {
        public Formador Formador { get; set; }
        public List<Modulo> Modulos { get; set; }
    }

}
