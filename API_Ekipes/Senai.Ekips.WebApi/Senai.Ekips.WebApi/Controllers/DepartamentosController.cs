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
    public class DepartamentosController : ControllerBase
    {
        DepartamentosRepository departamentosRepository = new DepartamentosRepository();
        /// <summary>
        /// Listar Departamentos
        /// </summary>
        /// <returns>Lista de departamento</returns>
        [HttpGet]
        public IEnumerable<DepartamentosDomain> Listar()
        {
            return departamentosRepository.Listar();
        }
        /// <summary>
        /// Cadastrar Departamentos
        /// </summary>
        /// <param name="departamentosDomain"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(DepartamentosDomain departamentosDomain)
        {
            departamentosRepository.Cadastrar(departamentosDomain);
            return Ok();
        }
        /// <summary>
        /// Buscar departamentos por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Departamentos com aquele Id</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            DepartamentosDomain departamento = departamentosRepository.BuscarPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }
    }
}