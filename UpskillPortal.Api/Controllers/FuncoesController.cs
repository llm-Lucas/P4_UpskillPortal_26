using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncoesController : Controller
    {
        private readonly IFuncoesData _funcoesData;

        public FuncoesController(IFuncoesData funcoesData)
        {
            _funcoesData = funcoesData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var funcoes = _funcoesData.GetAll();
                return Ok(funcoes);
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
                var funcao = _funcoesData.GetById(id);
                if (funcao == null)
                {
                    return NotFound();
                }
                return Ok(funcao);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Funcoes funcao)
        {
            try
            {
                if (funcao == null)
                {
                    return BadRequest("Invalid data.");
                }
                _funcoesData.Create(funcao);
                return Created();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Funcoes funcao)
        {
            try
            {
                if (funcao == null)
                {
                    return BadRequest("Invalid data.");
                }
                _funcoesData.Update(funcao);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_id")]
        public IActionResult Remove(int id)
        {
            try
            {
                var funcao = _funcoesData.GetById(id);
                if (funcao == null)
                {
                    return NotFound();
                }
                _funcoesData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_funcao")]
        public IActionResult Remove([FromBody] Funcoes funcao)
        {
            try
            {
                if (funcao == null)
                {
                    return BadRequest("Invalid data.");
                }
                _funcoesData.Remove(funcao);
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
