using System;
using System.Data;
using System.Data.Async;
using System.Data.Async.SqlClient;
using System.Data.SqlClient;

namespace LocalDb
{
    public class LocalDbService
    {
        private const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;";
        private readonly string databaseName;

        public LocalDbService()
        {
            databaseName = Guid.NewGuid().ToString("N");

            using (var connection = new SqlConnectionAsync(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        $"CREATE DATABASE [{databaseName}];" +
                        $"ALTER DATABASE [{databaseName}] SET TRUSTWORTHY ON;";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        internal IDbConnectionAsync GetConnection()
        {
            return new SqlConnectionAsync(connectionString + "Database=" + databaseName);
        }

        public void Dispose()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                                          $"DROP DATABASE [{databaseName}]";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
