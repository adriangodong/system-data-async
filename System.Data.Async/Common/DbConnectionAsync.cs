using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace System.Data.Async.Common
{
    public abstract class DbConnectionAsync : IDbConnectionAsync, IDisposable
    {

        private readonly DbConnection dbConnection;

        public DbConnectionAsync(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        #region Public Properties

        public abstract string ConnectionString { get; set; }
        public virtual int ConnectionTimeout => dbConnection.ConnectionTimeout;
        public abstract string Database { get; }
        public abstract ConnectionState State { get; }
        public abstract string ServerVersion { get; }
        public abstract string DataSource { get; }

        #endregion

        #region Public Fields

        public event StateChangeEventHandler StateChange;

        #endregion

        #region Public Methods

        IDbTransaction IDbConnection.BeginTransaction() => BeginTransaction();
        public DbTransaction BeginTransaction() => dbConnection.BeginTransaction();
        IDbTransaction IDbConnection.BeginTransaction(IsolationLevel isolationLevel) => BeginTransaction(isolationLevel);
        public DbTransaction BeginTransaction(IsolationLevel isolationLevel) => dbConnection.BeginTransaction(isolationLevel);
        public abstract void ChangeDatabase(string databaseName);
        public abstract void Close();
        IDbCommand IDbConnection.CreateCommand() => CreateCommand();
        public abstract IDbCommandAsync CreateCommand();
        public abstract void Open();
        public virtual void EnlistTransaction(Transaction transaction) => dbConnection.EnlistTransaction(transaction);
        public virtual DataTable GetSchema() => dbConnection.GetSchema();
        public virtual DataTable GetSchema(string collectionName) => dbConnection.GetSchema(collectionName);
        public virtual DataTable GetSchema(string collectionName, string[] restrictionValues) => dbConnection.GetSchema(collectionName, restrictionValues);
        public Task OpenAsync() => dbConnection.OpenAsync();
        public virtual Task OpenAsync(CancellationToken cancellationToken) => dbConnection.OpenAsync(cancellationToken);

        #endregion

        public void Dispose()
        {
            dbConnection.Dispose();
        }

    }
}
