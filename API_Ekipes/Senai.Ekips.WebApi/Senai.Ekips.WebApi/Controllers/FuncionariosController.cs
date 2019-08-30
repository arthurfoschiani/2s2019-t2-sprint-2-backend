using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            string EmailBuscado = User.FindFirst(ClaimTypes.Email)?.Value;
            string Permissao = User.FindFirst(ClaimTypes.Role)?.Value;
            string IdRecuperado = User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            int id = int.Parse(IdRecuperado);
            if (Permissao == "ADMINISTRADOR")
            {
                return Ok(funcionariosRepository.Listar());
            } else if (Permissao == "COMUM")
            {
                return Ok(funcionariosRepository.BuscarPorId(id));
            }
            return BadRequest();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
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

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionariosRepository.Deletar(id);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionario)
        {
            funcionariosRepository.Cadastrar(funcionario);
            return Ok();
        }
    }
}