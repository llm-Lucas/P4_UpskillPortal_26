using PortalUpskill.Data.Models;
using System.Collections.Generic;

namespace PortalUpskill.Data.DataAccessDapper.Interfaces
{
    public interface ICursoCoordenadorData
    {
        List<Pessoa> GetCoordenadoresByCurso(int cursoId);

        List<Curso> GetCursosByCoordenador(int coordenadorId);
        void InsertCursoCoordenador(int cursoId, int coordenadorId);
        void RemoveCursoCoordenador(int cursoId, int coordenadorId);
    }
}