using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class LivrosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa;Pwd=132";

        public List<LivrosDomain> Listar()
        {
            List<LivrosDomain> listaDeLivros = new List<LivrosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select Livros.Titulo, Generos.Descricao, Autores.Nome from Livros inner join Generos on Livros.IdGenero = Generos.IdGenero inner join Autores on Livros.IdAutor = Autores.IdAutor";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        LivrosDomain livro = new LivrosDomain
                        {
                            IdLivro = Convert.ToInt32(rdr["IdLivro"]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdAutor = Convert.ToInt32(rdr["IdAutor"]),
                            IdGenero = Convert.ToInt32(rdr["Idgenero"])
                        };
                        listaDeLivros.Add(livro);
                    }
                }
            }
            return listaDeLivros;
        }

        public void Cadastrar(LivrosDomain livro)
        {
            ///string Query = "insert into EstilosMusicais (Nome) values ('" + estilo.Nome + "')";
            string Query = "insert into Livros (Titulo) values (@Titulo)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(LivrosDomain livrosDomain)
        {
            string Query = "update Livros set Titulo = @Titulo where IdLivro = @IdLivro";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", livrosDomain.Titulo),
                cmd.Parameters.AddWithValue("@IdLivro", livrosDomain.IdLivro);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "delete from Livros where IdLivros = @IdLivros";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdLivros", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
