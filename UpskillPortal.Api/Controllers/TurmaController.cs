using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;
using UpskillPortal.Api.DTO;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private readonly ITurmaData _turmaData;

        public TurmaController(ITurmaData turmaData)
        {
            _turmaData = turmaData;
        }

        [HttpGet]
        public ActionResult<List<Turma>> GetAll()
        {
            return _turmaData.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Turma> GetById(int id)
        {
            return _turmaData.GetById(id);
        }

        [HttpGet("curso/{cursoId}")]
        public ActionResult<List<Turma>> GetByCurso(int cursoId)
        {
            return _turmaData.GetByCurso(cursoId);
        }

        [HttpGet("formandos/{turmaId}")]
        public ActionResult<List<Formando>> GetByTurma(int turmaId)
        {
            return _turmaData.GetByTurma(turmaId);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Turma turma)
        {
            _turmaData.Create(turma);
            return Ok();
        }

        [HttpPost("withReturn")]
        public ActionResult<int> CreateReturnId([FromBody] Turma turma)
        {
            return _turmaData.CreateReturnId(turma);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _turmaData.Remove(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Turma turma)
        {
            _turmaData.Update(turma);
            return Ok();
        }

        [HttpPost("add-to-curso")]
        public IActionResult AddToCurso([FromBody] CursoWithTurmasDTO model)
        {
            _turmaData.AddToCurso(model.Curso, model.Turmas);
            return Ok();
        }

        [HttpPost("remove-from-curso")]
        public IActionResult RemoveFromCurso([FromBody] CursoWithTurmasDTO model)
        {
            _turmaData.RemoveFromCurso(model.Curso, model.Turmas);
            return Ok();
        }

        [HttpPost("insert-formandos")]
        public IActionResult InsertFormandos([FromBody] TurmaWithFormandosDTO model)
        {
            _turmaData.InsertFormandos(model.Turma, model.Formandos);
            return Ok();
        }

        [HttpDelete("remove-formandos")]
        public IActionResult RemoveFormandos([FromBody] TurmaWithFormandosDTO model)
        {
            _turmaData.RemoveFormandos(model.Turma, model.Formandos);
            return Ok();
        }
    }
}
