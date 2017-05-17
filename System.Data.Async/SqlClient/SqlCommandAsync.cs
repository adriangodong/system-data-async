using System.Data.Async.Common;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async.SqlClient
{
    public class SqlCommandAsync : DbCommandAsync
    {

        public SqlCommand SqlCommand { get; }

        public SqlCommandAsync()
            : this(new SqlCommand())
        {
        }

        public SqlCommandAsync(string cmdText)
            : this(new SqlCommand(cmdText))
        {
        }

        public SqlCommandAsync(string cmdText, SqlConnectionAsync connection)
            : this(new SqlCommand(cmdText, connection.SqlConnection))
        {
        }

        public SqlCommandAsync(string cmdText, SqlConnectionAsync connection, SqlTransaction transaction)
            : this(new SqlCommand(cmdText, connection.SqlConnection, transaction))
        {
        }

        public SqlCommandAsync(SqlCommand sqlCommand)
        {
            SqlCommand = sqlCommand;
        }

        protected override DbDataReaderAsync ExecuteDbDataReaderAsync(CommandBehavior behavior)
        {
            var dataReader = SqlCommand.ExecuteReader(behavior);

            return new SqlDataReaderAsync(dataReader);
        }

        public override void Cancel()
        {
            SqlCommand.Cancel();
        }

        public override int ExecuteNonQuery()
        {
            return SqlCommand.ExecuteNonQuery();
        }

        public override object ExecuteScalar()
        {
            return SqlCommand.ExecuteScalar();
        }

        public override void Prepare()
        {
            SqlCommand.Prepare();
        }

        public override string CommandText
        {
            get => SqlCommand.CommandText;
            set => SqlCommand.CommandText = value;
        }

        public override int CommandTimeout
        {
            get => SqlCommand.CommandTimeout;
            set => SqlCommand.CommandTimeout = value;
        }

        public override CommandType CommandType
        {
            get => SqlCommand.CommandType;
            set => SqlCommand.CommandType = value;
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get => SqlCommand.UpdatedRowSource;
            set => SqlCommand.UpdatedRowSource = value;
        }

        protected override DbConnection DbConnection
        {
            get => SqlCommand.Connection;
            set => SqlCommand.Connection = (SqlConnection)value;
        }

        protected override DbParameterCollection DbParameterCollection => SqlCommand.Parameters;

        protected override DbTransaction DbTransaction
        {
            get => SqlCommand.Transaction;
            set => SqlCommand.Transaction = (SqlTransaction)value;
        }

        public override bool DesignTimeVisible
        {
            get => SqlCommand.DesignTimeVisible;
            set => SqlCommand.DesignTimeVisible = value;
        }

        protected override DbParameter CreateDbParameter()
        {
            return SqlCommand.CreateParameter();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return SqlCommand.ExecuteReader(behavior);
        }
    }
}