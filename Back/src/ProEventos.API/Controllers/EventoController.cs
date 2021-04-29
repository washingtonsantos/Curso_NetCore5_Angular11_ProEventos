using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Entities;
using ProEventos.Infra;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ILogger<EventoController> _logger;
        private readonly ProEventosContext context;
        private readonly IEventoService _eventoService;

        public EventoController(ILogger<EventoController> logger, ProEventosContext context, IEventoService eventoService)
        {
            this.context = context;
            _logger = logger;
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);

                if (eventos == null) return NotFound("Nenhum registro encontrado!");

                return Ok(eventos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByIdAsync(id, true);

                if (evento == null) return NotFound("Evento por id não encontrado!");

                return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);

                if (evento == null) return NotFound("Eventos por tema não encontrados!");

                return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento eventoModel)
        {
            try
            {
                var evento = await _eventoService.AddEvento(eventoModel);

                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Evento eventoModel)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, eventoModel);

                if (evento == null) return BadRequest("Erro ao tentar atualizar evento.");

                return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletou = await _eventoService.DeleteEvento(id);

                if (!deletou) return BadRequest("Erro ao tentar deletar evento.");

                return Ok(deletou);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro: " + ex.Message);
            }
        }
    }
}
