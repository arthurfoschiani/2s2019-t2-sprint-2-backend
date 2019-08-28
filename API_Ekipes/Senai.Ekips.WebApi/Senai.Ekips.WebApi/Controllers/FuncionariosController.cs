using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionariosRepository funcionariosRepository = new FuncionariosRepository();

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Listar()
        {
            return funcionariosRepository.Listar();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(FuncionariosDomain funcionario, int id)
        {
            funcionariosRepository.Atualizar(funcionario, id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionariosRepository.Deletar(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionario)
        {
            funcionariosRepository.Cadastrar(funcionario);
            return Ok();
        }
    }
}