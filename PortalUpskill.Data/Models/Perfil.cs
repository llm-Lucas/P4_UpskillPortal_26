using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.Models
{

    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<string> Permissoes { get; set; }
    }
}
