using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public Fornecedores Fornecedores { get; set; }
    }
}
