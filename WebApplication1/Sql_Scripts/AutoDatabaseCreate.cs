using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace WebApplication1.Helpers
{
    public class AutoDatabaseCreate
    {
        public void MakeDatabase()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["CustomDatabase"].ConnectionString);
            var dbName = builder.InitialCatalog;
            var dbsource = builder.DataSource;
            var intregreted = builder.IntegratedSecurity;
            string query = "CREATE DATABASE " + dbName + " ;";
            string sqlConnectionString = @"Initial Catalog="+ dbName + "; Data Source="+ dbsource + "; Integrated Security=true;";
            string sqlConnectionString1 = "Data Source=" + dbsource + "; Initial Catalog=master ; Integrated Security=true;";
            SqlConnection connection = new SqlConnection(sqlConnectionString1);
            using (connection)
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();      
            }
            connection.Close();
            RunSqlScript(sqlConnectionString);
        }

        public void RunSqlScript(string conString)
        {
            string script = File.ReadAllText(@"Sql_Scripts\Updated_Database_Schema.sql");
            SqlConnection conn = new SqlConnection(conString);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(script);
            conn.Close();
        }


    }
}