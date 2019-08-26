using Senai.Filmes.WebApi.Dominios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositorios
{
    public class FilmesRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_RoteiroFilmes; User Id=sa;Pwd=132";

        public List<FilmesDominio> Listar()
        {
            List<FilmesDominio> listaDeFilmes = new List<FilmesDominio>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select Filmes.IdFilme, Filmes.Titulo, Filmes.IdGenero, Generos.Nome from Filmes inner join Generos on Filmes.IdGenero = Generos.IdGenero";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmesDominio filmes = new FilmesDominio
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Nome = sdr["Titulo"].ToString(),
                            Generos = new GenerosDominio
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        listaDeFilmes.Add(filmes);
                    }
                }
            }
            return listaDeFilmes;
        }

        public FilmesDominio BuscarPorId(int id)
        {
            string Query = "select Filmes.IdFilme, Filmes.Titulo, Filmes.IdGenero, Generos.Nome from Filmes inner join Generos on Filmes.IdGenero = Generos.IdGenero where IdFilme = @IdFilme";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmesDominio listaDeFilmes = new FilmesDominio
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Nome = sdr["Titulo"].ToString(),
                                Generos = new GenerosDominio
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Nome"].ToString()
                                }
                            };
                            return listaDeFilmes;
                        }
                    }
                    return null;
                }

            }
        }

        public void Cadastrar(FilmesDominio filmes)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "insert into Filmes (Titulo, IdGenero) values(@Titulo, @IdGenero)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filmes.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", filmes.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
