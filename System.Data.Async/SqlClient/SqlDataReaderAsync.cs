using System.Collections;
using System.Data.Async.Common;
using System.Data.SqlClient;

namespace System.Data.Async.SqlClient
{
    public class SqlDataReaderAsync : DbDataReaderAsync
    {

        public SqlDataReader SqlDataReader { get; }

        public SqlDataReaderAsync(SqlDataReader sqlDataReader)
        {
            SqlDataReader = sqlDataReader;
        }

        public override bool GetBoolean(int ordinal)
        {
            return SqlDataReader.GetBoolean(ordinal);
        }

        public override byte GetByte(int ordinal)
        {
            return SqlDataReader.GetByte(ordinal);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return SqlDataReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override char GetChar(int ordinal)
        {
            return SqlDataReader.GetChar(ordinal);
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return SqlDataReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override string GetDataTypeName(int ordinal)
        {
            return SqlDataReader.GetDataTypeName(ordinal);
        }

        public override DateTime GetDateTime(int ordinal)
        {
            return SqlDataReader.GetDateTime(ordinal);
        }

        public override decimal GetDecimal(int ordinal)
        {
            return SqlDataReader.GetDecimal(ordinal);
        }

        public override double GetDouble(int ordinal)
        {
            return SqlDataReader.GetDouble(ordinal);
        }

        public override Type GetFieldType(int ordinal)
        {
            return SqlDataReader.GetFieldType(ordinal);
        }

        public override float GetFloat(int ordinal)
        {
            return SqlDataReader.GetFloat(ordinal);
        }

        public override Guid GetGuid(int ordinal)
        {
            return SqlDataReader.GetGuid(ordinal);
        }

        public override short GetInt16(int ordinal)
        {
            return SqlDataReader.GetInt16(ordinal);
        }

        public override int GetInt32(int ordinal)
        {
            return SqlDataReader.GetInt32(ordinal);
        }

        public override long GetInt64(int ordinal)
        {
            return SqlDataReader.GetInt64(ordinal);
        }

        public override string GetName(int ordinal)
        {
            return SqlDataReader.GetName(ordinal);
        }

        public override int GetOrdinal(string name)
        {
            return SqlDataReader.GetOrdinal(name);
        }

        public override string GetString(int ordinal)
        {
            return SqlDataReader.GetString(ordinal);
        }

        public override object GetValue(int ordinal)
        {
            return SqlDataReader.GetValue(ordinal);
        }

        public override int GetValues(object[] values)
        {
            return SqlDataReader.GetValues(values);
        }

        public override bool IsDBNull(int ordinal)
        {
            return SqlDataReader.IsDBNull(ordinal);
        }

        public override int FieldCount => SqlDataReader.FieldCount;

        public override object this[int ordinal] => SqlDataReader[ordinal];

        public override object this[string name] => SqlDataReader[name];

        public override int RecordsAffected => SqlDataReader.RecordsAffected;

        public override bool HasRows => SqlDataReader.HasRows;

        public override bool IsClosed => SqlDataReader.IsClosed;

        public override bool NextResult()
        {
            return SqlDataReader.NextResult();
        }

        public override bool Read()
        {
            return SqlDataReader.Read();
        }

        public override int Depth => SqlDataReader.Depth;

        public override IEnumerator GetEnumerator()
        {
            return SqlDataReader.GetEnumerator();
        }

    }
}
