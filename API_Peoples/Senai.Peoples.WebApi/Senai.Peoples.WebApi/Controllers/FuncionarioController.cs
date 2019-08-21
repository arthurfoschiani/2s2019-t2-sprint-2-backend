using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Listar()
        {
            return funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            funcionarioRepository.Cadastrar(funcionarioDomain);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionario = funcionarioRepository.BuscarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (FuncionarioDomain funcionario, int id)
        {
            funcionarioRepository.Atualizar(funcionario, id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            FuncionarioDomain funcionario = funcionarioRepository.BuscarPorNome(nome);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpGet("ordenacao/{tipo}")]
        public IEnumerable<FuncionarioDomain> ListarOrdenadamente(string tipo)
        {
            return funcionarioRepository.ListarOrdenadamente(tipo);
        }
    }
}