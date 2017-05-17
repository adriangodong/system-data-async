using System.Data.Async.Common;
using System.Data.Common;
using System.Data.SqlClient;

namespace System.Data.Async.SqlClient
{
    public class SqlConnectionAsync : DbConnectionAsync
    {
        public SqlConnection SqlConnection { get; }

        public SqlConnectionAsync()
            : this(new SqlConnection())
        {
        }

        public SqlConnectionAsync(string connectionString)
            : this(new SqlConnection(connectionString))
        {
        }

        public SqlConnectionAsync(SqlConnection sqlConnection)
        {
            SqlConnection = sqlConnection;
        }

        protected override DbCommandAsync CreateDbCommandAsync()
        {
            var command = SqlConnection.CreateCommand();
            var asyncCommand = new SqlCommandAsync(command);
            return asyncCommand;
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            DbTransaction transaction = SqlConnection.BeginTransaction(isolationLevel);

            //   InnerConnection doesn't maintain a ref on the outer connection (this) and 
            //   subsequently leaves open the possibility that the outer connection could be GC'ed before the SqlTransaction
            //   is fully hooked up (leaving a DbTransaction with a null connection property). Ensure that this is reachable
            //   until the completion of BeginTransaction with KeepAlive
            GC.KeepAlive(this);

            return transaction;
        }

        public override void ChangeDatabase(string databaseName)
        {
            SqlConnection.ChangeDatabase(databaseName);
        }

        public override void Close()
        {
            SqlConnection.Close();
        }

        public override void Open()
        {
            SqlConnection.Open();
        }

        public override string ConnectionString
        {
            get => SqlConnection.ConnectionString;
            set => SqlConnection.ConnectionString = value;
        }

        public override string Database => SqlConnection.Database;

        public override ConnectionState State => SqlConnection.State;

        public override string DataSource => SqlConnection.DataSource;

        public override string ServerVersion => SqlConnection.ServerVersion;

    }
}