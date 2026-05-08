using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;
using UpskillPortal.Api.DTO;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormadorController : Controller
    {
        private readonly IFormadorData _formadorData;

        public FormadorController(IFormadorData formadorData)
        {
            _formadorData = formadorData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var formadores = _formadorData.GetAll();
                return Ok(formadores);
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
                var formador = _formadorData.GetById(id);
                if (formador == null)
                {
                    return NotFound();
                }
                return Ok(formador);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_turma_by_id_form")]
        public IActionResult GetTurmaByIdForm([FromHeader] int id)
        {
            try
            {
                var turmas = _formadorData.GetTurmaByIdFormador(id);
                if (turmas == null)
                {
                    return NotFound();
                }
                return Ok(turmas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_turma_by_id_coordenador")]
        public IActionResult GetTurmaByIdCoor([FromHeader] int id)
        {
            try
            {
                var turmas = _formadorData.GetTurmaByIdCoordenador(id);
                if (turmas == null)
                {
                    return NotFound();
                }
                return Ok(turmas);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_coordenadores_by_curso")]
        public IActionResult GetCoordByCurso([FromHeader] int id)
        {
            try
            {
                var formadores = _formadorData.GetCoordByCurso(id);
                if (formadores == null)
                {
                    return NotFound();
                }
                return Ok(formadores);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_formadores_by_turma")]
        public IActionResult GetFormadoresByTurma([FromHeader] int id)
        {
            try
            {
                var formadores = _formadorData.GetFormadoresByTurma(id);
                if (formadores == null)
                {
                    return NotFound();
                }
                return Ok(formadores);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_historico_do_formador")]
        public IActionResult GetHistoricoDoFormador([FromHeader] int id)
        {
            try
            {
                var historico = _formadorData.ObterHistoricoDoFormador(id);
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

        [HttpPost("create")]
        public IActionResult Create()
        {
            try
            {
                var formador = new Formador();
                // Populate formador object with data from request body
                // _formadorData.Create(formador);
                return Ok(formador);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("create_return_id")]
        public IActionResult CreateReturnId([FromBody] Formador formador)
        {
            try
            {
                if (formador == null)
                {
                    return BadRequest("Invalid data.");
                }
                var id = _formadorData.CreateReturnId(formador);
                return Ok(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Formador formador)
        {
            try
            {
                if (formador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _formadorData.Update(formador);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("update_hist")]
        public IActionResult UpdateHist([FromBody] Formador formador)
        {
            try
            {
                if (formador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _formadorData.UpdateHistEstado(formador);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("insert_modulos")]
        public IActionResult InsertModulos([FromBody] FormadorWithModulosDTO data)
        {
            var formador = data.Formador;
            var modulos = data.Modulos;

            try
            {
                if (formador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _formadorData.InsertModulos(formador, modulos);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_modulos")]
        public IActionResult RemoveModulos([FromBody] FormadorWithModulosDTO data)
        {
            var formador = data.Formador;
            var modulos = data.Modulos;

            try
            {
                if (formador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _formadorData.RemoveModulos(formador, modulos);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete_by_formador")]
        public IActionResult Delete([FromBody] Formador formador)
        {
            try
            {
                if (formador == null)
                {
                    return BadRequest("Invalid data.");
                }
                _formadorData.Remove(formador);
                return Ok();
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
                var formador = _formadorData.GetById(id);
                if (formador == null)
                {
                    return NotFound();
                }
                _formadorData.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

    }
}