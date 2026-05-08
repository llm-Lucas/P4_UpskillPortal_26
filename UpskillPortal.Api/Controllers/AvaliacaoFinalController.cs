using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoFinalController : Controller
    {
        private readonly IAvaliacaoFinalData _avaliacaoFinalData;

        public AvaliacaoFinalController(IAvaliacaoFinalData avaliacaoFinalData)
        {
            _avaliacaoFinalData = avaliacaoFinalData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var avaliacoes = _avaliacaoFinalData.GetAll();
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
                var avaliacao = _avaliacaoFinalData.GetById(id);
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

        [HttpPost("create")]
        public IActionResult Create([FromBody] AvaliacaoFinal avaliacao)
        {
            try
            {
                if (avaliacao == null)
                {
                    return BadRequest("Invalid data.");
                }
                _avaliacaoFinalData.Create(avaliacao);
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
                var avaliacao = _avaliacaoFinalData.GetById(id);
                if (avaliacao == null)
                {
                    return NotFound();
                }
                _avaliacaoFinalData.Remove(avaliacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("delete_by_avaliacao")]
        public IActionResult Delete([FromBody] AvaliacaoFinal avaliacao)
        {
            try
            {
                if (avaliacao == null)
                {
                    return BadRequest("Invalid data.");
                }
                var existingAvaliacao = _avaliacaoFinalData.GetById(avaliacao.Id);
                if (existingAvaliacao == null)
                {
                    return NotFound();
                }
                _avaliacaoFinalData.Remove(avaliacao);
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
