using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository categoriasRepository = new CategoriaRepository();

        /// <summary>
        /// Listar todas as categorias
        /// </summary>
        /// <returns>200 com a lista de categorias</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar ()
        {
            return Ok(categoriasRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar (Categorias categorias)
        {
            try
            {
                categoriasRepository.Cadastrar(categorias);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            Categorias categorias = categoriasRepository.BuscarPorId(id);
            if (categorias == null)
            {
                return NotFound();
            }
            return Ok(categorias);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            categoriasRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar (Categorias categorias)
        {
            try
            {
                Categorias CategoriasBuscada = categoriasRepository.BuscarPorId(categorias.IdCategoria);

                if (CategoriasBuscada == null)
                    return NotFound();

                categoriasRepository.Atualizar(categorias);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}