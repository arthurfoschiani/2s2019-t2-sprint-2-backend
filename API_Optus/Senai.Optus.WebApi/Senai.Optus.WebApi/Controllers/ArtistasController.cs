using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/json")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistasRepository artistasRepository = new ArtistasRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(artistasRepository.Listar());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Artistas artistas)
        {
            try
            {
                artistasRepository.Cadastrar(artistas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }
    }
}