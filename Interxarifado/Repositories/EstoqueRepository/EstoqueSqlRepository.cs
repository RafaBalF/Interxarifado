using System.Data.SqlClient;
using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public class EstoqueSqlRepository : DBContext, IEstoqueRepository
    {
        public void CreateEstoque(Estoque produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO Estoque 
                    VALUES (@nome, @descricao, @qtdEstoque, @status)";

                cmd.Parameters.AddWithValue("@nome", produto.nome);
                cmd.Parameters.AddWithValue("@descricao", produto.descricao);
                cmd.Parameters.AddWithValue("@qtdEstoque", produto.qtdEstoque);
                cmd.Parameters.AddWithValue("@status", produto.status);

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

        public void DeleteEstoque(int idProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"DELETE FROM Estoque WHERE idProduto = @idProduto";

                cmd.Parameters.AddWithValue("@idProduto", idProduto);
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

        public List<Estoque> ReadEstoque()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Estoque";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Estoque> lista = new List<Estoque>();

                while (reader.Read())
                {
                    lista.Add(
                        new Estoque
                        {
                            idProduto = (int)reader["IdProduto"],
                            qtdEstoque = (int)reader["qtdEstoque"],
                            status = (int)reader["status"],
                            nome = (string)reader["nome"],
                            descricao = (string)reader["descricao"],
                            
                        }
                    );
                }

                return lista;
            }    
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
                return null;
            }
            finally
            {
                Dispose();
            }
            
        }

        public Estoque ReadEstoque(int idProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Estoque WHERE idProduto = @idProduto";
                cmd.Parameters.AddWithValue("@idProduto", idProduto);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Estoque
                    {
                        idProduto = (int)reader["idProduto"],
                        qtdEstoque = (int)reader["qtdEstoque"],
                        status = (int)reader["status"],
                        nome = (string)reader["nome"],
                        descricao = (string)reader["descricao"], 
                    };

                }
            return null;
            }    
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
                return null;
            }
            finally
            {
                Dispose();
            }

        }

        public void UpdateEstoque(int idProduto, Estoque produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"UPDATE Estoque SET 
                    nome=@nome, descricao=@descricao, qtdEstoque=@qtdEstoque, status=@status WHERE idProduto = @idProduto ";
                    
                cmd.Parameters.AddWithValue("@nome", produto.nome);
                cmd.Parameters.AddWithValue("@descricao", produto.descricao);
                cmd.Parameters.AddWithValue("@qtdEstoque", produto.qtdEstoque);
                cmd.Parameters.AddWithValue("@status", produto.status);
                cmd.Parameters.AddWithValue("@idProduto", idProduto);
                
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
            }
            finally
            {
                Dispose();
            }
        }
    }
}
