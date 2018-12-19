using System.Data.SqlTypes;
using System.Xml;

namespace System.Data.Async.SqlClient
{
    public interface ISqlDataReaderAsync : IDbDataReaderAsync, IDisposable
    {
        DateTimeOffset GetDateTimeOffset(int i);
        SqlBinary GetSqlBinary(int i);
        SqlBoolean GetSqlBoolean(int i);
        SqlByte GetSqlByte(int i);
        SqlBytes GetSqlBytes(int i);
        SqlChars GetSqlChars(int i);
        SqlDateTime GetSqlDateTime(int i);
        SqlDecimal GetSqlDecimal(int i);
        SqlDouble GetSqlDouble(int i);
        SqlGuid GetSqlGuid(int i);
        SqlInt16 GetSqlInt16(int i);
        SqlInt32 GetSqlInt32(int i);
        SqlInt64 GetSqlInt64(int i);
        SqlMoney GetSqlMoney(int i);
        SqlSingle GetSqlSingle(int i);
        SqlString GetSqlString(int i);
        object GetSqlValue(int i);
        int GetSqlValues(object[] values);
        SqlXml GetSqlXml(int i);
        TimeSpan GetTimeSpan(int i);
        XmlReader GetXmlReader(int i);
    }
}
