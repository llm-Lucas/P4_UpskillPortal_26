using Microsoft.AspNetCore.Mvc;
using PortalUpskill.Data.DataAccessDapper;
using PortalUpskill.Data.Models;

namespace UpskillPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaltaController : Controller
    {
        private readonly IFaltaData _faltaData;

        public FaltaController(IFaltaData faltaData)
        {
            _faltaData = faltaData;
        }

        // ── Leitura ─────────────────────────────────────────────

        [HttpGet("get_all")]
        public IActionResult GetAll()
        {
            try { return Ok(_faltaData.GetAll()); }
            catch { return StatusCode(500, "Internal server error"); }
        }

        [HttpGet("get_by_id")]
        public IActionResult GetById([FromHeader] int id)
        {
            try
            {
                var falta = _faltaData.GetById(id);
                return falta == null ? NotFound() : Ok(falta);
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        [HttpGet("get_by_aula_id")]
        public IActionResult GetByAulaId([FromHeader] int aulaId)
        {
            try { return Ok(_faltaData.GetByAulaId(aulaId)); }
            catch { return StatusCode(500, "Internal server error"); }
        }

        /// <summary>
        /// Devolve as faltas de um formando com Aula e Módulo incluídos.
        /// Usado pela PaginaFaltasFormando.
        /// </summary>
        [HttpGet("get_by_formando_id")]
        public IActionResult GetByFormandoId([FromHeader] int formandoId)
        {
            try { return Ok(_faltaData.GetByFormandoId(formandoId)); }
            catch { return StatusCode(500, "Internal server error"); }
        }

        /// <summary>
        /// Lista todas as faltas com Estado = 'Pendente'.
        /// Usado em ValidarJustificacoes pelo admin/coordenador.
        /// </summary>
        [HttpGet("pendentes")]
        public IActionResult GetFaltasPendentes()
        {
            try { return Ok(_faltaData.GetFaltasPendentes()); }
            catch { return StatusCode(500, "Internal server error"); }
        }

        // ── Criação ─────────────────────────────────────────────

        [HttpPost("create_single")]
        public IActionResult Create([FromBody] Falta falta)
        {
            try
            {
                if (falta == null) return BadRequest("Falta object is null");
                _faltaData.Create(falta);
                return CreatedAtAction(nameof(GetById), new { id = falta.Id }, falta);
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        [HttpPost("create_multiple")]
        public IActionResult Create([FromBody] List<Falta> faltas)
        {
            try
            {
                if (faltas == null || !faltas.Any()) return BadRequest("Falta list is null or empty");
                _faltaData.Create(faltas);
                return CreatedAtAction(nameof(GetAll), faltas);
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        // ── Atualização ─────────────────────────────────────────

        [HttpPut("update_single")]
        public IActionResult Update([FromBody] Falta falta)
        {
            try
            {
                if (falta == null) return BadRequest("Falta object is null");
                _faltaData.Update(falta);
                return NoContent();
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        [HttpPut("update_multiple")]
        public IActionResult Update([FromBody] List<Falta> faltas)
        {
            try
            {
                if (faltas == null || !faltas.Any()) return BadRequest("Falta list is null or empty");
                _faltaData.Update(faltas);
                return NoContent();
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        /// <summary>
        /// Chamado pelo formando para submeter a justificação.
        /// Recebe o caminho do anexo (já gravado no servidor) e a observação escrita.
        /// Define o Estado como 'Pendente'.
        /// </summary>
        [HttpPut("{id}/submeter-justificacao")]
        public IActionResult SubmeterJustificacao(int id, [FromQuery] string caminhoAnexo, [FromQuery] string observacoes)
        {
            if (string.IsNullOrEmpty(caminhoAnexo))
                return BadRequest("O caminho do anexo não pode ser vazio.");

            try
            {
                _faltaData.SubmeterJustificacao(id, caminhoAnexo, observacoes ?? "");
                return Ok(new { message = "Justificação submetida e a aguardar validação." });
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        /// <summary>
        /// Chamado pelo formando para cancelar uma submissão ainda Pendente.
        /// Repõe a falta ao estado inicial para que possa re-submeter.
        /// A remoção física do ficheiro deve ser feita pelo cliente antes desta chamada.
        /// </summary>
        [HttpPut("{id}/cancelar-justificacao")]
        public IActionResult CancelarJustificacao(int id)
        {
            try
            {
                _faltaData.CancelarJustificacao(id);
                return Ok(new { message = "Submissão cancelada. Pode submeter uma nova justificação." });
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        /// <summary>
        /// Chamado pelo admin/coordenador para aprovar ou rejeitar uma justificação.
        /// estado: "Justificada" ou "Injustificada"
        /// </summary>
        [HttpPut("{id}/decidir")]
        public IActionResult DecidirFalta(
            int id,
            [FromQuery] string estado,
            [FromQuery] bool justificada,
            [FromQuery] string? observacoes = null)
        {
            if (estado != "Justificada" && estado != "Injustificada")
                return BadRequest("Estado inválido. Use 'Justificada' ou 'Injustificada'.");

            try
            {
                _faltaData.AtualizarEstadoFalta(id, estado, justificada, observacoes ?? "");
                return Ok(new { message = $"Falta atualizada para '{estado}' com sucesso." });
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        // ── Eliminação ──────────────────────────────────────────

        [HttpDelete("delete_single")]
        public IActionResult Delete([FromBody] Falta falta)
        {
            try
            {
                if (falta == null) return BadRequest("Falta object is null");
                _faltaData.Remove(falta);
                return NoContent();
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        [HttpDelete("delete_multiple")]
        public IActionResult Delete([FromBody] List<Falta> faltas)
        {
            try
            {
                if (faltas == null || !faltas.Any()) return BadRequest("Falta list is null or empty");
                _faltaData.Remove(faltas);
                return NoContent();
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        [HttpDelete("delete_by_id")]
        public IActionResult DeleteById([FromHeader] int id)
        {
            try
            {
                var falta = _faltaData.GetById(id);
                if (falta == null) return NotFound();
                _faltaData.Remove(id);
                return NoContent();
            }
            catch { return StatusCode(500, "Internal server error"); }
        }

        // ── Acesso ao ficheiro ───────────────────────────────────

        /// <summary>
        /// Serve o ficheiro de justificação directamente ao browser.
        /// Usado em ValidarJustificacoes para o admin/coordenador ver o documento.
        /// </summary>
        [HttpGet("ver_anexo")]
        public IActionResult VerAnexo([FromQuery] string caminho)
        {
            if (string.IsNullOrEmpty(caminho) || !System.IO.File.Exists(caminho))
                return NotFound("Ficheiro não encontrado ou caminho inválido.");

            var bytes = System.IO.File.ReadAllBytes(caminho);
            string contentType = Path.GetExtension(caminho).ToLower() switch
            {
                ".pdf" => "application/pdf",
                ".png" => "image/png",
                ".jpg" or ".jpeg" => "image/jpeg",
                _ => "application/octet-stream"
            };

            return File(bytes, contentType, Path.GetFileName(caminho));
        }
    }
}