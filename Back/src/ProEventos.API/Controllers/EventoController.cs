using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EventoController> _logger;

        public EventoController(ILogger<EventoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Evento Get()
        {
            var rng = new Random();
            return new Evento()
            {
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "São Paulo",
                QtdPessoas =  200,
                Lote = "1",
                DataEvento = "01/05/2021",
                ImagemURL = "foto.png"
            };
        }

        [HttpPost]
        public void Post(){

        }

        [HttpPut]
        public void Put(int id){

        }

        [HttpDelete]
        public void Delete(int id){

        }

        
    }
}
