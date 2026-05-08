using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoModularController : Controller
    {
        private readonly IAvaliacaoModularData _avaliacaoModularData;

        public AvaliacoModularController(IAvaliacaoModularData avaliacaoModularData)
        {
            _avaliacaoModularData = avaliacaoModularData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var avaliacoes = _avaliacaoModularData.GetAll();
                return Ok(avaliacoes);
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
                var avaliacao = _avaliacaoModularData.GetById(id);
                if (avaliacao == null)
                {
                    return NotFound();
                }
                return Ok(avaliacao);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_all_by_turma_modulo")]
        public IActionResult GetAllByTurmaModulo([FromHeader] int idt, [FromHeader] int idm)
        {
            try
            {
                var avaliacoes = _avaliacaoModularData.GetAllByTurmaModulo(idt, idm);
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] AvaliacaoModular avaliacao)
        {
            try
            {
                if (avaliacao == null)
                {
                    return BadRequest("Invalid data.");
                }
                _avaliacaoModularData.Create(avaliacao);
                return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_by_id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var avaliacao = _avaliacaoModularData.GetById(id);
                if (avaliacao == null)
                {
                    return NotFound();
                }
                _avaliacaoModularData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("delete_by_avaliacao")]
        public IActionResult Delete([FromBody] AvaliacaoModular avaliacao)
        {
            try
            {
                if (avaliacao == null)
                {
                    return BadRequest("Invalid data.");
                }
                _avaliacaoModularData.Remove(avaliacao);
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
