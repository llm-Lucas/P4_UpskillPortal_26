using System.Collections.Generic;

namespace PortalUpskill.Data.Models
{
    public class Formando : Pessoa
    {
        public string IBAN { get; set; }
        public bool Bolsa { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public Turma Turma { get; set; }
        public EstadosFormando EstadosFormando { get; set; }
        public Falta FaltaJustificadas { get; set; }
        public Falta FaltaInjustificadas { get; set; }
        public AvaliacaoFinal AvaliacaoFinal { get; set; }
        public AvaliacaoModular AvaliacaoModular { get; set; }
        public Dictionary<int, AvaliacaoModular> DictAvaliacaoModular { get; set; }

		public Formando() { }

		public Formando(Formando formando)
		{
            this.Id = formando.Id;
            this.Nome = formando.Nome;
            this.Turma = formando.Turma;
            this.DictAvaliacaoModular = new Dictionary<int, AvaliacaoModular>(formando.DictAvaliacaoModular);
        }
    }
}