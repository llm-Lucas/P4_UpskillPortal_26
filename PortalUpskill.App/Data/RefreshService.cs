using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.Data
{
    public class RefreshService 
    {
        public event Action Refresh;

        public void InvokeRefresh() => Refresh?.Invoke();

    }
}
