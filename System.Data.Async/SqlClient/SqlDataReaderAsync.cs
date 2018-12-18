using System.Collections;
using System.Data.Async.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.Data.Async.SqlClient
{
    public class SqlDataReaderAsync : DbDataReaderAsync
    {

        internal SqlDataReader sqlDataReader;
        internal SqlCommandAsync sqlCommandAsync;

        public SqlDataReaderAsync(SqlDataReader sqlDataReader, SqlCommandAsync sqlCommandAsync)
        {
            this.sqlDataReader = sqlDataReader;
            this.sqlCommandAsync = sqlCommandAsync;
        }

        #region System.Data.SqlClient.SqlDataReader Redirect
        // All overridden members from DbDataReader and
        // all public members from SqlDataReader
        // should be redirected by this class to the sqlDataReader instance.

        public override object this[string name] => sqlDataReader[name];
        public override object this[int ordinal] => sqlDataReader[ordinal];
        public override int VisibleFieldCount => sqlDataReader.VisibleFieldCount;
        public override bool IsClosed => sqlDataReader.IsClosed;
        public override bool HasRows => sqlDataReader.HasRows;
        public override int FieldCount => sqlDataReader.FieldCount;
        public override int Depth => sqlDataReader.Depth;
        public override int RecordsAffected => sqlDataReader.RecordsAffected;

        public override bool GetBoolean(int ordinal)
        {
            return sqlDataReader.GetBoolean(ordinal);
        }

        public override byte GetByte(int ordinal)
        {
            return sqlDataReader.GetByte(ordinal);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return sqlDataReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override char GetChar(int ordinal)
        {
            return sqlDataReader.GetChar(ordinal);
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return sqlDataReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override string GetDataTypeName(int ordinal)
        {
            return sqlDataReader.GetDataTypeName(ordinal);
        }

        public override DateTime GetDateTime(int ordinal)
        {
            return sqlDataReader.GetDateTime(ordinal);
        }

        public DateTimeOffset GetDateTimeOffset(int ordinal)
        {
            return sqlDataReader.GetDateTimeOffset(ordinal);
        }

        public override decimal GetDecimal(int ordinal)
        {
            return sqlDataReader.GetDecimal(ordinal);
        }

        public override double GetDouble(int ordinal)
        {
            return sqlDataReader.GetDouble(ordinal);
        }

        public override IEnumerator GetEnumerator()
        {
            return sqlDataReader.GetEnumerator();
        }

        public override Type GetFieldType(int ordinal)
        {
            return sqlDataReader.GetFieldType(ordinal);
        }

        public override T GetFieldValue<T>(int ordinal)
        {
            return sqlDataReader.GetFieldValue<T>(ordinal);
        }

        public override Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken)
        {
            return sqlDataReader.GetFieldValueAsync<T>(ordinal, cancellationToken);
        }

        public override float GetFloat(int ordinal)
        {
            return sqlDataReader.GetFloat(ordinal);
        }

        public override Guid GetGuid(int ordinal)
        {
            return sqlDataReader.GetGuid(ordinal);
        }

        public override short GetInt16(int ordinal)
        {
            return sqlDataReader.GetInt16(ordinal);
        }

        public override int GetInt32(int ordinal)
        {
            return sqlDataReader.GetInt32(ordinal);
        }

        public override long GetInt64(int ordinal)
        {
            return sqlDataReader.GetInt64(ordinal);
        }

        public override string GetName(int ordinal)
        {
            return sqlDataReader.GetName(ordinal);
        }

        public override int GetOrdinal(string name)
        {
            return sqlDataReader.GetOrdinal(name);
        }

        public override Type GetProviderSpecificFieldType(int ordinal)
        {
            return sqlDataReader.GetProviderSpecificFieldType(ordinal);
        }

        public override object GetProviderSpecificValue(int ordinal)
        {
            return sqlDataReader.GetProviderSpecificValue(ordinal);
        }

        public override int GetProviderSpecificValues(object[] values)
        {
            return sqlDataReader.GetProviderSpecificValues(values);
        }

        public override DataTable GetSchemaTable()
        {
            return sqlDataReader.GetSchemaTable();
        }

        public SqlBinary GetSqlBinary(int ordinal)
        {
            return sqlDataReader.GetSqlBinary(ordinal);
        }

        public SqlBoolean GetSqlBoolean(int ordinal)
        {
            return sqlDataReader.GetSqlBoolean(ordinal);
        }

        public SqlByte GetSqlByte(int ordinal)
        {
            return sqlDataReader.GetSqlByte(ordinal);
        }

        public SqlBytes GetSqlBytes(int ordinal)
        {
            return sqlDataReader.GetSqlBytes(ordinal);
        }

        public SqlChars GetSqlChars(int ordinal)
        {
            return sqlDataReader.GetSqlChars(ordinal);
        }

        public SqlDateTime GetSqlDateTime(int ordinal)
        {
            return sqlDataReader.GetSqlDateTime(ordinal);
        }

        public SqlDecimal GetSqlDecimal(int ordinal)
        {
            return sqlDataReader.GetSqlDecimal(ordinal);
        }

        public SqlDouble GetSqlDouble(int ordinal)
        {
            return sqlDataReader.GetSqlDouble(ordinal);
        }

        public SqlGuid GetSqlGuid(int ordinal)
        {
            return sqlDataReader.GetSqlGuid(ordinal);
        }

        public SqlInt16 GetSqlInt16(int ordinal)
        {
            return sqlDataReader.GetSqlInt16(ordinal);
        }

        public SqlInt32 GetSqlInt32(int ordinal)
        {
            return sqlDataReader.GetSqlInt32(ordinal);
        }

        public SqlInt64 GetSqlInt64(int ordinal)
        {
            return sqlDataReader.GetSqlInt64(ordinal);
        }

        public SqlMoney GetSqlMoney(int ordinal)
        {
            return sqlDataReader.GetSqlMoney(ordinal);
        }

        public SqlSingle GetSqlSingle(int ordinal)
        {
            return sqlDataReader.GetSqlSingle(ordinal);
        }

        public SqlString GetSqlString(int ordinal)
        {
            return sqlDataReader.GetSqlString(ordinal);
        }

        public object GetSqlValue(int ordinal)
        {
            return sqlDataReader.GetSqlValue(ordinal);
        }

        public int GetSqlValues(object[] values)
        {
            return sqlDataReader.GetSqlValues(values);
        }

        public SqlXml GetSqlXml(int ordinal)
        {
            return sqlDataReader.GetSqlXml(ordinal);
        }

        public override Stream GetStream(int ordinal)
        {
            return sqlDataReader.GetStream(ordinal);
        }

        public override string GetString(int ordinal)
        {
            return sqlDataReader.GetString(ordinal);
        }

        public override TextReader GetTextReader(int ordinal)
        {
            return sqlDataReader.GetTextReader(ordinal);
        }

        public TimeSpan GetTimeSpan(int ordinal)
        {
            return sqlDataReader.GetTimeSpan(ordinal);
        }

        public override object GetValue(int ordinal)
        {
            return sqlDataReader.GetValue(ordinal);
        }

        public override int GetValues(object[] values)
        {
            return sqlDataReader.GetValues(values);
        }

        public XmlReader GetXmlReader(int ordinal)
        {
            return sqlDataReader.GetXmlReader(ordinal);
        }

        public override bool IsDBNull(int ordinal)
        {
            return sqlDataReader.IsDBNull(ordinal);
        }

        public override Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken)
        {
            return sqlDataReader.IsDBNullAsync(ordinal, cancellationToken);
        }

        public override bool NextResult()
        {
            return sqlDataReader.NextResult();
        }

        public override Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            return sqlDataReader.NextResultAsync(cancellationToken);
        }

        public override bool Read()
        {
            return sqlDataReader.Read();
        }

        public override Task<bool> ReadAsync(CancellationToken cancellationToken)
        {
            return sqlDataReader.ReadAsync(cancellationToken);
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (sqlDataReader != null)
            {
                sqlDataReader.Dispose();
                sqlDataReader = null;
            }

            if (sqlCommandAsync != null)
            {
                sqlCommandAsync.Dispose();
                sqlCommandAsync = null;
            }

            base.Dispose(disposing);
        }

    }
}
