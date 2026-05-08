using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoalController : Controller
    {
        private readonly IPessoalData _pessoalData;

        public PessoalController(IPessoalData pessoalData)
        {
            _pessoalData = pessoalData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var pessoas = _pessoalData.GetAll();
                return Ok(pessoas);
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
                var pessoa = _pessoalData.GetById(id);
                if (pessoa == null)
                {
                    return NotFound();
                }
                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Pessoal pessoal)
        {
            try
            {
                if (pessoal == null)
                {
                    return BadRequest("Invalid data.");
                }
                var id = _pessoalData.CreateReturnId(pessoal);
                return CreatedAtAction(nameof(GetById), new { id }, pessoal);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("create_return_id")]
        public IActionResult CreateReturnId([FromBody] Pessoal pessoal)
        {
            try
            {
                if (pessoal == null)
                {
                    return BadRequest("Invalid data.");
                }
                var id = _pessoalData.CreateReturnId(pessoal);
                return CreatedAtAction(nameof(GetById), new { id }, pessoal);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Pessoal pessoal)
        {
            try
            {
                if (pessoal == null)
                {
                    return BadRequest("Invalid data.");
                }
                _pessoalData.Update(pessoal);
                return NoContent();
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
                var pessoa = _pessoalData.GetById(id);
                if (pessoa == null)
                {
                    return NotFound();
                }
                _pessoalData.Remove(pessoa);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_pessoal")]
        public IActionResult Remove([FromBody] Pessoal pessoal)
        {
            try
            {
                if (pessoal == null)
                {
                    return BadRequest("Invalid data.");
                }
                _pessoalData.Remove(pessoal);
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
