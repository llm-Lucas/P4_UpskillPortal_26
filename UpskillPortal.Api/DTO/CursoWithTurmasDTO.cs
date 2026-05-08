using System.Collections.Generic;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.DTO
{
    public class CursoWithTurmasDTO
    {
        public Curso Curso { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
