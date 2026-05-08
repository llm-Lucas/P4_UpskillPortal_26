using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IAulaData : IData<Aula> 
    {
        List<Aula> GetByTurma(Turma turma);
        List<Aula> GetByTurma(int TurmaId);
        List<Aula> GetByTurmaFormador(int TurmaId, int FormadorId);
    }
}
