using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstilosRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilos);
                ctx.SaveChanges();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos estiloBuscado = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(estiloBuscado);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Estilos categorias)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // busco a categoria
                Estilos estiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == categorias.IdEstilo);
                // SET
                estiloBuscado.Nome = categorias.Nome;
                // atualizo no contexto
                ctx.Estilos.Update(estiloBuscado);
                // efetivo no database
                ctx.SaveChanges();
            }
        }
    }
}
