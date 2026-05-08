using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnaefController : Controller
    {
        private readonly ICNAEFData _cnaefData;

        public CnaefController(ICNAEFData cnaefData)
        {
            _cnaefData = cnaefData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var cnaefs = _cnaefData.GetAll();
                return Ok(cnaefs);
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
                var cnaef = _cnaefData.GetById(id);
                if (cnaef == null)
                {
                    return NotFound();
                }
                return Ok(cnaef);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CNAEF cnaef)
        {
            try
            {
                if (cnaef == null)
                {
                    return BadRequest("Invalid data.");
                }
                _cnaefData.Create(cnaef);
                return CreatedAtAction(nameof(GetById), new { id = cnaef.CodigoCNAEF }, cnaef);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_id")]
        public IActionResult Remove([FromHeader] int id)
        {
            try
            {
                var cnaef = _cnaefData.GetById(id);
                if (cnaef == null)
                {
                    return NotFound();
                }
                _cnaefData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("remove_by_cnaef")]
        public IActionResult Remove([FromBody] CNAEF cnaef)
        {
            try
            {
                if (cnaef == null)
                {
                    return BadRequest("Invalid data.");
                }
                _cnaefData.Remove(cnaef);
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
