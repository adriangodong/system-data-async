using System.Collections;
using System.Data.Async.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async.SqlClient
{
    public class SqlConnectionAsync : DbConnectionAsync, ISqlConnectionAsync, IDisposable, ICloneable
    {

        private readonly SqlConnection sqlConnection;

        public SqlConnectionAsync()
            : this(new SqlConnection())
        {
        }

        public SqlConnectionAsync(string connectionString)
            : this(new SqlConnection(connectionString))
        {
        }

        public SqlConnectionAsync(string connectionString, SqlCredential credential)
            : this(new SqlConnection(connectionString, credential))
        {
        }

        public SqlConnectionAsync(SqlConnection sqlConnection) : base(sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        #region Public Properties

        public override string ConnectionString
        {
            get => sqlConnection.ConnectionString;
            set => sqlConnection.ConnectionString = value;
        }

        public override int ConnectionTimeout
        {
            get => sqlConnection.ConnectionTimeout;
        }

        public override string Database
        {
            get => sqlConnection.Database;
        }

        public override ConnectionState State
        {
            get => sqlConnection.State;
        }

        public override string ServerVersion
        {
            get => sqlConnection.ServerVersion;
        }

        public override string DataSource
        {
            get => sqlConnection.DataSource;
        }

        public string WorkstationId
        {
            get => sqlConnection.WorkstationId;
        }

        public bool StatisticsEnabled
        {
            get => sqlConnection.StatisticsEnabled;
            set => sqlConnection.StatisticsEnabled = value;
        }

        public int PacketSize
        {
            get => sqlConnection.PacketSize;
        }

        public bool FireInfoMessageEventOnUserErrors
        {
            get => sqlConnection.FireInfoMessageEventOnUserErrors;
            set => sqlConnection.FireInfoMessageEventOnUserErrors = value;
        }

        public Guid ClientConnectionId
        {
            get => sqlConnection.ClientConnectionId;
        }

        public SqlCredential Credential
        {
            get => sqlConnection.Credential;
            set => sqlConnection.Credential = value;
        }

        #endregion

        #region Public Fields

        public event SqlInfoMessageEventHandler InfoMessage;

        #endregion

        #region Public Methods

        public new SqlTransaction BeginTransaction() => sqlConnection.BeginTransaction();
        public new SqlTransaction BeginTransaction(IsolationLevel iso) => sqlConnection.BeginTransaction(iso);
        public SqlTransaction BeginTransaction(IsolationLevel iso, string transactionName) => sqlConnection.BeginTransaction(iso, transactionName);
        public SqlTransaction BeginTransaction(string transactionName) => sqlConnection.BeginTransaction(transactionName);
        public override void ChangeDatabase(string databaseName) => sqlConnection.ChangeDatabase(databaseName);
        public override void Close() => sqlConnection.Close();
        IDbCommand IDbConnection.CreateCommand() => CreateCommandAsync();
        IDbCommandAsync IDbConnectionAsync.CreateCommand() => CreateCommandAsync();
        ISqlCommandAsync ISqlConnectionAsync.CreateCommand() => CreateCommandAsync();
        public override IDbCommandAsync CreateCommand() => CreateCommandAsync();
        protected SqlCommandAsync CreateCommandAsync() => new SqlCommandAsync(sqlConnection.CreateCommand());
        public override void Open() => sqlConnection.Open();
        public new DataTable GetSchema() => sqlConnection.GetSchema();
        public new DataTable GetSchema(string collectionName) => sqlConnection.GetSchema(collectionName);
        public new DataTable GetSchema(string collectionName, string[] restrictionValues) => sqlConnection.GetSchema(collectionName, restrictionValues);
        public new Task OpenAsync(CancellationToken cancellationToken) => sqlConnection.OpenAsync(cancellationToken);
        public void ResetStatistics() => sqlConnection.ResetStatistics();
        public IDictionary RetrieveStatistics() => sqlConnection.RetrieveStatistics();

        #endregion

        public new void Dispose()
        {
            sqlConnection.Dispose();
            base.Dispose();
        }

        object ICloneable.Clone() => Clone();

        public SqlConnectionAsync Clone()
        {
            return new SqlConnectionAsync((SqlConnection)((ICloneable)sqlConnection).Clone());
        }

    }
}
