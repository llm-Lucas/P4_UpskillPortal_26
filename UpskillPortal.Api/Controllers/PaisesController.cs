using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : Controller
    {
        private readonly IPaisesData _paisesData;

        public PaisesController(IPaisesData paisesData)
        {
            _paisesData = paisesData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var paises = _paisesData.GetAll();
                return Ok(paises);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get_by_id")]
        public IActionResult GetById(int numcode)
        {
            try
            {
                var pais = _paisesData.GetById(numcode);
                if (pais == null)
                {
                    return NotFound();
                }
                return Ok(pais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get_by_iso")]
        public IActionResult GetByIso(string iso)
        {
            try
            {
                var pais = _paisesData.GetById(iso);
                if (pais == null)
                {
                    return NotFound();
                }
                return Ok(pais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Paises pais)
        {
            try
            {
                _paisesData.Create(pais);
                return CreatedAtAction(nameof(GetById), new { numcode = pais.numcode }, pais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(int numcode)
        {
            try
            {
                var pais = _paisesData.GetById(numcode);
                if (pais == null)
                {
                    return NotFound();
                }
                _paisesData.Update(pais);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete_by_iso")]
        public IActionResult DeleteById(int iso)
        {
            try
            {
                _paisesData.Remove(iso);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete_by_pais")]
        public IActionResult DeleteByPais(Paises pais)
        {
            try
            {
                _paisesData.Remove(pais);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
