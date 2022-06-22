using System.Data.SqlClient;
using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public class ProdutoRequisicaoSqlRepository : DBContext, IProdutoRequisicaoRepository
    {
        public void CreateProdutoRequi(ProdutoRequisicao preq)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO ProdutosRequisitados 
                    VALUES (@produtoRequisitado, @qtdRequisitada, @qtdEntregue, @idRequisicao, @idProduto)";

                cmd.Parameters.AddWithValue("@idRequisicao", preq.idRequisicao);
                cmd.Parameters.AddWithValue("@idProduto", preq.idProduto);
                cmd.Parameters.AddWithValue("@produtoRequisitado", preq.produtoRequisitado);
                cmd.Parameters.AddWithValue("@qtdRequisitada", preq.qtdRequisitada);
                cmd.Parameters.AddWithValue("@qtdEntregue", preq.qtdEntregue);

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

        public List<ProdutoRequisicao> ReadProdutoRequi()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM ProdutosRequisitados";

                SqlDataReader reader = cmd.ExecuteReader();

                List<ProdutoRequisicao> lista = new List<ProdutoRequisicao>();

                while (reader.Read())
                {
                    lista.Add(
                        new ProdutoRequisicao
                        {
                            idRequisicao = (int)reader["idPreq"],
                            idProduto = (int)reader["idProduto"],
                            produtoRequisitado = (string)reader["produtoRequisitado"],
                            qtdRequisitada = (int)reader["qtdRequisitada"],
                            qtdEntregue = (int)reader["qtdEntregue"],
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

        public ProdutoRequisicao ReadProdutoRequi(int idPreq)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM ProdutosRequisitados WHERE idPreq = @idPreq";
                cmd.Parameters.AddWithValue("@idRequisicao", idPreq);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new ProdutoRequisicao
                    {
                        idRequisicao = (int)reader["idPreq"],
                        idProduto = (int)reader["idProduto"],
                        produtoRequisitado = (string)reader["produtoRequisitado"],
                        qtdRequisitada = (int)reader["qtdRequisitada"],
                        qtdEntregue = (int)reader["qtdEntregue"],
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

        public void UpdateProdutoRequi(int idPreq, ProdutoRequisicao preq)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"UPDATE ProdutosRequisitados SET 
                    qtdRequisitada=@qtdRequisitada, qtdEntregue=@qtdEntregue,
                    idRequisicao=@idRequisicao, idProduto=@idProduto";
                    
                cmd.Parameters.AddWithValue("@idRequisicao", preq.idRequisicao);
                cmd.Parameters.AddWithValue("@idProduto", preq.idProduto);
                cmd.Parameters.AddWithValue("@produtoRequisitado", preq.produtoRequisitado);
                cmd.Parameters.AddWithValue("@qtdRequisitada", preq.qtdRequisitada);
                cmd.Parameters.AddWithValue("@qtdEntregue", preq.qtdEntregue);
                
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