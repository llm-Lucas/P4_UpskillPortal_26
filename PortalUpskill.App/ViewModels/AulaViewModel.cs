using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalUpskill.App.ViewModels
{
    /// <summary>
    /// Classe para validação de formulários para PortaUpskill.Data.Models.Aula
    /// </summary>
    public class AulaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Sumario { get; set; }

        [Required]
        public decimal? DuracaoHoras { get; set; }

        [Required]
        public DateTime HoraInicio { get; set; }

        public DateTime HoraFim { get; set; }

        [Required]
        public int? TurmaId { get; set; }

        [Required]
        public int? SalaId { get; set; }

        public int? FormadorId { get; set; }

        public int? ModuloId { get; set; }

        public Turma Turma { get; set; }
        /// <summary>
        /// Cria um novo objecto Aula, com os valores desta instância  
        /// </summary>
        /// <returns>Novo objecto modelo Aula</returns>
        public Aula CreateModel()
        {
            return new Aula
            {
                Id = this.Id,
                Sumario = this.Sumario,
                HoraInicio = this.HoraInicio,
                HoraFim = this.HoraFim,
                TurmaId = this.TurmaId,
                SalaId = this.SalaId,
                FormadorId = this.FormadorId,
                ModuloId = this.ModuloId,
                Turma = this.Turma
            };
        }
        /// <summary>
        /// Faz mapping de um objecto Aula para esta instância.
        /// Os parametros anteriores serão substituidos.
        /// </summary>
        /// <param name="aula">Modelo a copiar</param>
        public void FromModel(Aula aula)
        {
            Id = aula.Id;
            Sumario = aula.Sumario;
            DuracaoHoras = aula.DuracaoHoras;
            HoraInicio = aula.HoraInicio;
            HoraFim = aula.HoraFim;
            TurmaId = aula.TurmaId;
            SalaId = aula.SalaId;
            FormadorId = aula.FormadorId;
            ModuloId = aula.ModuloId;
            Turma = aula.Turma;
        }
    }
}
