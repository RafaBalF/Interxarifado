using System.Data.SqlClient;

namespace Interxarifado.Repositories
{
    public abstract class DBContext
    {
        private readonly string strConn = @"Data Source=192.168.40.34;
        Initial Catalog=Interxarifado;
        Persist Security Info=True;
        User ID = SA;
        Password =F4tecSQL!;";
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