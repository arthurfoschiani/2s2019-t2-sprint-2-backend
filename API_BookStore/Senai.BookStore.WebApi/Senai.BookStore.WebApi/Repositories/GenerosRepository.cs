using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GenerosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa;Pwd=132";

        public List<GenerosDomain> Listar()
        {
            List<GenerosDomain> listaDeGeneros = new List<GenerosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select IdGenero, Descricao from Generos";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GenerosDomain Generos = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Descricao = sdr["Descricao"].ToString()
                        };
                        listaDeGeneros.Add(Generos);
                    }
                }
            }
            return listaDeGeneros;
        }

        public void Cadastrar(GenerosDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "insert into Generos(Descricao) values (@Descricao)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", genero.Descricao);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
