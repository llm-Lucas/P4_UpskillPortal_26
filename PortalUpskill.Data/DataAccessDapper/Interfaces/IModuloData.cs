using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IModuloData : IData<Modulo>

    {
        Modulo GetByIdWithFormador(int id);
        List<Modulo> GetModulosByCurso(int cursoId);
        List<Modulo> GetModulosComFormadorByTurma(int idTurma);
        void RemoveFormadores(Modulo modulo, List<Formador> formadoresToRemove);
        void InsertFormadores(Modulo modulo, List<Formador> formadoresToInsert);
        List<Modulo> GetByIdFormadorIdTurma(int idf, int idt);
        Dictionary<int, ModuloFormadorHora> GetModuloFormadorByTurma(Turma turma);
    }

}
