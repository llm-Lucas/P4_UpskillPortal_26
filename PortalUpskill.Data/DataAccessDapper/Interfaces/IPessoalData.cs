using PortalUpskill.Data.Models;
using System.Collections.Generic;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IPessoalData : IData<Pessoal>
    {
        public int CreateReturnId(Pessoal pessoal);
    }
}