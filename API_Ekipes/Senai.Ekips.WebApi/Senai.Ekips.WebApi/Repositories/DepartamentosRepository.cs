using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips; User Id=sa;Pwd=132";

        public List<DepartamentosDomain> Listar()
        {
            List<DepartamentosDomain> ListaDeDepartamentos = new List<DepartamentosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdDepartamento, Nome from Departamentos";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        DepartamentosDomain departamento = new DepartamentosDomain
                        {
                            IdDepartamento = Convert.ToInt32(sdr["IdDepartamento"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        ListaDeDepartamentos.Add(departamento);
                    }
                }
            }

            return ListaDeDepartamentos;
        }

        public void Cadastrar(DepartamentosDomain departamento)
        {
            string Query = "insert into Departamentos (Nome) values(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", departamento.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DepartamentosDomain BuscarPorId(int id)
        {
            string Query = "select IdDepartamento, Nome from Departamentos where IdDepartamento = @IdDepartamento";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdDepartamento", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            DepartamentosDomain departamento = new DepartamentosDomain
                            {
                                IdDepartamento = Convert.ToInt32(sdr["IdDepartamento"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return departamento;
                        }
                    }
                    return null;
                }
            }
        }
    }
}
