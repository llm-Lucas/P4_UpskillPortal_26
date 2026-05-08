using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;


namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaData _pessoaData;

        public PessoaController(IPessoaData pessoaData)
        {
            _pessoaData = pessoaData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var pessoas = _pessoaData.GetAll();
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
                var pessoa = _pessoaData.GetById(id);
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

        [HttpGet("get_by_email")]
        public IActionResult GetByEmail([FromHeader] string email)
        {
            try
            {
                var pessoa = _pessoaData.GetByEmail(email);
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
        public IActionResult Create([FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return BadRequest("Invalid data.");
                }
                _pessoaData.Create(pessoa);
                return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return BadRequest("Invalid data.");
                }
                _pessoaData.Update(pessoa);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("update_pwd")]
        public IActionResult UpdatePassword([FromBody] Pessoa pessoa, [FromHeader] string newPass)
        {
            try
            {
                if (pessoa == null || string.IsNullOrEmpty(newPass))
                {
                    return BadRequest("Invalid data.");
                }
                _pessoaData.UpdatePassword(pessoa, newPass);
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
                var pessoa = _pessoaData.GetById(id);
                if (pessoa == null)
                {
                    return NotFound();
                }
                _pessoaData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_by_pessoa")]
        public IActionResult Delete([FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return BadRequest("Invalid data.");
                }
                _pessoaData.Remove(pessoa);
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
