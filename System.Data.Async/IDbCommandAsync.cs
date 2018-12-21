using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDbCommandAsync : IDbCommand, IDisposable
    {
        new DbConnection Connection { get; set; }
        new DbParameterCollection Parameters { get; }
        new DbTransaction Transaction { get; set; }
        bool DesignTimeVisible { get; set; }

        Task<int> ExecuteNonQueryAsync();
        Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken);
        Task<IDbDataReaderAsync> ExecuteReaderAsync();
        Task<IDbDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior);
        Task<IDbDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken);
        Task<IDbDataReaderAsync> ExecuteReaderAsync(CancellationToken cancellationToken);
        Task<object> ExecuteScalarAsync();
        Task<object> ExecuteScalarAsync(CancellationToken cancellationToken);
    }
}