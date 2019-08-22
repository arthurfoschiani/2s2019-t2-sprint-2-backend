using Senai.Filmes.WebApi.Dominios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositorios
{
    public class GenerosRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_RoteiroFilmes; User Id=sa;Pwd=132";

        public List<GenerosDominio> Listar()
        {
            List<GenerosDominio> generos = new List<GenerosDominio>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select IdGenero, Nome from Generos";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GenerosDominio genero = new GenerosDominio
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public GenerosDominio BuscarPorId(int id)
        {
            string Query = "select IdGenero, Nome from Generos WHERE IdGenero = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GenerosDominio listaDeGeneros = new GenerosDominio
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return listaDeGeneros;
                        }
                    }
                    return null;
                }

            }
        }

        public void Atualizar(GenerosDominio genero, int id)
        {
            string Query = "update Generos set Nome = @Nome where IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "delete from Generos where IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(GenerosDominio generos)
        {
            string Query = "insert into Generos (Nome) values (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generos.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
