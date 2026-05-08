using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IPessoaData : IData<Pessoa> 
    {
        Pessoa GetByEmail(string email);

        void UpdatePassword(Pessoa pessoa, string newPass);
    }
}
