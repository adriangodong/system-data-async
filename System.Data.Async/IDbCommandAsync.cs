using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDbCommandAsync : IDbCommand
    {
        Task<int> ExecuteNonQueryAsync();
        Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken);
        new IDataReaderAsync ExecuteReader();
        new IDataReaderAsync ExecuteReader(CommandBehavior behavior);
        Task<IDataReaderAsync> ExecuteReaderAsync();
        Task<IDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior);
        Task<IDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken);
        Task<IDataReaderAsync> ExecuteReaderAsync(CancellationToken cancellationToken);
        Task<object> ExecuteScalarAsync();
        Task<object> ExecuteScalarAsync(CancellationToken cancellationToken);
    }
}