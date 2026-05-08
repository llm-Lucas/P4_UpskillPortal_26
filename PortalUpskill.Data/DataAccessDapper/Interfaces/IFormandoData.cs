using PortalUpskill.Data.Models;
using System.Collections.Generic;

namespace PortalUpskill.Data.DataAccessDapper
{
	public interface IFormandoData : IData<Formando>
	{
		void UpdateHistEstado(Formando formando);
		void Create(List<Formando> formandos);
		int CreateReturnId(Formando formando);
		void CreateAvaliacaoModular(List<Formando> formandos, int idModulo, int formadorId);
		void UpdateAvaliacaoModular(List<Formando> formandos, int idModulo);
		void CreateAvaliacaoFinal(List<Formando> formandos);
		void UpdateAvaliacaoFinal(List<Formando> formandos);
		List<EstadosFormando> ObterHistoricoDoFormando(int id);
		List<Formando> GetAllByTurma(int id);
		List<Formando> GetAllByTurmaComFaltas(int turmaId);
		List<Formando> GetAllByTurmaWithAvaliacao(int turmaId);
	}
}