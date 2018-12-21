using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace System.Data.Async
{
    public interface IDbConnectionAsync : IDbConnection, IDisposable
    {
        string ServerVersion { get; }
        string DataSource { get; }

        event StateChangeEventHandler StateChange;

        new DbTransaction BeginTransaction();
        new DbTransaction BeginTransaction(IsolationLevel isolationLevel);
        new IDbCommandAsync CreateCommand();
        void EnlistTransaction(Transaction transaction);
        DataTable GetSchema();
        DataTable GetSchema(string collectionName);
        DataTable GetSchema(string collectionName, string[] restrictionValues);
        Task OpenAsync();
        Task OpenAsync(CancellationToken cancellationToken);
    }
}