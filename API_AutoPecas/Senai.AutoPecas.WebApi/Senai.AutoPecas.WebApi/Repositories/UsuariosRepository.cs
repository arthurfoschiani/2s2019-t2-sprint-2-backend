using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public Usuarios BuscarPorEmailSenha(LoginViewModel login)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Usuarios usuarios = ctx.Usuarios.Include(x => x.Fornecedores).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuarios == null)
                {
                    return null;
                }
                return usuarios;
            }
        }

        public void Cadastrar(Usuarios usuarios)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }

        public List<UsuarioViewModel> Listar()
        {
            List<UsuarioViewModel> usuariosViewModel = new List<UsuarioViewModel>();

            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                List<Usuarios> usuarios = ctx.Usuarios.ToList();
                foreach(var item in usuarios)
                {
                    UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
                    usuarioViewModel.UsuarioId = item.UsuarioId;
                    usuarioViewModel.Email = item.Email;
                    usuarioViewModel.Fornecedores = item.Fornecedores;
                    usuariosViewModel.Add(usuarioViewModel);
                }
                return usuariosViewModel;
            }
        }
    }
}
