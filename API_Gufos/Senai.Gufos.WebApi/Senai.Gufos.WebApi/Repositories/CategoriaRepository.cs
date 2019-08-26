using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class CategoriaRepository
    {
        // Não irá mudar o acesso ao banco de dados, nãi irei deixar de acessa-lo
        // O que irá mudar eh como eu faço esse acesso

        /// <summary>
        /// Listar todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public List<Categorias> Listar ()
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.ToList();
            }
        }

        public void Cadastrar (Categorias categorias)
        {
            using (GufosContext ctx = new GufosContext())
            {
                ctx.Categorias.Add(categorias);
                ctx.SaveChanges();
            }
        }

        public Categorias BuscarPorId (int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Deletar (int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias categoriaBuscada = ctx.Categorias.Find(id);
                ctx.Categorias.Remove(categoriaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Atualizar (Categorias categorias)
        {
            using (GufosContext ctx = new GufosContext())
            {
                // busco a categoria
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categorias.IdCategoria);
                // SET
                CategoriaBuscada.Nome = categorias.Nome;
                // atualizo no contexto
                ctx.Categorias.Update(CategoriaBuscada);
                // efetivo no database
                ctx.SaveChanges();
            }
        }
    }
}
