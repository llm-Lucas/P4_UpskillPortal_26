using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormandoController : Controller
    {
        private readonly IFormandoData _formandoData;

        public FormandoController(IFormandoData formandoData)
        {
            _formandoData = formandoData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var formando = _formandoData.GetAll();
                return Ok(formando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_all_by_turma")]
        public IActionResult GetAllByTurma([FromHeader] int idt)
        {
            try
            {
                var formando = _formandoData.GetAllByTurma(idt);
                return Ok(formando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_all_by_turma_com_avaliacao")]
        public IActionResult GetAllByTurmaComAvaliacao([FromHeader] int idt)
        {
            try
            {
                var formando = _formandoData.GetAllByTurmaWithAvaliacao(idt);
                return Ok(formando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_all_by_turma_com_faltas")]
        public IActionResult GetAllByTurmaComFaltas([FromHeader] int idt)
        {
            try
            {
                var formando = _formandoData.GetAllByTurmaComFaltas(idt);
                return Ok(formando);
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
                var formando = _formandoData.GetById(id);
                if (formando == null)
                {
                    return NotFound();
                }
                return Ok(formando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create_single")]
        public IActionResult Create([FromBody] Formando formando)
        {
            try
            {
                if (formando == null)
                {
                    return BadRequest("Formando object is null");
                }
                _formandoData.Create(formando);
                return CreatedAtAction(nameof(GetById), new { id = formando.Id }, formando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create_multiple")]
        public IActionResult Create([FromBody] List<Formando> formandos)
        {
            try
            {
                if (formandos == null || formandos.Count == 0)
                {
                    return BadRequest("Formando list is null or empty");
                }
                _formandoData.Create(formandos);
                return CreatedAtAction(nameof(GetAll), formandos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("create_return_id")]
        public IActionResult CreateReturnId([FromBody] Formando formando)
        {
            try
            {
                if (formando == null)
                {
                    return BadRequest("Formando object is null");
                }
                var id = _formandoData.CreateReturnId(formando);
                return CreatedAtAction(nameof(GetById), new { id = id }, formando);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("create_avaliacao_mod")]
        public IActionResult CreateAvaliacaoMod([FromBody] List<Formando> formandos, [FromHeader] int idModulo, [FromHeader] int formadorId)
        {
            try
            {
                if (formandos == null || formandos.Count == 0)
                {
                    return BadRequest("Formando list is null or empty");
                }
                _formandoData.CreateAvaliacaoModular(formandos, idModulo, formadorId);
                return CreatedAtAction(nameof(GetAll), formandos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update_avaliacao_mod")]
        public IActionResult UpdateAvaliacaoMod([FromBody] List<Formando> formandos, [FromHeader] int idModulo)
        {
            try
            {
                if (formandos == null || formandos.Count == 0)
                {
                    return BadRequest("Formando list is null or empty");
                }
                _formandoData.UpdateAvaliacaoModular(formandos, idModulo);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("create_avaliacao_final")]
        public IActionResult CreateAvaliacaoFinal([FromBody] List<Formando> formandos)
        {
            try
            {
                if (formandos == null || formandos.Count == 0)
                {
                    return BadRequest("Formando list is null or empty");
                }
                _formandoData.CreateAvaliacaoFinal(formandos);
                return CreatedAtAction(nameof(GetAll), formandos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update_avaliacao_final")]
        public IActionResult UpdateAvaliacaoFinal([FromBody] List<Formando> formandos)
        {
            try
            {
                if (formandos == null || formandos.Count == 0)
                {
                    return BadRequest("Formando list is null or empty");
                }
                _formandoData.UpdateAvaliacaoFinal(formandos);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update_hist_estado")]
        public IActionResult UpdateHistEstado([FromBody] Formando formando)
        {
            try
            {
                if (formando == null)
                {
                    return BadRequest("Formando object is null");
                }
                _formandoData.UpdateHistEstado(formando);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("update")]
        public IActionResult Update([FromBody] Formando formando)
        {
            try
            {
                if (formando == null)
                {
                    return BadRequest("Formando object is null");
                }
                _formandoData.Update(formando);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("get_historico_formando")]
        public IActionResult GetHistoricoFormando([FromHeader] int id)
        {
            try
            {
                var historico = _formandoData.ObterHistoricoDoFormando(id);
                if (historico == null)
                {
                    return NotFound();
                }
                return Ok(historico);
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
                var formando = _formandoData.GetById(id);
                if (formando == null)
                {
                    return NotFound();
                }
                _formandoData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_by_formando")]
        public IActionResult Delete([FromBody] Formando formando)
        {
            try
            {
                if (formando == null)
                {
                    return BadRequest("Formando object is null");
                }
                _formandoData.Remove(formando);
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
