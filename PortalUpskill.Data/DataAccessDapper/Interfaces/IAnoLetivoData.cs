using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper.Interfaces
{
    public interface IAnoLetivoData
    {
        List<AnoLetivo> GetAll();
    }
}
