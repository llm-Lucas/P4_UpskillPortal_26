using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private readonly ICursoData _cursoData;

        public CursoController(ICursoData cursoData)
        {
            _cursoData = cursoData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var cursos = _cursoData.GetAll();
                return Ok(cursos);
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
                var curso = _cursoData.GetById(id);
                if (curso == null)
                {
                    return NotFound();
                }
                return Ok(curso);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("get_all_with_modulos")]
        public IActionResult GetAllWithModulos()
        {
            try
            {
                var cursos = _cursoData.GetAllWithModulos();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Curso curso)
        {
            try
            {
                if (curso == null)
                {
                    return BadRequest("Curso is null");
                }
                var id = _cursoData.CreateReturnId(curso);
                return CreatedAtAction(nameof(GetById), new { id }, curso);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("create_return_id")]
        public IActionResult CreateReturnId([FromBody] Curso curso)
        {
            try
            {
                if (curso == null)
                {
                    return BadRequest("Curso is null");
                }
                var id = _cursoData.CreateReturnId(curso);
                return CreatedAtAction(nameof(GetById), new { id }, curso);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Curso curso)
        {
            try
            {
                if (curso == null)
                {
                    return BadRequest("Curso is null");
                }
                _cursoData.Update(curso);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("insert_coordenadores")]
        public IActionResult InsertCoordenadores([FromHeader] int cursoId, [FromBody] List<Formador> coordenadores)
        {
            try
            {
                if (coordenadores == null || coordenadores.Count == 0)
                {
                    return BadRequest("Coordenadores is null or empty");
                }
                _cursoData.InsertCoordenadores(cursoId, coordenadores);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_coordenadores")]
        public IActionResult RemoveCoordenadores([FromHeader] int cursoId, [FromBody] List<Formador> coordenadores)
        {
            try
            {
                if (coordenadores == null || coordenadores.Count == 0)
                {
                    return BadRequest("Coordenadores is null or empty");
                }
                _cursoData.RemoveCoordenadores(cursoId, coordenadores);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_modulos")]
        public IActionResult RemoveModulos([FromHeader] int cursoId, [FromBody] List<Modulo> modulos)
        {
            try
            {
                if (modulos == null || modulos.Count == 0)
                {
                    return BadRequest("Modulos is null or empty");
                }
                var curso = _cursoData.GetById(cursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _cursoData.RemoveModulos(curso, modulos);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("remove_modulos_time")]
        public IActionResult RemoveModulosTime([FromHeader] int cursoId, [FromBody] Dictionary<Modulo, double> modulos)
        {
            try
            {
                if (modulos == null || modulos.Count == 0)
                {
                    return BadRequest("Modulos is null or empty");
                }
                var curso = _cursoData.GetById(cursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _cursoData.RemoveModulos(curso, modulos);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("insert_modulos")]
        public IActionResult InsertModulos([FromHeader] int cursoId, [FromBody] List<Modulo> modulos)
        {
            try
            {
                if (modulos == null || modulos.Count == 0)
                {
                    return BadRequest("Modulos is null or empty");
                }
                var curso = _cursoData.GetById(cursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _cursoData.InsertModulos(curso, modulos);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("insert_modulos_time")]
        public IActionResult InsertModulosTime([FromHeader] int cursoId, [FromBody] Dictionary<Modulo, double> modulos)
        {
            try
            {
                if (modulos == null || modulos.Count == 0)
                {
                    return BadRequest("Modulos is null or empty");
                }
                var curso = _cursoData.GetById(cursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _cursoData.InsertModulos(curso, modulos);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update_duracao_modulos")]
        public IActionResult UpdateDuracaoModulos([FromHeader] int cursoId, [FromBody] Dictionary<Modulo, double> modulos)
        {
            try
            {
                if (modulos == null || modulos.Count == 0)
                {
                    return BadRequest("Modulos is null or empty");
                }
                var curso = _cursoData.GetById(cursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _cursoData.UpdateDuracaoModulos(curso, modulos);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("update_ordem_modulos")]
        public IActionResult UpdateOrdemModulos([FromHeader] int cursoId, [FromBody] List<Modulo> modulos)
        {
            try
            {
                if (modulos == null || modulos.Count == 0)
                {
                    return BadRequest("Modulos is null or empty");
                }
                var curso = _cursoData.GetById(cursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _cursoData.UpdateOrdemModulos(curso);
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
