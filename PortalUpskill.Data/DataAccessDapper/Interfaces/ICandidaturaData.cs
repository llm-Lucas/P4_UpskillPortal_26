using PortalUpskill.Data.Models;
using System.Collections.Generic;

namespace PortalUpskill.Data.DataAccessDapper.Interfaces
{
    public interface ICandidaturaData
    {
        List<Candidatura> GetAll();
        Candidatura GetById(int id);
        int Create(Candidatura candidatura);
        void UpdateEstado(int candidaturaId, int estadoId);

        void Update(int id, int primeiraOpcaoId, int? segundaOpcaoId, string observacoes, string foto, string cv, string cert, string ccFrente, string ccVerso);

        void Submeter(int candidaturaId);

        void UpdateSituacaoProfissional(int candidaturaId, string situacao);

        List<Candidatura> GetAprovadosByCurso(int cursoId);
    }
}