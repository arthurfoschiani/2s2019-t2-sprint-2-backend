using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CargosController : ControllerBase
    {
        CargosRepository cargosRepository = new CargosRepository();

        [Authorize]
        [HttpGet]
        public IEnumerable<CargosDomain> Listar()
        {
            return cargosRepository.Listar();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(CargosDomain cargosDomain)
        {
            cargosRepository.Cadastrar(cargosDomain);
            return Ok();
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            CargosDomain cargos = cargosRepository.BuscarPorId(id);
            if (cargos == null)
            {
                return NotFound();
            }
            return Ok(cargos);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(CargosDomain cargo, int id)
        {
            cargosRepository.Atualizar(cargo, id);
            if (cargo == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}