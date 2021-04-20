using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ILogger<EventoController> _logger;
        private readonly DataContext context;

        public EventoController(ILogger<EventoController> logger, DataContext context)
        {
            this.context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return this.context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return this.context.Eventos.FirstOrDefault(x => x.EventoId == id);
        }

        [HttpPost]
        public void Post()
        {

        }

        [HttpPut]
        public void Put(int id)
        {

        }

        [HttpDelete]
        public void Delete(int id)
        {

        }


    }
}
