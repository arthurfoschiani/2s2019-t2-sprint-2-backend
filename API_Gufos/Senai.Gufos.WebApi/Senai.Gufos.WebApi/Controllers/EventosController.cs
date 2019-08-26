using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        EventoRepository eventoRepository = new EventoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(eventoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar (Eventos eventos)
        {
            try
            {
                eventoRepository.Cadastrar(eventos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }
    }
}