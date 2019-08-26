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
    public class GenerosController : ControllerBase
    {
        GenerosRepository  generosRepository = new GenerosRepository();

        [HttpGet]
        public IEnumerable<GenerosDomain> Listar()
        {
            return generosRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(GenerosDomain generos)
        {
            generosRepository.Cadastrar(generos);
            return Ok();
        }
    }
}