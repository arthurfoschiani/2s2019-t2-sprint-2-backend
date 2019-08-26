using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Dominios
{
    public class FilmesDominio
    {
        public int IdFilme { get; set; }
        public string Nome { get; set; }
        public int IdGenero { get; set; }
        public GenerosDominio Generos { get; set; }
    }
}
