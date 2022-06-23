using System.Data.SqlClient;

namespace Interxarifado.Repositories
{
    public abstract class DBContext
    {
        private readonly string strConn = @"Data Source=DESKTOP-2KN5ELF\SQLEXPRESS;
        Initial Catalog=Interxarifado;
        Persist Security Info=True;
        User ID = rafabalf;
        Password =1977;";
         // User Id=sa; Password=F4tecSQL!

         protected SqlConnection connection;

         public DBContext()
         {
             connection = new SqlConnection(strConn);
             connection.Open();
         }

         public void Dispose()
         {
             connection.Close();
         }
    }
}