using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosFormandoController : Controller
    {
        private readonly IEstadosFormandoData _estadosFormandoData;

        public EstadosFormandoController(IEstadosFormandoData estadosFormandoData)
        {
            _estadosFormandoData = estadosFormandoData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var estadosFormando = _estadosFormandoData.GetAll();
                return Ok(estadosFormando);
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
                var estadoFormando = _estadosFormandoData.GetById(id);
                if (estadoFormando == null)
                {
                    return NotFound();
                }
                return Ok(estadoFormando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] EstadosFormando estadosFormando)
        {
            try
            {
                if (estadosFormando == null)
                {
                    return BadRequest("Invalid data.");
                }
                _estadosFormandoData.Create(estadosFormando);
                return CreatedAtAction(nameof(GetById), new { id = estadosFormando.Id }, estadosFormando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var estadoFormando = _estadosFormandoData.GetById(id);
                if (estadoFormando == null)
                {
                    return NotFound();
                }
                _estadosFormandoData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("remove_by_estado")]
        public IActionResult Delete([FromBody] EstadosFormando estadosFormando)
        {
            try
            {
                if (estadosFormando == null)
                {
                    return BadRequest("Invalid data.");
                }
                _estadosFormandoData.Remove(estadosFormando);
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
