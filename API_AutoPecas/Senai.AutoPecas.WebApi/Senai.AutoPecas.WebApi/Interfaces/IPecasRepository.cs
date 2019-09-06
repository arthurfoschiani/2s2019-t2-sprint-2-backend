using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    interface IPecasRepository
    {
        List<Pecas> BuscarPorIdFornecedor(int id);
        Pecas BuscarPorId(int id);
        void Cadastrar(Pecas pecas);
        void Atualizar(Pecas pecas);
        void Deletar(int id);
    }
}
