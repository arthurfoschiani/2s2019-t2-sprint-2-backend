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

        public void Cadastrar(GenerosDominio generos)
        {
            string Query = "insert into Generos (Nome) values (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", generos.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar (GenerosDominio generos)
        {
            string Query = "update Generos set Nome = @Nome";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", generos.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
