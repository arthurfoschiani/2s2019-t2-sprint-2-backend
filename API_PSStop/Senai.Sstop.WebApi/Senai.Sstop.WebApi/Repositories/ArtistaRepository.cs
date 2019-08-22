using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa;Pwd=132";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT A.IdArtista, A.Nome, A.IdEstilosMusicais, E.Nome AS NomeEstilo FROM Artistas A INNER JOIN EstilosMusicais E ON A.IdEstilosMusicais = E.IdEstilosMusicais;";

                // abre a conexao
                con.Open();

                SqlDataReader sdr;

                // declara o comando
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain
                        {
                            IdArtista = Convert.ToInt32(sdr["IdArtista"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstilosMusicais"]),
                                Nome = sdr["NomeEstilo"].ToString()
                            }
                        };
                        artistas.Add(artista);
                    }

                }
            }
            return artistas;
        }

        public void Cadastrar(ArtistaDomain artista)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Artistas (Nome, IdEstilosMusicais) VALUES (@Nome, @IdEstilosMusicais);";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", artista.Nome);
                cmd.Parameters.AddWithValue("@IdEstilosMusicais", artista.EstiloId);
                con.Open();
                //quantidade de registros afetados
                cmd.ExecuteNonQuery();
            }
        }
    }
}
