using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilitacoesController : Controller
    {
        private readonly IHabilitacoesData _habilitacoesData;

        public HabilitacoesController(IHabilitacoesData habilitacoesData)
        {
            _habilitacoesData = habilitacoesData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var habilitacoes = _habilitacoesData.GetAll();
                return Ok(habilitacoes);
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
                var habilitacao = _habilitacoesData.GetById(id);
                if (habilitacao == null)
                {
                    return NotFound();
                }
                return Ok(habilitacao);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Habilitacoes habilitacoes)
        {
            try
            {
                if (habilitacoes == null)
                {
                    return BadRequest("Invalid data.");
                }
                _habilitacoesData.Create(habilitacoes);
                return CreatedAtAction(nameof(GetById), new { id = habilitacoes.Codigo }, habilitacoes);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Habilitacoes habilitacoes)
        {
            try
            {
                if (habilitacoes == null)
                {
                    return BadRequest("Invalid data.");
                }
                _habilitacoesData.Update(habilitacoes);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_id")]
        public IActionResult RemoveById([FromHeader] int id)
        {
            try
            {
                var habilitacao = _habilitacoesData.GetById(id);
                if (habilitacao == null)
                {
                    return NotFound();
                }
                _habilitacoesData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_habilitacao")]
        public IActionResult RemoveByHabilitacao([FromBody] Habilitacoes habilitacoes)
        {
            try
            {
                if (habilitacoes == null)
                {
                    return BadRequest("Invalid data.");
                }
                _habilitacoesData.Remove(habilitacoes);
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
