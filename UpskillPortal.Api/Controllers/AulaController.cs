using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : Controller
    {
        private readonly IAulaData _aulaData;

        public AulaController(IAulaData aulaData)
        {
            _aulaData = aulaData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var aulas = _aulaData.GetAll();
                return Ok(aulas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_by_id")]
        public IActionResult GetById([FromHeader] int id)
        {
            try
            {
                var aula = _aulaData.GetById(id);
                if (aula == null)
                {
                    return NotFound();
                }
                return Ok(aula);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_by_turma")]
        public IActionResult GetByTurma([FromHeader] Turma turma)
        {
            try
            {
                var aulas = _aulaData.GetByTurma(turma);
                if (aulas == null || !aulas.Any())
                {
                    return NotFound();
                }
                return Ok(aulas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_by_turma_id")]
        public IActionResult GetByTurmaId([FromHeader] int turmaId)
        {
            try
            {
                var aulas = _aulaData.GetByTurma(turmaId);
                if (aulas == null || !aulas.Any())
                {
                    return NotFound();
                }
                return Ok(aulas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_by_turma_formador")]
        public IActionResult GetByTurmaFormador([FromHeader] int turmaId, [FromHeader] int formadorId)
        {
            try
            {
                var aulas = _aulaData.GetByTurmaFormador(turmaId, formadorId);
                if (aulas == null || !aulas.Any())
                {
                    return NotFound();
                }
                return Ok(aulas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Aula aula)
        {
            try
            {
                if (aula == null)
                {
                    return BadRequest("Aula is null");
                }
                _aulaData.Create(aula);
                return CreatedAtAction(nameof(GetById), new { id = aula.Id }, aula);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Aula aula)
        {
            try
            {
                if (aula == null)
                {
                    return BadRequest("Aula is null");
                }
                _aulaData.Update(aula);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_by_id")]
        public IActionResult Delete([FromHeader] int id)
        {
            try
            {
                var aula = _aulaData.GetById(id);
                if (aula == null)
                {
                    return NotFound();
                }
                _aulaData.Remove(aula);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_by_aula")]
        public IActionResult Delete([FromBody] Aula aula)
        {
            try
            {
                _aulaData.Remove(aula);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
