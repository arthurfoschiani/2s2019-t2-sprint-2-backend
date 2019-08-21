using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Peoples; User Id=sa;Pwd=132";

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> ListaDeFuncionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select IdFuncionario, Nome, Sobrenome from Funcionario";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        ListaDeFuncionarios.Add(funcionario);
                    }
                }
            }

            return ListaDeFuncionarios;
        }

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            string Query = "insert into Funcionario (Nome, Sobrenome) values(@Nome, @Sobrenome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@SobreNome", funcionario.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "select IdFuncionario, Nome, Sobrenome from Funcionario where IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionario, int id)
        {
            string Query = "update Funcionario set Nome = @Nome where IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "delete from Funcionario where IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public FuncionarioDomain BuscarPorNome(string nome)
        {
            string Query = "select IdFuncionario, Nome, Sobrenome from Funcionario where Nome = @Nome";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("Nome", nome);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public List<FuncionarioDomain> ListarOrdenadamente(string tipo)
        {
            List<FuncionarioDomain> ListaDeFuncionarios = new List<FuncionarioDomain>();

            if (tipo.Equals("asc"))
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string query = "select * from Funcionario order by Nome asc";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                                Nome = rdr["Nome"].ToString(),
                                Sobrenome = rdr["Sobrenome"].ToString()
                            };
                            ListaDeFuncionarios.Add(funcionario);
                        }
                    }
                }
            } else if (tipo.Equals("desc"))
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    string query = "select * from Funcionario order by Nome desc";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                                Nome = rdr["Nome"].ToString(),
                                Sobrenome = rdr["Sobrenome"].ToString()
                            };
                            ListaDeFuncionarios.Add(funcionario);
                        }
                    }
                }
            }
            return ListaDeFuncionarios;
        }
    }
}