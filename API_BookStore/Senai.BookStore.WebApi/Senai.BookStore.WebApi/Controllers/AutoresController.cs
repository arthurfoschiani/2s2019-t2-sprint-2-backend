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
    public class AutoresController : ControllerBase
    {
        AutoresRepository autoresRepository = new AutoresRepository();

        [HttpGet]
        public IEnumerable<AutoresDomain> Listar()
        {
            return autoresRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(AutoresDomain autores)
        {
            autoresRepository.Cadastrar(autores);
            return Ok();
        }
    }
}