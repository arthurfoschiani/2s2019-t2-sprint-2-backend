using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecasRepository PecasRepository { get; set; }

        public PecasController()
        {
            PecasRepository = new PecasRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecasRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pecas pecas = PecasRepository.BuscarPorId(id);
            if (pecas == null)
            {
                return NotFound();
            }
            return Ok(pecas);
        }

        [HttpPost]
        public IActionResult Cadastrar(Pecas pecas)
        {
            try
            {
                PecasRepository.Cadastrar(pecas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro" + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Pecas pecas, int id)
        {
            try
            {
                pecas.PecaId = id;
                Pecas PecasBuscada = PecasRepository.BuscarPorId(pecas.PecaId);

                if (PecasBuscada == null)
                    return NotFound();

                PecasRepository.Atualizar(pecas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PecasRepository.Deletar(id);
            return Ok();
        }
    }
}