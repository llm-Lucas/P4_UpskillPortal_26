using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;


namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaEstadosFormandoController : Controller
    {
        private readonly IListaEstadosFormandoData _listaEstadosFormandoData;

        public ListaEstadosFormandoController(IListaEstadosFormandoData listaEstadosFormandoData)
        {
            _listaEstadosFormandoData = listaEstadosFormandoData;
        }

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try
            {
                var estados = _listaEstadosFormandoData.GetAll();
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
                var estado = _listaEstadosFormandoData.GetById(id);
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
        public IActionResult Create([FromHeader] ListaEstadosFormando listaEstadosFormando)
        {
            try
            {
                _listaEstadosFormandoData.Create(listaEstadosFormando);
                return Created();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("update")]
        public IActionResult Update([FromHeader] ListaEstadosFormando listaEstadosFormando)
        {
            try
            {
                _listaEstadosFormandoData.Update(listaEstadosFormando);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("remove_by_id")]
        public IActionResult Remove([FromHeader] int id)
        {
            try
            {
                _listaEstadosFormandoData.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("remove_by_lista")]
        public IActionResult Remove([FromHeader] ListaEstadosFormando listaEstadosFormando)
        {
            try
            {
                _listaEstadosFormandoData.Remove(listaEstadosFormando);
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
