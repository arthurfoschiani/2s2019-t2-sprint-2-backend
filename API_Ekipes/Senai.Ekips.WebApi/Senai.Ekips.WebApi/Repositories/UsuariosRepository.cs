using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuariosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips; User Id=sa;Pwd=132";

        public UsuariosDomain BuscarPorEmailESenhas(LoginViewModel login)
        {
            string Query = "select IdUsuario, Email, Senha, Permissao from Usuarios where Email = @Email and Senha = @Senha";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Senha", login.Senha);
                    sdr = cmd.ExecuteReader();
                    
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            UsuariosDomain usuario = new UsuariosDomain()
                            {
                                IdUsuario = Convert.ToInt32(sdr["IdUsuario"]),
                                Email = sdr["Email"].ToString(),
                                Senha = sdr["Senha"].ToString(),
                                Permissao = sdr["Permissao"].ToString()
                            };
                            return usuario;
                        }
                    }
                    return null;
                }
            }
        }
    }
}
