using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async.Common
{
    public abstract class DbCommandAsync : DbCommand, IDbCommandAsync
    {
        public new IDataReaderAsync ExecuteReader() => ExecuteDbDataReaderAsync(CommandBehavior.Default);
        public new IDataReaderAsync ExecuteReader(CommandBehavior behavior) => ExecuteDbDataReaderAsync(behavior);
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior) => ExecuteDbDataReaderAsync(behavior);
        protected abstract DbDataReaderAsync ExecuteDbDataReaderAsync(CommandBehavior behavior);

        public new async Task<IDataReaderAsync> ExecuteReaderAsync() => await ExecuteDbDataReaderAsyncAsync(CommandBehavior.Default, CancellationToken.None);
        public new async Task<IDataReaderAsync> ExecuteReaderAsync(CancellationToken cancellationToken) => await ExecuteDbDataReaderAsyncAsync(CommandBehavior.Default, cancellationToken);
        public new async Task<IDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior) => await ExecuteDbDataReaderAsyncAsync(behavior, CancellationToken.None);
        public new async Task<IDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken) => await ExecuteDbDataReaderAsyncAsync(behavior, cancellationToken);
        protected override async Task<DbDataReader> ExecuteDbDataReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken) => await ExecuteDbDataReaderAsyncAsync(behavior, cancellationToken);

        protected virtual Task<DbDataReaderAsync> ExecuteDbDataReaderAsyncAsync(CommandBehavior behavior, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return Task.FromCanceled<DbDataReaderAsync>(new CancellationToken(true));
            }
            else
            {
                CancellationTokenRegistration registration = new CancellationTokenRegistration();
                if (cancellationToken.CanBeCanceled)
                {
                    registration = cancellationToken.Register(s => ((DbCommandAsync)s).CancelIgnoreFailure(), this);
                }

                try
                {
                    return Task.FromResult<DbDataReaderAsync>(ExecuteDbDataReaderAsync(behavior));
                }
                catch (Exception e)
                {
                    return Task.FromException<DbDataReaderAsync>(e);
                }
                finally
                {
                    registration.Dispose();
                }
            }
        }

        internal void CancelIgnoreFailure()
        {
            // This method is used to route CancellationTokens to the Cancel method.
            // Cancellation is a suggestion, and exceptions should be ignored
            // rather than allowed to be unhandled, as the exceptions cannot be 
            // routed to the caller. These errors will be observed in the regular 
            // method instead.
            try
            {
                Cancel();
            }
            catch (Exception)
            {
            }
        }
    }
}