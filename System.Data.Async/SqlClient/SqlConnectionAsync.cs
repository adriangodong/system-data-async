using System.Data.Async.Common;
using System.Data.Common;
using System.Data.SqlClient;

namespace System.Data.Async.SqlClient
{
    public class SqlConnectionAsync : DbConnectionAsync
    {

        internal SqlConnection sqlConnection;

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
            this.sqlConnection = sqlConnection;
        }

        protected override DbCommandAsync CreateDbCommandAsync()
        {
            var command = sqlConnection.CreateCommand();
            var asyncCommand = new SqlCommandAsync(command, this);
            return asyncCommand;
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            DbTransaction transaction = sqlConnection.BeginTransaction(isolationLevel);

            //   InnerConnection doesn't maintain a ref on the outer connection (this) and 
            //   subsequently leaves open the possibility that the outer connection could be GC'ed before the SqlTransaction
            //   is fully hooked up (leaving a DbTransaction with a null connection property). Ensure that this is reachable
            //   until the completion of BeginTransaction with KeepAlive
            GC.KeepAlive(this);

            return transaction;
        }

        public override void ChangeDatabase(string databaseName)
        {
            sqlConnection.ChangeDatabase(databaseName);
        }

        public override void Close()
        {
            sqlConnection.Close();
        }

        public override void Open()
        {
            sqlConnection.Open();
        }

        public override string ConnectionString
        {
            get => sqlConnection.ConnectionString;
            set => sqlConnection.ConnectionString = value;
        }

        public override string Database => sqlConnection.Database;

        public override ConnectionState State => sqlConnection.State;

        public override string DataSource => sqlConnection.DataSource;

        public override string ServerVersion => sqlConnection.ServerVersion;

        protected override void Dispose(bool disposing)
        {
            sqlConnection.Dispose();
            base.Dispose(disposing);
        }

    }
}