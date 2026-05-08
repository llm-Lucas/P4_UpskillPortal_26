using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortalUpskill.Data.Models;

namespace PortalUpskill.Data.DataAccessDapper
{
    public interface IFaltaData : IData<Falta>
    {
        public List<Falta> GetByAulaId(int aulaId);
        public void Create(List<Falta> faltas);
        public void Update(List<Falta> faltas);
        public void Remove(List<Falta> faltas);

        // INICIO #008
        // Para a tabela no /DetalhesFormando que mostra as datas das Faltas justificadas e injustificadas
        List<Falta> GetByFormandoId(int formandoId);
        // FIM

    }
}
