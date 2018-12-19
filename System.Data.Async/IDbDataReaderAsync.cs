using System.Collections;
using System.Data.Common;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Async
{
    public interface IDbDataReaderAsync : IDataReaderAsync, IDataRecordAsync, IEnumerable, IDisposable
    {
        bool HasRows { get; }
        int VisibleFieldCount { get; }

        new DbDataReader GetData(int ordinal);
        T GetFieldValue<T>(int ordinal);
        Task<T> GetFieldValueAsync<T>(int ordinal);
        Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken);
        Type GetProviderSpecificFieldType(int ordinal);
        object GetProviderSpecificValue(int ordinal);
        int GetProviderSpecificValues(object[] values);
        Stream GetStream(int ordinal);
        TextReader GetTextReader(int ordinal);
    }
}
