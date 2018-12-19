using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDataRecordAsync : IDataRecord
    {
        Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken);
        Task<bool> IsDBNullAsync(int ordinal);
    }
}
