using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Dominios;
using Senai.Filmes.WebApi.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GenerosController : ControllerBase
    {
        GenerosRepositorio generosRepositorio = new GenerosRepositorio();

        [HttpGet]
        public IEnumerable<GenerosDominio> Listar()
        {
            return generosRepositorio.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            GenerosDominio Genero = generosRepositorio.BuscarPorId(id);
            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(GenerosDominio genero, int id)
        {
            generosRepositorio.Atualizar(genero, id);
            if (genero == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            generosRepositorio.Deletar(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar(GenerosDominio Genero)
        {
            generosRepositorio.Cadastrar(Genero);
            return Ok();
        }
    }
}
