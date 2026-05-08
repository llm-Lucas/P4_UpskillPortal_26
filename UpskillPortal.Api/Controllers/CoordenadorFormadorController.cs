using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordenadorFormadorController : Controller
    {
        private readonly ICoordenadorFormadorData _coordenadorFormadorData;

        public CoordenadorFormadorController(ICoordenadorFormadorData coordenadorFormadorData)
        {
            _coordenadorFormadorData = coordenadorFormadorData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var coordenadores = _coordenadorFormadorData.GetAll();
                return Ok(coordenadores);
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
                var coordenador = _coordenadorFormadorData.GetById(id);
                if (coordenador == null)
                {
                    return NotFound();
                }
                return Ok(coordenador);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("create")]
        public IActionResult Create([FromBody] CoordenadorFormador coordenadorFormador)
        {
            try
            {
                if (coordenadorFormador == null)
                {
                    return BadRequest("Invalid data.");
                }
                var id = _coordenadorFormadorData.CreateReturnId(coordenadorFormador);
                return CreatedAtAction(nameof(GetById), new { id }, coordenadorFormador);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("create_return_id")]
        public IActionResult CreateReturnId([FromBody] CoordenadorFormador coordenadorFormador)
        {
            try
            {
                if (coordenadorFormador == null)
                {
                    return BadRequest("Invalid data.");
                }
                var id = _coordenadorFormadorData.CreateReturnId(coordenadorFormador);
                return CreatedAtAction(nameof(GetById), new { id }, coordenadorFormador);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CoordenadorFormador coordenadorFormador)
        {
            try
            {
                if (coordenadorFormador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _coordenadorFormadorData.Update(coordenadorFormador);
                return NoContent();
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
                var coordenador = _coordenadorFormadorData.GetById(id);
                if (coordenador == null)
                {
                    return NotFound();
                }
                _coordenadorFormadorData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_by_coordenador")]
        public IActionResult Delete([FromBody] CoordenadorFormador coordenadorFormador)
        {
            try
            {
                if (coordenadorFormador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _coordenadorFormadorData.Remove(coordenadorFormador);
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
