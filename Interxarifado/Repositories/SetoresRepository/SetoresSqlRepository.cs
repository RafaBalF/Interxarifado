using System.Data.SqlClient;
using Interxarifado.Models;

namespace Interxarifado.Repositories
{
    public class SetoresSqlRepository : DBContext, ISetoresRepository
    {
        public void CreateSetores(Setores setor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO Setores 
                    VALUES (@setor, @responsavelSetor)";

                cmd.Parameters.AddWithValue("@responsavelSetor", setor.Id);
                cmd.Parameters.AddWithValue("@setor", setor.Setor);
                

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                // Logar os erros (Sentry, App Insights, etc)...
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Dispose();
            }
        }

        public void DeleteSetores(int IdSetor)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"DELETE FROM Setores WHERE IdSetor = @IdSetor";

                cmd.Parameters.AddWithValue("@IdSetor", IdSetor);

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

        public List<Setores>ReadSetores()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Setores";

                SqlDataReader reader = cmd.ExecuteReader();

                List<Setores> lista = new List<Setores>();

                while(reader.Read())
                {
                    lista.Add(
                        new Setores {
                            IdSetor = (int)reader["IdSetor"],
                            Setor = (string)reader["setor"],
                            Id = (int)reader["responsavelSetor"],  
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

        public List<Setores> ReadByResponsavel(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Setores WHERE responsavelSetor = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Setores> lista = new List<Setores>();

                while(reader.Read())
                {
                    lista.Add(
                        new Setores 
                        {
                            IdSetor = (int)reader["idSetor"],
                            Setor = (string)reader["setor"],
                            Id = (int)reader["responsavelSetor"],
                            
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

        public Setores ReadSetores(int IdSetor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT * FROM Setores WHERE idSetor = @IdSetor";

                cmd.Parameters.AddWithValue("@IdSetor", IdSetor);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    return new Setores {
                        IdSetor = (int)reader["IdSetor"],
                        Setor = (string)reader["Setor"],
                        Id = (int)reader["ResponsavelSetor"],
                        
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

        public void UpdateSetores(int IdSetor, Setores setor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"UPDATE Setores 
                    SET setor = @Setor, responsavelSetor = @ResponsavelSetor
                    WHERE idSetor = @IdSetor";

                
                cmd.Parameters.AddWithValue("@ResponsavelSetor", setor.Id);
                cmd.Parameters.AddWithValue("@Setor", setor.Setor);
                cmd.Parameters.AddWithValue("@IdSetor", setor.IdSetor);

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                // Logar os erros (Sentry, App Insights, etc)...
            }
            finally
            {
                Dispose();
            }
        }
    }
}