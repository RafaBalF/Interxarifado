using System.Data.SqlClient;
using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public class RequisicaoSqlRepository : DBContext, IRequisicaoRepository
    {
        public void CreateRequisicao(Requisicao requisicao)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Requisicao 
                VALUES (@dataRequisicao, @setorRequisitante)";

            cmd.Parameters.AddWithValue("@setorRequisitante", requisicao.setorRequisitante);
            cmd.Parameters.AddWithValue("@dataRequisicao", requisicao.dataRequisicao);

            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //logar erros
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Dispose();
            }
        }

        public void DeleteRequisicao(int idRequisicao)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Requisicao WHERE idRequisicao = @idRequisicao";

            cmd.Parameters.AddWithValue("@idRequisicao", idRequisicao);
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

        public List<Requisicao> ReadRequisicao()
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Requisicao";

            SqlDataReader reader = cmd.ExecuteReader();

            List<Requisicao> lista = new List<Requisicao>();

            while (reader.Read())
            {
                lista.Add(
                    new Requisicao
                    {
                        idRequisicao = (int)reader["idRequisicao"],  
                        dataRequisicao = (string)reader["dataRequisicao"], 
                        setorRequisitante = (int)reader["setorRequisitante"],
                    }
                );
            }

            return lista;
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

        public List<Requisicao> ReadBySetor(int IdSetor)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Requisicao WHERE setorRequisitante = @IdSetor";
            cmd.Parameters.AddWithValue("@IdSetor", IdSetor);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Requisicao> lista = new List<Requisicao>();

            while (reader.Read())
            {
                lista.Add(
                     new Requisicao
                    {
                        idRequisicao = (int)reader["idRequisicao"], 
                        dataRequisicao = (string)reader["dataRequisicao"], 
                        setorRequisitante = (int)reader["setorRequisitante"],
                    }
                );

            }
            return lista;
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

        

        public Requisicao ReadRequisicao(int idRequisicao)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Requisicao WHERE idRequisicao = @idRequisicao";

            cmd.Parameters.AddWithValue("@idRequisicao", idRequisicao);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                return new Requisicao
                {
                    idRequisicao = (int)reader["idRequisicao"],
                    dataRequisicao = (string)reader["dataRequisicao"], 
                    setorRequisitante = (int)reader["setorRequisitante"],
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

        public void UpdateRequisicao(int idRequisicao, Requisicao requisicoes)
        {
            try{
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Requisicao
                SET dataRequisicao=@dataRequisicao, setorRequisitante=@setorRequisitante
                WHERE idRequisicao =@idRequisicao";


            cmd.Parameters.AddWithValue("@idRequisicao", requisicoes.idRequisicao);

            
            cmd.Parameters.AddWithValue("@setorRequisitante", requisicoes.setorRequisitante);
            cmd.Parameters.AddWithValue("@dataRequisicao", requisicoes.dataRequisicao);
        
            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //logar erros
            }
            finally
            {
                Dispose();
            }
        }
    }
}