using Microsoft.Data.SqlClient;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IFaltaData : IData<Falta>
    {
        public List<Falta> GetByAulaId(int aulaId);
        public void Create(List<Falta> faltas);
        public void Update(List<Falta> faltas);
        public void Remove(List<Falta> faltas);

        public void SubmeterJustificacao(int faltaId, string caminhoAnexo);
        void AtualizarEstadoFalta(int faltaId, string estado, bool justificada, string observacoes); 
        public List<Falta> GetFaltasPendentes();
        public void ProcessarValidacao(int faltaId, string novoEstado, string observacoes);
        // INICIO #008
        // Para a tabela no /DetalhesFormando que mostra as datas das Faltas justificadas e injustificadas
        List<Falta> GetByFormandoId(int formandoId);
        // FIM

    }
}
