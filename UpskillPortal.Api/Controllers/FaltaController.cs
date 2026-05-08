using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FaltaController : Controller
    {
        private readonly IFaltaData _faltaData;

        public FaltaController(IFaltaData faltaData)
        {
            _faltaData = faltaData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var faltas = _faltaData.GetAll();
                return Ok(faltas);
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
                var falta = _faltaData.GetById(id);
                if (falta == null)
                {
                    return NotFound();
                }
                return Ok(falta);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_by_aula_id")]
        public IActionResult GetByAulaId([FromHeader] int aulaId)
        {
            try
            {
                var faltas = _faltaData.GetByAulaId(aulaId);
                return Ok(faltas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create_single")]
        public IActionResult Create([FromBody] Falta falta)
        {
            try
            {
                if (falta == null)
                {
                    return BadRequest("Falta object is null");
                }
                _faltaData.Create(falta);
                return CreatedAtAction(nameof(GetById), new { id = falta.Id }, falta);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create_multiple")]
        public IActionResult Create([FromBody] List<Falta> faltas)
        {
            try
            {
                if (faltas == null || !faltas.Any())
                {
                    return BadRequest("Falta list is null or empty");
                }
                _faltaData.Create(faltas);
                return CreatedAtAction(nameof(GetAll), faltas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("update_single")]
        public IActionResult Update([FromBody] Falta falta)
        {
            try
            {
                if (falta == null)
                {
                    return BadRequest("Falta object is null");
                }
                _faltaData.Update(falta);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("update_multiple")]
        public IActionResult Update([FromBody] List<Falta> faltas)
        {
            try
            {
                if (faltas == null || !faltas.Any())
                {
                    return BadRequest("Falta list is null or empty");
                }
                _faltaData.Update(faltas);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_single")]
        public IActionResult Delete([FromBody] Falta falta)
        {
            try
            {
                if (falta == null)
                {
                    return BadRequest("Falta object is null");
                }
                _faltaData.Remove(falta);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_multiple")]
        public IActionResult Delete([FromBody] List<Falta> faltas)
        {
            try
            {
                if (faltas == null || !faltas.Any())
                {
                    return BadRequest("Falta list is null or empty");
                }
                _faltaData.Remove(faltas);
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
                var falta = _faltaData.GetById(id);
                if (falta == null)
                {
                    return NotFound();
                }
                _faltaData.Remove(id);
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
