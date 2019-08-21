using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class EstiloRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa;Pwd=132";

        List<EstiloDomain> estilos = new List<EstiloDomain>()
        {
            new EstiloDomain {IdEstilo = 1, Nome = "Rock"}
            , new EstiloDomain {IdEstilo = 2, Nome = "Pop"}
        };

        public void Cadastrar (EstiloDomain estilo)
        {
            ///string Query = "insert into EstilosMusicais (Nome) values ('" + estilo.Nome + "')";
            string Query = "insert into EstilosMusicais (Nome) values (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public EstiloDomain BuscarPorId (int id)
        {
            string Query = "SELECT IdEstilosMusicais, Nome FROM EstilosMusicais WHERE IdEstilosMusicais = @IdEstilosMusicais";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("IdEstilosMusicais", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            EstiloDomain estilo = new EstiloDomain
                            {
                            IdEstilo = Convert.ToInt32(sdr["IdEstilosMusicais"]),
                            Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                    }
                    return null;
                }

            }
        }

        public List<EstiloDomain> Listar ()
        {
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdEstilosMusicais, Nome FROM EstilosMusicais";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(rdr["IdEstilosMusicais"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    }
                }
            }

                return estilos;
        }

        public void Alterar (EstiloDomain estiloDomain)
        {
            string Query = "update EstilosMusicais set Nome = @Nome where IdEstilosMusicais = @IdEstilosMusicais";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstilosMusicais", estiloDomain.IdEstilo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar (int id)
        {
            string Query = "delete from EstilosMusicais where IdEstilosMusicais = @IdEstilosMusicais";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdEstilosMusicais", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
