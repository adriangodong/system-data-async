using System.Collections;
using System.Data.Async.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

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

        public override decimal GetDecimal(int ordinal)
        {
            return sqlDataReader.GetDecimal(ordinal);
        }

        public override double GetDouble(int ordinal)
        {
            return sqlDataReader.GetDouble(ordinal);
        }

        public override Type GetFieldType(int ordinal)
        {
            return sqlDataReader.GetFieldType(ordinal);
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

        public override string GetString(int ordinal)
        {
            return sqlDataReader.GetString(ordinal);
        }

        public override object GetValue(int ordinal)
        {
            return sqlDataReader.GetValue(ordinal);
        }

        public override int GetValues(object[] values)
        {
            return sqlDataReader.GetValues(values);
        }

        public override bool IsDBNull(int ordinal)
        {
            return sqlDataReader.IsDBNull(ordinal);
        }

        public override int FieldCount => sqlDataReader.FieldCount;

        public override object this[int ordinal] => sqlDataReader[ordinal];

        public override object this[string name] => sqlDataReader[name];

        public override int RecordsAffected => sqlDataReader.RecordsAffected;

        public override bool HasRows => sqlDataReader.HasRows;

        public override bool IsClosed => sqlDataReader.IsClosed;

        public override bool NextResult()
        {
            return sqlDataReader.NextResult();
        }

        public override bool Read()
        {
            return sqlDataReader.Read();
        }

        public override Task<bool> ReadAsync(CancellationToken cancellationToken)
        {
            return sqlDataReader.ReadAsync(cancellationToken);
        }

        public override int Depth => sqlDataReader.Depth;

        public override IEnumerator GetEnumerator()
        {
            return sqlDataReader.GetEnumerator();
        }

        protected override void Dispose(bool disposing)
        {
            sqlDataReader.Dispose();
            sqlCommandAsync.Dispose();

            sqlDataReader = null;
            sqlCommandAsync = null;

            base.Dispose(disposing);
        }

    }
}
