using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDataReaderAsync : IDataReader, IDataRecordAsync
    {
        Task<bool> NextResultAsync();
        Task<bool> NextResultAsync(CancellationToken cancellationToken);
        Task<bool> ReadAsync();
        Task<bool> ReadAsync(CancellationToken cancellationToken);
    }
}
