using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async.Common
{
    public abstract class DbCommandAsync : IDbCommandAsync, IDisposable
    {

        private readonly DbCommand dbCommand;

        public DbCommandAsync(DbCommand dbCommand)
        {
            this.dbCommand = dbCommand;
        }

        #region Public Properties

        public abstract string CommandText { get; set; }
        public abstract int CommandTimeout { get; set; }
        public abstract CommandType CommandType { get; set; }

        IDbConnection IDbCommand.Connection
        {
            get => Connection;
            set => Connection = (DbConnection)value;
        }

        public DbConnection Connection
        {
            get => dbCommand.Connection;
            set => dbCommand.Connection = value;
        }

        IDataParameterCollection IDbCommand.Parameters
        {
            get => Parameters;
        }

        public DbParameterCollection Parameters
        {
            get => dbCommand.Parameters;
        }

        IDbTransaction IDbCommand.Transaction
        {
            get => Transaction;
            set => Transaction = (DbTransaction)value;
        }

        public DbTransaction Transaction
        {
            get => dbCommand.Transaction;
            set => dbCommand.Transaction = value;
        }

        public abstract UpdateRowSource UpdatedRowSource { get; set; }
        public abstract bool DesignTimeVisible { get; set; }

        #endregion

        #region Public Methods

        public abstract void Cancel();
        public IDbDataParameter CreateParameter() => dbCommand.CreateParameter();
        public abstract int ExecuteNonQuery();
        public abstract IDataReader ExecuteReader();
        public abstract IDataReader ExecuteReader(CommandBehavior behavior);
        public abstract object ExecuteScalar();
        public abstract void Prepare();
        public Task<int> ExecuteNonQueryAsync() => dbCommand.ExecuteNonQueryAsync();
        public virtual Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken) => dbCommand.ExecuteNonQueryAsync(cancellationToken);
        public abstract Task<IDbDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken);
        public abstract Task<IDbDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior);
        public abstract Task<IDbDataReaderAsync> ExecuteReaderAsync();
        public abstract Task<IDbDataReaderAsync> ExecuteReaderAsync(CancellationToken cancellationToken);
        public Task<object> ExecuteScalarAsync() => dbCommand.ExecuteScalarAsync();
        public virtual Task<object> ExecuteScalarAsync(CancellationToken cancellationToken) => dbCommand.ExecuteScalarAsync(cancellationToken);

        #endregion

        public void Dispose()
        {
            dbCommand.Dispose();
        }

    }
}
