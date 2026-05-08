using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
	public interface ICursoData : IData<Curso>
	{
		int CreateReturnId(Curso curso);
		bool RemoveWithReturn(int id);
		List<Curso> GetAllWithModulos();

		void InsertModulos(Curso curso, List<Modulo> modulosToInsert);
		void InsertModulos(Curso curso, Dictionary<Modulo, double> modulosToInsert);

		void RemoveModulos(Curso curso, List<Modulo> modulosToRemove);
		void RemoveModulos(Curso curso, Dictionary<Modulo, double> modulosToRemove);

		void UpdateDuracaoModulos(Curso curso, Dictionary<Modulo, double> modulos);

		void InsertCoordenadores(int cursoId, List<Formador> Coordenadores);
		void RemoveCoordenadores(int cursoId, List<Formador> coordenadoresToRemove);
		void UpdateOrdemModulos(Curso curso);
	}
}
