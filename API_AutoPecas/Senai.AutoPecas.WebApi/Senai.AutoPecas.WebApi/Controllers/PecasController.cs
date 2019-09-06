using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            int id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "FornecedorId").Value);
            return Ok(PecasRepository.BuscarPorIdFornecedor(id));
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Pecas pecas, int id)
        {
            try
            {
                int UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "FornecedorId").Value);
                pecas.PecaId = id;
                Pecas PecasBuscada = PecasRepository.BuscarPorId(pecas.PecaId);
                if (PecasBuscada == null)
                    return NotFound();

                if (UsuarioId == PecasBuscada.FornecedorId)
                {
                    PecasRepository.Atualizar(pecas);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um problema: " + ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PecasRepository.Deletar(id);
            return Ok();
        }
    }
}