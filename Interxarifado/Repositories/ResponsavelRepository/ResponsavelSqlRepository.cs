using System.Data.SqlClient;
using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public class ResponsavelSqlRepository : DBContext, IResponsavelRepository
    {
         public ResponsavelSetor ReadResponsavel(string email,string senha)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM v_ResponsavelSetor WHERE email=@email and senha=@senha";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                return new ResponsavelSetor
                {
                    id = (int)reader["id"],
                    nome = (string)reader["nome"],
                    cpf = (string)reader["cpf"],
                    salario = (decimal)reader["salario"], 
                    nmrConcurso = (int)reader["nmrConcurso"],
                    email=(string)reader["email"],
                    senha=(string)reader["senha"] 
                };

            }
            return null;
            }
            catch (Exception ex)
            {
                //logar erros
                return null;
            }
            finally
            {
                Dispose();
            }
        }
        public void CreateResponsavel(ResponsavelSetor responsavel)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"EXEC sp_Add_ResponsavelSetor 
                @Nome, @CPF, @Salario, @Email, @Senha, @NmrConcurso";

            cmd.Parameters.AddWithValue("@Nome", responsavel.nome);
            cmd.Parameters.AddWithValue("@CPF", responsavel.cpf);
            cmd.Parameters.AddWithValue("@Salario", responsavel.salario);
            cmd.Parameters.AddWithValue("@NmrConcurso", responsavel.nmrConcurso);
            cmd.Parameters.AddWithValue("@Email", responsavel.email);
            cmd.Parameters.AddWithValue("@Senha", responsavel.senha);

            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //logar erros
            }
            finally
            {
                Dispose();
            }
        }

        public void DeleteResponsavel(int id)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"EXEC sp_Del_ResponsavelSetor @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //logar erros
            }
            finally
            {
                Dispose();
            }
        }

        public List<ResponsavelSetor> ReadResponsavel()
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM v_ResponsavelSetor";

            SqlDataReader reader = cmd.ExecuteReader();

            List<ResponsavelSetor> lista = new List<ResponsavelSetor>();

            while (reader.Read())
            {
                lista.Add(
                    new ResponsavelSetor
                    {
                        id = (int)reader["id"],
                        nome = (string)reader["Nome"],
                        cpf = (string)reader["cpf"],
                        salario = (decimal)reader["salario"], 
                        nmrConcurso = reader["nmrConcurso"]!=DBNull.Value?(int)reader["nmrConcurso"]:0  
                    }
                );
            }

            return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //logar erros
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        public ResponsavelSetor ReadResponsavel(int id)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM v_ResponsavelSetor WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                return new ResponsavelSetor
                {
                    id = (int)reader["id"],
                    nome = (string)reader["nome"],
                    cpf = (string)reader["cpf"],
                    salario = (decimal)reader["salario"], 
                    nmrConcurso = (int)reader["nmrConcurso"], 
                };

            }
            return null;
            }
            catch (Exception ex)
            {
                //logar erros
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        public void UpdateResponsavel(int id, ResponsavelSetor responsavel)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"EXEC sp_Upd_ResponsavelSetor SET 
                nome=@nome, cpf=@cpf, salario=@salario, nmrConcurso=@nmrConcurso) WHERE id =@id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@nome", responsavel.nome);
            cmd.Parameters.AddWithValue("@cpf", responsavel.cpf);
            cmd.Parameters.AddWithValue("@salario", responsavel.salario);
            cmd.Parameters.AddWithValue("@nmrConcurso", responsavel.nmrConcurso);
        
            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //logar erros
            }
            finally
            {
                Dispose();
            }
        }
    }
}