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

        [HttpPost]
        public IActionResult Cadastrar(GenerosDominio generosDominio)
        {
            generosRepositorio.Cadastrar(generosDominio);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id)
        {

        }
    }
}
