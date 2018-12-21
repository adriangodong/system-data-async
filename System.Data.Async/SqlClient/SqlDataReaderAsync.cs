using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.Data.Async.SqlClient
{
    public class SqlDataReaderAsync : ISqlDataReaderAsync, IDisposable
    {

        private readonly SqlDataReader sqlDataReader;

        internal SqlDataReaderAsync(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader;
        }

        #region Public Indexers

        public object this[string name] => sqlDataReader[name];
        public object this[int ordinal] => sqlDataReader[ordinal];

        #endregion

        #region Public Properties

        public int FieldCount => sqlDataReader.FieldCount;
        public int Depth => sqlDataReader.Depth;
        public bool IsClosed => sqlDataReader.IsClosed;
        public int RecordsAffected => sqlDataReader.RecordsAffected;
        public bool HasRows => sqlDataReader.HasRows;
        public int VisibleFieldCount => sqlDataReader.VisibleFieldCount;

        #endregion

        #region Public Methods

        public bool GetBoolean(int ordinal) => sqlDataReader.GetBoolean(ordinal);
        public byte GetByte(int ordinal) => sqlDataReader.GetByte(ordinal);
        public long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) => sqlDataReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        public char GetChar(int ordinal) => sqlDataReader.GetChar(ordinal);
        public long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length) => sqlDataReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        IDataReader IDataRecord.GetData(int ordinal) => sqlDataReader.GetData(ordinal);
        public DbDataReader GetData(int ordinal) => sqlDataReader.GetData(ordinal);
        public string GetDataTypeName(int ordinal) => sqlDataReader.GetDataTypeName(ordinal);
        public DateTime GetDateTime(int ordinal) => sqlDataReader.GetDateTime(ordinal);
        public DateTimeOffset GetDateTimeOffset(int ordinal) => sqlDataReader.GetDateTimeOffset(ordinal);
        public decimal GetDecimal(int ordinal) => sqlDataReader.GetDecimal(ordinal);
        public double GetDouble(int ordinal) => sqlDataReader.GetDouble(ordinal);
        public Type GetFieldType(int ordinal) => sqlDataReader.GetFieldType(ordinal);
        public T GetFieldValue<T>(int ordinal) => sqlDataReader.GetFieldValue<T>(ordinal);
        public Task<T> GetFieldValueAsync<T>(int ordinal) => sqlDataReader.GetFieldValueAsync<T>(ordinal);
        public Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken) => sqlDataReader.GetFieldValueAsync<T>(ordinal, cancellationToken);
        public float GetFloat(int ordinal) => sqlDataReader.GetFloat(ordinal);
        public Guid GetGuid(int ordinal) => sqlDataReader.GetGuid(ordinal);
        public short GetInt16(int ordinal) => sqlDataReader.GetInt16(ordinal);
        public int GetInt32(int ordinal) => sqlDataReader.GetInt32(ordinal);
        public long GetInt64(int ordinal) => sqlDataReader.GetInt64(ordinal);
        public string GetName(int ordinal) => sqlDataReader.GetName(ordinal);
        public int GetOrdinal(string name) => sqlDataReader.GetOrdinal(name);
        public Type GetProviderSpecificFieldType(int ordinal) => sqlDataReader.GetProviderSpecificFieldType(ordinal);
        public object GetProviderSpecificValue(int ordinal) => sqlDataReader.GetProviderSpecificValue(ordinal);
        public int GetProviderSpecificValues(object[] values) => sqlDataReader.GetProviderSpecificValues(values);
        public DataTable GetSchemaTable() => sqlDataReader.GetSchemaTable();
        public SqlBinary GetSqlBinary(int ordinal) => sqlDataReader.GetSqlBinary(ordinal);
        public SqlBoolean GetSqlBoolean(int ordinal) => sqlDataReader.GetSqlBoolean(ordinal);
        public SqlByte GetSqlByte(int ordinal) => sqlDataReader.GetSqlByte(ordinal);
        public SqlBytes GetSqlBytes(int ordinal) => sqlDataReader.GetSqlBytes(ordinal);
        public SqlChars GetSqlChars(int ordinal) => sqlDataReader.GetSqlChars(ordinal);
        public SqlDateTime GetSqlDateTime(int ordinal) => sqlDataReader.GetSqlDateTime(ordinal);
        public SqlDecimal GetSqlDecimal(int ordinal) => sqlDataReader.GetSqlDecimal(ordinal);
        public SqlDouble GetSqlDouble(int ordinal) => sqlDataReader.GetSqlDouble(ordinal);
        public SqlGuid GetSqlGuid(int ordinal) => sqlDataReader.GetSqlGuid(ordinal);
        public SqlInt16 GetSqlInt16(int ordinal) => sqlDataReader.GetSqlInt16(ordinal);
        public SqlInt32 GetSqlInt32(int ordinal) => sqlDataReader.GetSqlInt32(ordinal);
        public SqlInt64 GetSqlInt64(int ordinal) => sqlDataReader.GetSqlInt64(ordinal);
        public SqlMoney GetSqlMoney(int ordinal) => sqlDataReader.GetSqlMoney(ordinal);
        public SqlSingle GetSqlSingle(int ordinal) => sqlDataReader.GetSqlSingle(ordinal);
        public SqlString GetSqlString(int ordinal) => sqlDataReader.GetSqlString(ordinal);
        public object GetSqlValue(int ordinal) => sqlDataReader.GetSqlValue(ordinal);
        public int GetSqlValues(object[] values) => sqlDataReader.GetSqlValues(values);
        public SqlXml GetSqlXml(int ordinal) => sqlDataReader.GetSqlXml(ordinal);
        public Stream GetStream(int ordinal) => sqlDataReader.GetStream(ordinal);
        public string GetString(int ordinal) => sqlDataReader.GetString(ordinal);
        public TextReader GetTextReader(int ordinal) => sqlDataReader.GetTextReader(ordinal);
        public TimeSpan GetTimeSpan(int ordinal) => sqlDataReader.GetTimeSpan(ordinal);
        public object GetValue(int ordinal) => sqlDataReader.GetValue(ordinal);
        public int GetValues(object[] values) => sqlDataReader.GetValues(values);
        public XmlReader GetXmlReader(int ordinal) => sqlDataReader.GetXmlReader(ordinal);
        public void Close() => sqlDataReader.Close();
        public bool IsDBNull(int ordinal) => sqlDataReader.IsDBNull(ordinal);
        public Task<bool> IsDBNullAsync(int ordinal) => sqlDataReader.IsDBNullAsync(ordinal);
        public Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken) => sqlDataReader.IsDBNullAsync(ordinal, cancellationToken);
        public bool NextResult() => sqlDataReader.NextResult();
        public Task<bool> NextResultAsync() => sqlDataReader.NextResultAsync();
        public Task<bool> NextResultAsync(CancellationToken cancellationToken) => sqlDataReader.NextResultAsync(cancellationToken);
        public bool Read() => sqlDataReader.Read();
        public Task<bool> ReadAsync() => sqlDataReader.ReadAsync();
        public Task<bool> ReadAsync(CancellationToken cancellationToken) => sqlDataReader.ReadAsync(cancellationToken);

        #endregion

        public IEnumerator GetEnumerator()
        {
            return sqlDataReader.GetEnumerator();
        }

        public void Dispose()
        {
            sqlDataReader.Dispose();
        }

    }
}
