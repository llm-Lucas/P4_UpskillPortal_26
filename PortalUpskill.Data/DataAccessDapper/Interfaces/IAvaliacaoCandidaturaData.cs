using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IAvaliacaoCandidaturaData
    {
        AvaliacaoCandidatura GetByCandidatura(int candidaturaId);
        void Create(AvaliacaoCandidatura avaliacao);
        void Update(AvaliacaoCandidatura avaliacao);
    }
}