using System.Data.Async.Common;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.Data.Async.SqlClient
{
    public class SqlCommandAsync : DbCommandAsync, ISqlCommandAsync, IDisposable, ICloneable
    {

        private readonly SqlCommand sqlCommand;

        public SqlCommandAsync()
            : this(new SqlCommand())
        {
        }

        public SqlCommandAsync(string cmdText)
            : this(new SqlCommand(cmdText))
        {
        }

        public SqlCommandAsync(string cmdText, SqlConnection sqlConnection)
            : this(new SqlCommand(cmdText, sqlConnection))
        {
        }

        public SqlCommandAsync(string cmdText, SqlConnection sqlConnection, SqlTransaction transaction)
            : this(new SqlCommand(cmdText, sqlConnection, transaction))
        {
        }

        public SqlCommandAsync(SqlCommand sqlCommand) : base(sqlCommand)
        {
            this.sqlCommand = sqlCommand;
            sqlCommand.StatementCompleted += SqlCommand_StatementCompleted;
        }

        private void SqlCommand_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            StatementCompleted?.Invoke(sender, e);
        }

        #region Public Properties

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

        IDbConnection IDbCommand.Connection
        {
            get => Connection;
            set => Connection = (SqlConnection)value;
        }

        public new SqlConnection Connection
        {
            get => sqlCommand.Connection;
            set => sqlCommand.Connection = value;
        }

        public new SqlParameterCollection Parameters
        {
            get => sqlCommand.Parameters;
        }

        public new SqlTransaction Transaction
        {
            get => sqlCommand.Transaction;
            set => sqlCommand.Transaction = (SqlTransaction)value;
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get => sqlCommand.UpdatedRowSource;
            set => sqlCommand.UpdatedRowSource = value;
        }

        public override bool DesignTimeVisible
        {
            get => sqlCommand.DesignTimeVisible;
            set => sqlCommand.DesignTimeVisible = value;
        }

        public SqlNotificationRequest Notification
        {
            get => sqlCommand.Notification;
            set => sqlCommand.Notification = value;
        }

        #endregion

        #region Public Fields

        public event StatementCompletedEventHandler StatementCompleted;

        #endregion

        #region Public Methods

        public override void Cancel() => sqlCommand.Cancel();
        public new SqlParameter CreateParameter() => sqlCommand.CreateParameter();
        public override int ExecuteNonQuery() => sqlCommand.ExecuteNonQuery();

        SqlDataReader ISqlCommandAsync.ExecuteReader() => ExecuteSqlReader();
        public override IDataReader ExecuteReader() => ExecuteSqlReader();
        protected SqlDataReader ExecuteSqlReader() => sqlCommand.ExecuteReader();

        SqlDataReader ISqlCommandAsync.ExecuteReader(CommandBehavior behavior) => ExecuteSqlReader(behavior);
        public override IDataReader ExecuteReader(CommandBehavior behavior) => ExecuteSqlReader(behavior);
        protected SqlDataReader ExecuteSqlReader(CommandBehavior behavior) => sqlCommand.ExecuteReader(behavior);

        public override object ExecuteScalar() => sqlCommand.ExecuteScalar();
        public override void Prepare() => sqlCommand.Prepare();
        public override Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken) => sqlCommand.ExecuteNonQueryAsync(cancellationToken);

        async Task<SqlDataReaderAsync> ISqlCommandAsync.ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken) => await ExecuteSqlReaderAsync(behavior, cancellationToken);
        public override async Task<IDbDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken) => await ExecuteSqlReaderAsync(behavior, cancellationToken);
        protected async Task<SqlDataReaderAsync> ExecuteSqlReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken) => new SqlDataReaderAsync(await sqlCommand.ExecuteReaderAsync(behavior, cancellationToken));

        async Task<SqlDataReaderAsync> ISqlCommandAsync.ExecuteReaderAsync(CommandBehavior behavior) => await ExecuteSqlReaderAsync(behavior);
        public override async Task<IDbDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior) => await ExecuteSqlReaderAsync(behavior);
        protected async Task<SqlDataReaderAsync> ExecuteSqlReaderAsync(CommandBehavior behavior) => new SqlDataReaderAsync(await sqlCommand.ExecuteReaderAsync(behavior));

        async Task<SqlDataReaderAsync> ISqlCommandAsync.ExecuteReaderAsync() => await ExecuteSqlReaderAsync();
        public override async Task<IDbDataReaderAsync> ExecuteReaderAsync() => await ExecuteSqlReaderAsync();
        protected async Task<SqlDataReaderAsync> ExecuteSqlReaderAsync() => new SqlDataReaderAsync(await sqlCommand.ExecuteReaderAsync());

        async Task<SqlDataReaderAsync> ISqlCommandAsync.ExecuteReaderAsync(CancellationToken cancellationToken) => await ExecuteSqlReaderAsync(cancellationToken);
        public override async Task<IDbDataReaderAsync> ExecuteReaderAsync(CancellationToken cancellationToken) => await ExecuteSqlReaderAsync(cancellationToken);
        protected async Task<SqlDataReaderAsync> ExecuteSqlReaderAsync(CancellationToken cancellationToken) => new SqlDataReaderAsync(await sqlCommand.ExecuteReaderAsync(cancellationToken));

        public override Task<object> ExecuteScalarAsync(CancellationToken cancellationToken) => sqlCommand.ExecuteScalarAsync(cancellationToken);
        public IAsyncResult BeginExecuteNonQuery() => sqlCommand.BeginExecuteNonQuery();
        public IAsyncResult BeginExecuteNonQuery(AsyncCallback callback, object stateObject) => sqlCommand.BeginExecuteNonQuery(callback, stateObject);
        public IAsyncResult BeginExecuteXmlReader(AsyncCallback callback, object stateObject) => sqlCommand.BeginExecuteXmlReader(callback, stateObject);
        public IAsyncResult BeginExecuteXmlReader() => sqlCommand.BeginExecuteXmlReader();
        public int EndExecuteNonQuery(IAsyncResult asyncResult) => sqlCommand.EndExecuteNonQuery(asyncResult);
        public XmlReader EndExecuteXmlReader(IAsyncResult asyncResult) => sqlCommand.EndExecuteXmlReader(asyncResult);
        public XmlReader ExecuteXmlReader() => sqlCommand.ExecuteXmlReader();
        public Task<XmlReader> ExecuteXmlReaderAsync(CancellationToken cancellationToken) => sqlCommand.ExecuteXmlReaderAsync(cancellationToken);
        public Task<XmlReader> ExecuteXmlReaderAsync() => sqlCommand.ExecuteXmlReaderAsync();
        public void ResetCommandTimeout() => sqlCommand.ResetCommandTimeout();

        #endregion

        public new void Dispose()
        {
            StatementCompleted -= SqlCommand_StatementCompleted;
            sqlCommand.Dispose();
            base.Dispose();
        }

        public object Clone()
        {
            return new SqlCommandAsync(sqlCommand.Clone());
        }

    }
}
