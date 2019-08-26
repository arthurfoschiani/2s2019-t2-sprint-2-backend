using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutoresRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa;Pwd=132";

        public List<AutoresDomain> Listar ()
        {
            List<AutoresDomain> listaDeAutores = new List<AutoresDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select IdAutor, Nome, Email, Ativo, DataNascimento from Autores";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        AutoresDomain Autores = new AutoresDomain
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString(),
                            Email = sdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"].ToString())
                        };
                        listaDeAutores.Add(Autores);
                    }
                }
            }
            return listaDeAutores;
        }

        public void Cadastrar(AutoresDomain autores)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "insert into Autores (Nome, Email, DataNascimento) values(@Nome, @Email, @DataNascimento)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", autores.Nome);
                cmd.Parameters.AddWithValue("@Email", autores.Email);
                cmd.Parameters.AddWithValue("@DataNascimento", autores.DataNascimento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
