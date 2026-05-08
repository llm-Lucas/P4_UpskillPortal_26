using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.DataAccessDapper.Interfaces;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosFormadorController : Controller
    {
        private readonly IEstadosFormadorData _estadosFormadorData;

        public EstadosFormadorController(IEstadosFormadorData estadosFormadorData)
        {
            _estadosFormadorData = estadosFormadorData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var estadosFormador = _estadosFormadorData.GetAll();
                return Ok(estadosFormador);
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
                var estadosFormador = _estadosFormadorData.GetById(id);
                if (estadosFormador == null)
                {
                    return NotFound();
                }
                return Ok(estadosFormador);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] EstadosFormador estadosFormador)
        {
            try
            {
                if (estadosFormador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _estadosFormadorData.Create(estadosFormador);
                return CreatedAtAction(nameof(GetById), new { id = estadosFormador.Id }, estadosFormador);
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
                var estadosFormador = _estadosFormadorData.GetById(id);
                if (estadosFormador == null)
                {
                    return NotFound();
                }
                _estadosFormadorData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("delete_by_estado")]
        public IActionResult Delete([FromBody] EstadosFormador estadosFormador)
        {
            try
            {
                if (estadosFormador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _estadosFormadorData.Remove(estadosFormador);
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
