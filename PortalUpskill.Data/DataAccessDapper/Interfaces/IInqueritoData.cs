using System.Collections.Generic;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper.Interfaces
{
    public interface IInqueritoData
    {
        // Submissão de inquéritos

        bool FormandoJaSubmeteu(int formandoId, int turmaId);

        int CreateSubmissao(InqueritoSubmissao submissao);

        void CreateModulo(InqueritoModulo modulo);

        void CreateFormador(InqueritoFormador formador);

        void MarcarFormandoComoSubmetido(InqueritoFormandoSubmetido submetido);


        // Relatórios

        List<RelatorioInqueritoModulo> GetRelatorioModulos(int turmaId);

        List<RelatorioInqueritoFormador> GetRelatorioFormadores(int turmaId);

        List<RelatorioInqueritoComentario> GetComentarios(int turmaId);

        RelatorioInqueritoGeral GetRelatorioGeral(int turmaId);

        int GetTotalSubmissoes(int turmaId);
    }
}