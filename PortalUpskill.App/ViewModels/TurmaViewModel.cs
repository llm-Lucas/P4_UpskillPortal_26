using System;
using PortalUpskill.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PortalUpskill.App.Utils;

namespace PortalUpskill.App.ViewModels
{
    public class TurmaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime? DataInicioCurso { get; set; }
        public DateTime? DataFimCurso { get; set; }
        public DateTime? HorarioAssincronoInicio { get; set; }
        public DateTime? HorarioAssincronoFim { get; set; }
        public DateTime? HorarioSincronoInicio { get; set; }
        public DateTime? HorarioSincronoFim { get; set; }
        public int TempoLectivo { get; set; }
        [RequiredPositiveInt]
        public int? CursoId { get; set; }
        public List<Aula> Aulas { get; set; } = new List<Aula>();
        public List<Formando> Formandos { get; set; } = new List<Formando>();
        public List<Modulo> Modulos { get; set; } = new List<Modulo>();
        public int? AnoLetivoId { get; set; }

        public Turma CreateModel()
        {
            return new Turma
            {
                Id = this.Id,
                Nome = this.Nome,
                DataInicioCurso = this.DataInicioCurso,
                DataFimCurso = this.DataFimCurso,
                CursoId = this.CursoId,
                HorarioAssincronoInicio = this.HorarioAssincronoInicio,
                HorarioAssincronoFim = this.HorarioAssincronoFim,
                HorarioSincronoInicio = this.HorarioSincronoInicio,
                HorarioSincronoFim = this.HorarioSincronoFim,
                AnoLetivoId = this.AnoLetivoId,
                TempoLectivo = this.TempoLectivo
            };
        }
        public void FromModel(Turma turma)
        {
            Id  = turma.Id;
            Nome = turma.Nome;
            DataInicioCurso = turma.DataInicioCurso;
            DataFimCurso = turma.DataFimCurso;
            CursoId = turma.CursoId;
            HorarioAssincronoInicio = turma.HorarioAssincronoInicio;
            HorarioAssincronoFim = turma.HorarioAssincronoFim;
            HorarioSincronoInicio = turma.HorarioSincronoInicio;
            HorarioSincronoFim = turma.HorarioSincronoFim;
            TempoLectivo = turma.TempoLectivo;
            AnoLetivoId = turma.AnoLetivoId;

        }
   
    }
}
