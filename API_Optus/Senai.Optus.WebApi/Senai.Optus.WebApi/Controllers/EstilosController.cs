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
    public class EstilosController : ControllerBase
    {
        EstilosRepository estilosRepository = new EstilosRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estilosRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilos)
        {
            try
            {
                estilosRepository.Cadastrar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro" + ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos estilos = estilosRepository.BuscarPorId(id);
            if (estilos == null)
            {
                return NotFound();
            }
            return Ok(estilos);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estilosRepository.Deletar(id);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estilos estilos)
        {
            try
            {
                Estilos EstilosBuscados = estilosRepository.BuscarPorId(estilos.IdEstilo);

                if (EstilosBuscados == null)
                    return NotFound();

                estilosRepository.Atualizar(estilos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/artistas")]
        public IActionResult BuscarArtistasAtravesDoEstilo (int id)
        {
            return Ok(estilosRepository.BuscarArtistasAtravesDoEstilo(id));
        }
    }
}