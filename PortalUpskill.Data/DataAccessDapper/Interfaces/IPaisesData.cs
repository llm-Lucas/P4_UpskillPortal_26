using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
	public interface IPaisesData : IData<Paises>
	{
		public Paises GetById(string iso);
	}
}
