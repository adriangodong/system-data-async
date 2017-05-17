using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDbConnectionAsync : IDbConnection
    {
        Task OpenAsync();
        Task OpenAsync(CancellationToken cancellationToken);
        new IDbCommandAsync CreateCommand();
    }
}