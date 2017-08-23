using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Async;
using System.Data.Async.SqlClient;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocalDb
{
    [TestClass]
    public class LeakTests
    {

        private IDbConnectionAsync GetConnection()
        {
            return new SqlConnectionAsync("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;");
        }

        private DbmsDatatypeMapping Read(IDataReaderAsync reader)
        {
            var mapping = new DbmsDatatypeMapping();

            mapping.DatatypeMappingId = reader.GetInt32(0);
            mapping.MapId = reader.GetInt32(1);
            mapping.DestDatatypeId = reader.GetInt32(2);

            return mapping;
        }

        [TestMethod]
        public async Task SqlCommandAsync_Dispose_ShouldCloseConnectionAndNullify()
        {
            // Arrange
            var connection = GetConnection();
            var command = connection.CreateCommand();

            var innerConnection = ((SqlConnectionAsync)connection).sqlConnection;

            await connection.OpenAsync();

            // Act
            command.Dispose();

            // Assert
            Assert.AreEqual(ConnectionState.Closed, innerConnection.State);
            Assert.IsNull(((SqlCommandAsync)command).sqlCommand);
            Assert.IsNull(((SqlCommandAsync)command).sqlConnectionAsync);
        }

        [TestMethod]
        public async Task SqlDataReaderAsync_Dispose_ShouldCloseConnectionAndNullify()
        {
            // Arrange
            var connection = GetConnection();
            var command = connection.CreateCommand();
            command.CommandText = "select * from msdb.dbo.MSdbms_datatype_mapping";
            command.CommandType = CommandType.Text;

            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();

            // Act
            reader.Dispose();

            // Assert
            Assert.IsNull(((SqlDataReaderAsync)reader).sqlDataReader);
            Assert.IsNull(((SqlDataReaderAsync)reader).sqlCommandAsync);
        }

        [TestMethod]
        public async Task Using_ExecuteReaderAsync_CommandBehavior_CloseConnection_LeakTest()
        {
            for (var i = 0; i < 1000; i++)
            {
                var connection = GetConnection();
                var command = connection.CreateCommand();
                command.CommandText = "select * from msdb.dbo.MSdbms_datatype_mapping";
                command.CommandType = CommandType.Text;

                await connection.OpenAsync();

                var mappings = new List<DbmsDatatypeMapping>();
                using (var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                {
                    while (await reader.ReadAsync())
                    {
                        mappings.Add(Read(reader));
                    }
                }
            }
        }

        [TestMethod]
        public async Task Using_ExecuteReaderAsync_WithGcCollect_LeakTest()
        {
            var connection = GetConnection();
            var command = connection.CreateCommand();
            command.CommandText = "select * from msdb.dbo.MSdbms_datatype_mapping";
            command.CommandType = CommandType.Text;

            await connection.OpenAsync();

            var mappings = new List<DbmsDatatypeMapping>();
            using (var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
            {
                while (await reader.ReadAsync())
                {
                    GC.Collect();
                    mappings.Add(Read(reader));
                }
            }
        }

        [TestMethod]
        public async Task Using_ExecuteReaderAsync_LeakTest()
        {
            for (var i = 0; i < 1000; i++)
            {
                var connection = GetConnection();
                var command = connection.CreateCommand();
                command.CommandText = "select * from msdb.dbo.MSdbms_datatype_mapping";
                command.CommandType = CommandType.Text;

                await connection.OpenAsync();

                var mappings = new List<DbmsDatatypeMapping>();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            mappings.Add(Read(reader));
                        }
                    }
                }
            }
        }

        [TestMethod]
        public async Task Dispose_ExecuteReaderAsync_CommandBehavior_CloseConnection_LeakTest()
        {
            for (var i = 0; i < 1000; i++)
            {
                var connection = GetConnection();
                var command = connection.CreateCommand();
                command.CommandText = "select * from msdb.dbo.MSdbms_datatype_mapping";
                command.CommandType = CommandType.Text;

                await connection.OpenAsync();

                var mappings = new List<DbmsDatatypeMapping>();
                var reader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (await reader.ReadAsync())
                {
                    mappings.Add(Read(reader));
                }
                reader.Dispose();
            }
        }

        [TestMethod]
        public async Task Dispose_ExecuteReaderAsync_WithGcCollect_LeakTest()
        {
            var connection = GetConnection();
            var command = connection.CreateCommand();
            command.CommandText = "select * from msdb.dbo.MSdbms_datatype_mapping";
            command.CommandType = CommandType.Text;

            await connection.OpenAsync();

            var mappings = new List<DbmsDatatypeMapping>();
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                while (await reader.ReadAsync())
                {
                    GC.Collect();
                    mappings.Add(Read(reader));
                }
            }
            reader.Dispose();
        }

        [TestMethod]
        public async Task Dispose_ExecuteReaderAsync_LeakTest()
        {
            for (var i = 0; i < 1000; i++)
            {
                var connection = GetConnection();
                var command = connection.CreateCommand();
                command.CommandText = "select * from msdb.dbo.MSdbms_datatype_mapping";
                command.CommandType = CommandType.Text;

                await connection.OpenAsync();

                var mappings = new List<DbmsDatatypeMapping>();
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        mappings.Add(Read(reader));
                    }
                }
                reader.Dispose();
            }
        }

        [TestMethod]
        public async Task Using_ExecuteNonQueryAsync_LeakTest()
        {
            for (var i = 0; i < 1000; i++)
            {
                using (var connection = GetConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT 1";
                        command.CommandType = CommandType.Text;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        internal class DbmsDatatypeMapping
        {
            public int DatatypeMappingId { get; set; }
            public int MapId { get; set; }
            public int DestDatatypeId { get; set; }
        }

    }
}
