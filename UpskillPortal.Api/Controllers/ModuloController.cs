using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;
using UpskillPortal.Api.DTO;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : Controller
    {
        private readonly IModuloData _moduloData;

        public ModuloController(IModuloData moduloData)
        {
            _moduloData = moduloData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            var modulos = _moduloData.GetAll();
            return Ok(modulos);
        }

        [HttpGet("get_by_id")]
        public IActionResult GetById(int id)
        {
            var modulo = _moduloData.GetById(id);
            if (modulo == null)
            {
                return NotFound();
            }
            return Ok(modulo);
        }

        [HttpGet("get_by_id_with_formador")]
        public IActionResult GetByIdWithFormador(int id)
        {
            var modulo = _moduloData.GetByIdWithFormador(id);
            if (modulo == null)
            {
                return NotFound();
            }
            return Ok(modulo);
        }

        [HttpGet("get_modulos_by_curso")]
        public IActionResult GetModulosByCurso(int cursoId)
        {
            var modulos = _moduloData.GetModulosByCurso(cursoId);
            return Ok(modulos);
        }

        [HttpGet("get_modulos_com_formador_by_turma")]
        public IActionResult GetModulosComFormadorByTurma(int idTurma)
        {
            var modulos = _moduloData.GetModulosComFormadorByTurma(idTurma);
            return Ok(modulos);
        }

        [HttpGet("get_by_id_formador_id_turma")]
        public IActionResult GetByIdFormadorIdTurma(int idf, int idt)
        {
            var modulos = _moduloData.GetByIdFormadorIdTurma(idf, idt);
            return Ok(modulos);
        }

        [HttpPost("get_modulo_formador_by_turma")]
        public IActionResult GetModuloFormadorByTurma(Turma turma)
        {
            var modulos = _moduloData.GetModuloFormadorByTurma(turma);
            return Ok(modulos);
        }

        [HttpPost("insert_formadores")]
        public IActionResult InsertFormadores([FromBody] ModuloWithFormadoresDTO moduloWithFormadores)
        {
            var modulo = moduloWithFormadores.Modulo;
            var formadores = moduloWithFormadores.Formadores;

            if (modulo == null)
            {
                return BadRequest("Modulo cannot be null");
            }
            _moduloData.InsertFormadores(modulo, formadores);
            return Ok();
        }

        [HttpPost("remove_formadores")]
        public IActionResult RemoveFormadores([FromBody] ModuloWithFormadoresDTO moduloWithFormadores)
        {
            var modulo = moduloWithFormadores.Modulo;
            var formadores = moduloWithFormadores.Formadores;

            if (modulo == null)
            {
                return BadRequest("Modulo cannot be null");
            }
            _moduloData.RemoveFormadores(modulo, formadores);
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Modulo modulo)
        {
            if (modulo == null)
            {
                return BadRequest("Modulo cannot be null");
            }
            _moduloData.Create(modulo);
            return CreatedAtAction(nameof(GetById), new { id = modulo.Id }, modulo);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Modulo modulo)
        {
            if (modulo == null)
            {
                return BadRequest("Modulo cannot be null");
            }
            _moduloData.Update(modulo);
            return NoContent();
        }

        [HttpDelete("delete_by_id")]
        public IActionResult Delete(int id)
        {
            _moduloData.Remove(id);
            return NoContent();
        }

        [HttpDelete("delete_by_modulo")]
        public IActionResult Delete([FromBody] Modulo modulo)
        {
            if (modulo == null)
            {
                return BadRequest("Modulo cannot be null");
            }
            _moduloData.Remove(modulo);
            return NoContent();
        }
    }
}
