using PortalUpskill.Data.Models;
using System.Collections.Generic;

namespace PortalUpskill.Data.DataAccessDapper.Interfaces
{
    public interface ICursoCoordenadorData
    {
        List<Pessoa> GetCoordenadoresByCurso(int cursoId);
    }
}