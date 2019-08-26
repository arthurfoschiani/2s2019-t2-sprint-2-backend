using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LivrosController : ControllerBase
    {
        LivrosRepository livrosRepository = new LivrosRepository();

        [HttpGet]
        public IEnumerable<LivrosDomain> Listar()
        {
            return livrosRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(LivrosDomain livroDomain)
        {
            livrosRepository.Cadastrar(livroDomain);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(LivrosDomain livroDomain)
        {
            livrosRepository.Alterar(livroDomain);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            livrosRepository.Deletar(id);
            return Ok();
        }
    }
}