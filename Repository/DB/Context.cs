using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompraDapper.DB
{
    public class Context :IDisposable
    {
        SqlConnection connection;
        private static string connectionString { get; } = "Server=localhost,1433;Database=DB_LOJA;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        public SqlConnection GetConnection()
        {
            connection = new SqlConnection(connectionString);
            if (connection.State == System.Data.ConnectionState.Closed || connection == null)
            {
                connection.Open();
            }
            
            return connection;
        }
        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Dispose();
        }

    }
}
