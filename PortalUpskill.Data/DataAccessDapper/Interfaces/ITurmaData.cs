using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface ITurmaData : IData<Turma> 
    {
        List<Turma> GetByCurso(int cursoId);

        List<Formando> GetByTurma(int turmaId);
        
        void AddToCurso(Curso curso, List<Turma> turmasToAdd);
        void RemoveFromCurso(Curso curso, List<Turma> turmasToRemove);
        int CreateReturnId(Turma turma);
        int CreateReturnId(Turma turma, Dictionary<int, ModuloFormadorHora> ModFor);
        //bool RemoveWithReturn(int id);
        void InsertFormandos(Turma turma, List<Formando> formandosToInsert);
        void RemoveFormandos(Turma turma, List<Formando> formandosToRemove);
        void Update(Turma turma, Dictionary<int, ModuloFormadorHora> ModFor);



    }
}
