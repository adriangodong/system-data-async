using System.Data.Async.Common;
using System.Data.Common;
using System.Data.SqlClient;

namespace System.Data.Async.SqlClient
{
    public class SqlCommandAsync : DbCommandAsync
    {

        internal SqlCommand sqlCommand;
        internal SqlConnectionAsync sqlConnectionAsync;

        public SqlCommandAsync()
            : this(new SqlCommand(), null)
        {
        }

        public SqlCommandAsync(string cmdText)
            : this(new SqlCommand(cmdText), null)
        {
        }

        public SqlCommandAsync(string cmdText, SqlConnectionAsync connection)
            : this(new SqlCommand(cmdText, connection.sqlConnection), connection)
        {
        }

        public SqlCommandAsync(string cmdText, SqlConnectionAsync connection, SqlTransaction transaction)
            : this(new SqlCommand(cmdText, connection.sqlConnection, transaction), connection)
        {
        }

        public SqlCommandAsync(SqlCommand sqlCommand, SqlConnectionAsync sqlConnectionAsync)
        {
            this.sqlCommand = sqlCommand;
            this.sqlConnectionAsync = sqlConnectionAsync;
        }

        protected override DbDataReaderAsync ExecuteDbDataReaderAsync(CommandBehavior behavior)
        {
            var dataReader = sqlCommand.ExecuteReader(behavior);

            return new SqlDataReaderAsync(dataReader, this);
        }

        public override void Cancel()
        {
            sqlCommand.Cancel();
        }

        public override int ExecuteNonQuery()
        {
            return sqlCommand.ExecuteNonQuery();
        }

        public override object ExecuteScalar()
        {
            return sqlCommand.ExecuteScalar();
        }

        public override void Prepare()
        {
            sqlCommand.Prepare();
        }

        public override string CommandText
        {
            get => sqlCommand.CommandText;
            set => sqlCommand.CommandText = value;
        }

        public override int CommandTimeout
        {
            get => sqlCommand.CommandTimeout;
            set => sqlCommand.CommandTimeout = value;
        }

        public override CommandType CommandType
        {
            get => sqlCommand.CommandType;
            set => sqlCommand.CommandType = value;
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get => sqlCommand.UpdatedRowSource;
            set => sqlCommand.UpdatedRowSource = value;
        }

        protected override DbConnection DbConnection
        {
            get => sqlCommand.Connection;
            set => sqlCommand.Connection = (SqlConnection)value;
        }

        protected override DbParameterCollection DbParameterCollection => sqlCommand.Parameters;

        protected override DbTransaction DbTransaction
        {
            get => sqlCommand.Transaction;
            set => sqlCommand.Transaction = (SqlTransaction)value;
        }

        public override bool DesignTimeVisible
        {
            get => sqlCommand.DesignTimeVisible;
            set => sqlCommand.DesignTimeVisible = value;
        }

        protected override DbParameter CreateDbParameter()
        {
            return sqlCommand.CreateParameter();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return sqlCommand.ExecuteReader(behavior);
        }

        protected override void Dispose(bool disposing)
        {
            sqlCommand.Dispose();
            sqlConnectionAsync.Dispose();
            base.Dispose(disposing);
        }

    }
}