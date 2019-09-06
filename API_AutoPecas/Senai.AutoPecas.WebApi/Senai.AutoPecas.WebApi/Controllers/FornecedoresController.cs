using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private IFornecedoresRepository FornecedoresRepository { get; set; }

        public FornecedoresController ()
        {
            FornecedoresRepository = new FornecedoresRepository();
        }
        
        public IActionResult Listar()
        {
            return Ok(FornecedoresRepository.Listar());
        }
    }
}