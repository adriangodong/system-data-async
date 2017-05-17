using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDbCommandAsync : IDbCommand
    {
        Task<int> ExecuteNonQueryAsync();
        Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken);
        Task<DbDataReader> ExecuteReaderAsync();
        Task<DbDataReader> ExecuteReaderAsync(CommandBehavior behavior);
        Task<DbDataReader> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken);
        Task<DbDataReader> ExecuteReaderAsync(CancellationToken cancellationToken);
        Task<object> ExecuteScalarAsync();
        Task<object> ExecuteScalarAsync(CancellationToken cancellationToken);
    }
}