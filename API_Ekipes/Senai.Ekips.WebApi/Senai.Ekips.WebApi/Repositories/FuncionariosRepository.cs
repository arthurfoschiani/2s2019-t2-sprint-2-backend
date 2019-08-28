using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionariosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips; User Id=sa;Pwd=132";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> ListaDeFuncionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select f.IdFuncionario, f.Nome, f.CPF, f.DataNascimento, f.Salario, f.IdDepartamento, f.IdCargo, f.IdUsuario, u.Email, u.Senha, u.Permissao, d.Nome, c.Nome, c.Ativo from Funcionarios f inner join Usuarios u on f.IdUsuario = u.IdUsuario inner join Departamentos d on f.IdDepartamento = d.IdDepartamento inner join Cargos c on f.IdCargo = c.IdCargo";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            CPF = sdr["CPF"].ToString(),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
                            Salario = Convert.ToDouble(sdr["Salario"]),
                            Departamentos = new DepartamentosDomain
                            {
                                IdDepartamento = Convert.ToInt32(sdr["IdDepartamento"]),
                                Nome = sdr["Nome"].ToString()
                            },
                            Cargos = new CargosDomain
                            {
                                IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                                Nome = sdr["Nome"].ToString(),
                                Ativo = Convert.ToInt32(sdr["Ativo"])
                            },
                            IdUsuarios = Convert.ToInt32(sdr["IdUsuario"])

                        };
                        ListaDeFuncionarios.Add(funcionario);
                    }
                }
            }

            return ListaDeFuncionarios;
        }

        public void Cadastrar(FuncionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "insert into Funcionarios (Nome, CPF, DataNascimento, Salario, IdDepartamento, IdCargo, IdUsuario) values(@Nome, @CPF, @DataNascimento, @Salario, @IdDepartamento, @IdCargo, @IdUsuario)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                cmd.Parameters.AddWithValue("@CPF", funcionarios.CPF);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionarios.DataNascimento);
                cmd.Parameters.AddWithValue("@Salario", funcionarios.Salario);
                cmd.Parameters.AddWithValue("@IdDepartamento", funcionarios.IdDepartamento);
                cmd.Parameters.AddWithValue("@IdCargo", funcionarios.IdCargos);
                cmd.Parameters.AddWithValue("@IdUsuario", funcionarios.IdUsuarios);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(FuncionariosDomain funcionarios, int id)
        {
            string Query = "update Funcionarios set Nome = @Nome where IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "delete from Funcionarios where IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
