using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;


namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaEstadosFormadorController : Controller
    {
        private readonly IListaEstadosFormadorData _listaEstadosFormadorData;

        public ListaEstadosFormadorController(IListaEstadosFormadorData listaEstadosFormadorData)
        {
            _listaEstadosFormadorData = listaEstadosFormadorData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var estados = _listaEstadosFormadorData.GetAll();
                return Ok(estados);
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
                var estado = _listaEstadosFormadorData.GetById(id);
                if (estado == null)
                {
                    return NotFound();
                }
                return Ok(estado);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("create")]
        public IActionResult Create([FromHeader] ListaEstadosFormador listaEstadosFormador)
        {
            try
            {
                _listaEstadosFormadorData.Create(listaEstadosFormador);
                return Created();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("update")]
        public IActionResult Update([FromHeader] ListaEstadosFormador listaEstadosFormador)
        {
            try
            {
                _listaEstadosFormadorData.Update(listaEstadosFormador);
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
                var estado = _listaEstadosFormadorData.GetById(id);
                if (estado == null)
                {
                    return NotFound();
                }
                _listaEstadosFormadorData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("remove_by_estado")]
        public IActionResult Remove([FromHeader] ListaEstadosFormador listaEstadosFormador)
        {
            try
            {
                _listaEstadosFormadorData.Remove(listaEstadosFormador);
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
