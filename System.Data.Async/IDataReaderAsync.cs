using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDataReaderAsync : IDataReader
    {
        Task<T> GetFieldValueAsync<T>(int ordinal);
        Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken);
        Task<bool> IsDBNullAsync(int ordinal);
        Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken);
        Task<bool> NextResultAsync();
        Task<bool> NextResultAsync(CancellationToken cancellationToken);
        Task<bool> ReadAsync();
        Task<bool> ReadAsync(CancellationToken cancellationToken);
    }
}