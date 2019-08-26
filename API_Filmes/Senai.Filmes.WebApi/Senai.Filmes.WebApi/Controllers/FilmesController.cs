using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Dominios;
using Senai.Filmes.WebApi.Repositorios;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmesController : ControllerBase
    {
        FilmesRepositorio filmesRepoistorio = new FilmesRepositorio();

        [HttpGet]
        public IEnumerable<FilmesDominio> Listar()
        {
            return filmesRepoistorio.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FilmesDominio Filmes = filmesRepoistorio.BuscarPorId(id);
            if (Filmes == null)
            {
                return NotFound();
            }
            return Ok(Filmes);
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmesDominio Filmes)
        {
            filmesRepoistorio.Cadastrar(Filmes);
            return Ok();
        }
    }
}