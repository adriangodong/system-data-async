using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.Data.Async.SqlClient
{
    public interface ISqlCommandAsync : IDbCommandAsync, ICloneable
    {
        new SqlConnection Connection { get; set; }
        new SqlParameterCollection Parameters { get; }
        new SqlTransaction Transaction { get; set; }
        SqlNotificationRequest Notification { get; set; }

        event StatementCompletedEventHandler StatementCompleted;

        new SqlParameter CreateParameter();
        new SqlDataReader ExecuteReader();
        new SqlDataReader ExecuteReader(CommandBehavior behavior);
        new Task<SqlDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken cancellationToken);
        new Task<SqlDataReaderAsync> ExecuteReaderAsync(CommandBehavior behavior);
        new Task<SqlDataReaderAsync> ExecuteReaderAsync();
        new Task<SqlDataReaderAsync> ExecuteReaderAsync(CancellationToken cancellationToken);
        IAsyncResult BeginExecuteNonQuery();
        IAsyncResult BeginExecuteNonQuery(AsyncCallback callback, object stateObject);
        IAsyncResult BeginExecuteXmlReader(AsyncCallback callback, object stateObject);
        IAsyncResult BeginExecuteXmlReader();
        int EndExecuteNonQuery(IAsyncResult asyncResult);
        XmlReader EndExecuteXmlReader(IAsyncResult asyncResult);
        XmlReader ExecuteXmlReader();
        Task<XmlReader> ExecuteXmlReaderAsync(CancellationToken cancellationToken);
        Task<XmlReader> ExecuteXmlReaderAsync();
        void ResetCommandTimeout();
    }
}
