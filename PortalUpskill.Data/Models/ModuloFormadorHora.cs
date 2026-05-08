using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.Models
{
/// <summary>
/// Esta classe serve para transferir entre componentes 
/// a relação entre o Formador, o Módulo e as Horas deste módulo para cada turma.
/// </summary>
    public class ModuloFormadorHora
    {
        public int FormadorId { get; set; }
        public double Horas { get; set; }
    }
}
