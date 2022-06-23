using System.Data.SqlClient;
using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public class FuncionarioSqlRepository : DBContext, IFuncionarioRepository
    {
        public void CreateFuncionario(Funcionario funcionario)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;           
            cmd.CommandText = @"exec sp_Add_Funcionario 
            @Nome , @CPF , @Salario , @Email , @Senha , @DataInicioContr ,
			@DataFimContr ,  @IdSetor";

            cmd.Parameters.AddWithValue("@Nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@CPF", funcionario.cpf);
            cmd.Parameters.AddWithValue("@Email", funcionario.email);
            cmd.Parameters.AddWithValue("@Senha", funcionario.senha);
            cmd.Parameters.AddWithValue("@Salario", funcionario.salario);
            cmd.Parameters.AddWithValue("@IdSetor", funcionario.idSetor);
            cmd.Parameters.AddWithValue("@DataInicioContr", funcionario.dataInicioContr );
            cmd.Parameters.AddWithValue("@DataFimContr", funcionario.dataFimContr);

            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Dispose();
            }
        }

        public void DeleteFuncionario(int id)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"exec sp_Del_Funcionario @id";

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
        

        public List<Funcionario> ReadFuncionario()
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM v_Funcionario";

            SqlDataReader reader = cmd.ExecuteReader();

            List<Funcionario> lista = new List<Funcionario>();

            while (reader.Read())
            {
                lista.Add(
                    new Funcionario
                    {
                        id = (int)reader["id"],
                        nome = (string)reader["nome"],
                        cpf = (string)reader["cpf"],
                        email = (string)reader["email"],
                        senha = (string)reader["senha"],
                        salario = (decimal)reader["salario"], 
                        idSetor = (int)reader["idSetor"],
                        dataInicioContr = (string)reader["dataInicioContr"],
                        dataFimContr = (string)reader["dataFimContr"],  
                    }
                );
            }

            return lista;
            }
            catch (Exception ex)
            {
                //logar erros
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        public List<Funcionario> ReadBySetor(int idSetor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM v_Funcionario WHERE idSetor = '@idSetor'";
            cmd.Parameters.AddWithValue("@idSetor", idSetor);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Funcionario> lista = new List<Funcionario>();

            while (reader.Read())
            {
                lista.Add(
                     new Funcionario
                    {
                        id = (int)reader["id"],
                        nome = (string)reader["nome"],
                        cpf = (string)reader["cpf"],
                        email = (string)reader["email"],
                        salario = (decimal)reader["salario"], 
                        idSetor = (int)reader["idSetor"],
                        dataInicioContr = (string)reader["dataInicioContr"],
                        dataFimContr = (string)reader["dataFimContr"], 
                    }
                );

            }
            return null; 
        }

        public Funcionario ReadFuncionario(int id)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM v_Funcionario WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                return new Funcionario
                {
                    id = (int)reader["id"],
                    nome = (string)reader["nome"],
                    cpf = (string)reader["cpf"],
                    email = (string)reader["email"],
                    salario = (decimal)reader["salario"], 
                    idSetor = (int)reader["idSetor"],
                    dataInicioContr = (string)reader["dataInicioContr"],
                    dataFimContr = (string)reader["dataFimContr"], 
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

        public void UpdateFuncionario(int id, Funcionario funcionario)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"EXEC sp_Upd_Funcionario @id @Nome, @cpf, @salario, @dataInicioContr, @dataFimContr,@idSetor";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
            cmd.Parameters.AddWithValue("@email", funcionario.email);
            cmd.Parameters.AddWithValue("@senha", funcionario.senha);
            cmd.Parameters.AddWithValue("@salario", funcionario.salario);
            cmd.Parameters.AddWithValue("@idSetor", funcionario.idSetor);
            cmd.Parameters.AddWithValue("@dataInicioContr", funcionario.dataInicioContr);
            cmd.Parameters.AddWithValue("@dataFimContr", funcionario.dataFimContr);
        
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