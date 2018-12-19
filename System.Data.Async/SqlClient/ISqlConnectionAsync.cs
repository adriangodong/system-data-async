using System.Collections;
using System.Data.SqlClient;

namespace System.Data.Async.SqlClient
{
    public interface ISqlConnectionAsync : IDbConnectionAsync, ICloneable
    {
        string WorkstationId { get; }
        bool StatisticsEnabled { get; set; }
        int PacketSize { get; }
        bool FireInfoMessageEventOnUserErrors { get; set; }
        Guid ClientConnectionId { get; }
        SqlCredential Credential { get; set; }

        event SqlInfoMessageEventHandler InfoMessage;

        new SqlTransaction BeginTransaction();
        new SqlTransaction BeginTransaction(IsolationLevel isolationLevel);
        SqlTransaction BeginTransaction(IsolationLevel isolationLevel, string transactionName);
        SqlTransaction BeginTransaction(string transactionName);
        new ISqlCommandAsync CreateCommand();
        void ResetStatistics();
        IDictionary RetrieveStatistics();
    }
}
