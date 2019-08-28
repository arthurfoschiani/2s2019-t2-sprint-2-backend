using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Domains
{
    public class FuncionariosDomain
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargos { get; set; }
        public int IdUsuarios { get; set; }

        public DepartamentosDomain Departamentos { get; set; }
        public CargosDomain Cargos { get; set; }
        public UsuariosDomain Usuarios { get; set; }
    }
}
