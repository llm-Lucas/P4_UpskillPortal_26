using System;
using PortalUpskill.Data.Models;
using System.Collections.Generic;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IAvaliacaoModularData : IData<AvaliacaoModular>
    {
        List<Formando> GetAllByTurmaModulo(int idt, int idm);
    }
}
