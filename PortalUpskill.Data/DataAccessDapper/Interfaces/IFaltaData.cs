using Microsoft.Data.SqlClient;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IFaltaData : IData<Falta>
    {
        List<Falta> GetByAulaId(int aulaId);
        void Create(List<Falta> faltas);
        void Update(List<Falta> faltas);
        void Remove(List<Falta> faltas);

        // Submissão pelo formando: guarda o anexo, a observação e define Estado = 'Pendente'
        void SubmeterJustificacao(int faltaId, string caminhoAnexo, string observacoes);

        // Cancela uma submissão pendente: limpa o anexo e repõe o estado anterior
        void CancelarJustificacao(int faltaId);

        // Decisão do admin/coordenador: atualiza Estado, Justificada e Observacoes (feedback)
        void AtualizarEstadoFalta(int faltaId, string estado, bool justificada, string observacoes);

        // Utilizado em ValidarJustificacoes: lista todas as faltas com Estado = 'Pendente'
        List<Falta> GetFaltasPendentes();

        // Utilizado em PaginaFaltasFormando: faltas do formando com Aula e Módulo incluídos
        List<Falta> GetByFormandoId(int formandoId);
    }
}