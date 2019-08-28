using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips; User Id=sa;Pwd=132";

        public List<CargosDomain> Listar()
        {
            List<CargosDomain> ListaDeCargos = new List<CargosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdCargo, Nome, Ativo from Cargos";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        CargosDomain cargo = new CargosDomain
                        {
                            IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                            Nome = sdr["Nome"].ToString(),
                            Ativo = Convert.ToInt32(sdr["Ativo"])
                        };
                        ListaDeCargos.Add(cargo);
                    }
                }
            }

            return ListaDeCargos;
        }

        public void Cadastrar(CargosDomain cargo)
        {
            string Query = "insert into Cargos (Nome) values(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", cargo.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public CargosDomain BuscarPorId(int id)
        {
            string Query = "select IdCargo, Nome, Ativo from Cargos where IdCargo = @IdCargo";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("IdCargo", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            CargosDomain cargo = new CargosDomain
                            {
                                IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                                Nome = sdr["Nome"].ToString(),
                                Ativo = Convert.ToInt32(sdr["Ativo"])
                            };
                            return cargo;
                        }
                    }
                    return null;
                }
            }
        }

        public void Atualizar(CargosDomain Cargo, int id)
        {
            string Query = "update Cargos set Nome = @Nome where IdCargo = @IdCargo";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", Cargo.Nome);
                cmd.Parameters.AddWithValue("@IdCargo", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
