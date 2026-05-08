using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface ICoordenadorFormadorData : IData<CoordenadorFormador>
	{
		public int CreateReturnId(CoordenadorFormador coordenadorformador);
	}
}
