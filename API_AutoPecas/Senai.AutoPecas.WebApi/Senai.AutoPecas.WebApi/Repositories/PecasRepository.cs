using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository : IPecasRepository
    {
        public void Atualizar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas pecasBuscada = ctx.Pecas.FirstOrDefault(x => x.PecaId == pecas.PecaId);
                pecasBuscada.Codigo = pecas.Codigo;
                pecasBuscada.Descricao = pecas.Descricao;
                pecasBuscada.Peso = pecas.Peso;
                pecasBuscada.PrecoCusto = pecas.PrecoCusto;
                pecasBuscada.PrecoVenda = pecas.PrecoVenda;
                pecasBuscada.FornecedorId = pecas.FornecedorId;
                ctx.Pecas.Update(pecasBuscada);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.PecaId == id);
            }
        }

        public void Cadastrar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(pecas);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas pecasBuscada = ctx.Pecas.FirstOrDefault(x => x.PecaId == id);
                ctx.Pecas.Remove(pecasBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
    }
}
