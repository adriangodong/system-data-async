using System.Data;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocalDb
{
    [TestClass]
    public class LeakTests
    {

        [TestMethod]
        public async Task Using_ExecuteReaderAsync_CommandBehavior_CloseConnection_LeakTest()
        {
            var service = new LocalDbService();

            for (var i = 0; i < 1000; i++)
            {
                var connection = service.GetConnection();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT 1";
                command.CommandType = CommandType.Text;

                await connection.OpenAsync();
                using (await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                {
                }
            }

            service.Dispose();
        }

        [TestMethod]
        public async Task Dispose_ExecuteReaderAsync_CommandBehavior_CloseConnection_LeakTest()
        {
            var service = new LocalDbService();

            for (var i = 0; i < 1000; i++)
            {
                var connection = service.GetConnection();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT 1";
                command.CommandType = CommandType.Text;

                await connection.OpenAsync();
                var dataReader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                dataReader.Dispose();
            }

            service.Dispose();
        }

        [TestMethod]
        public async Task Using_ExecuteNonQueryAsync_LeakTest()
        {
            var service = new LocalDbService();

            for (var i = 0; i < 1000; i++)
            {
                using (var connection = service.GetConnection())
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

            service.Dispose();
        }

    }
}
