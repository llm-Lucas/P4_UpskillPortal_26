using PortalUpskill.Data.Models;
using System.Collections.Generic;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IFormadorData : IData<Formador>
    {
        void UpdateHistEstado(Formador formador);
        public List<EstadosFormador> ObterHistoricoDoFormador(int id);
        public List<Turma> GetTurmaByIdCoordenador(int coordenadorId);
        public List<Formador> GetFormadoresByTurma(int turmaId);
        int CreateReturnId(Formador formador);
        void InsertModulos(Formador formador, List<Modulo> modulosToInsert);
        void RemoveModulos(Formador formador, List<Modulo> modulosToRemove);
        List<Formador> GetCoordByCurso(int cursoId);
        public List<Turma> GetTurmaByIdFormador(int id);
    }
}