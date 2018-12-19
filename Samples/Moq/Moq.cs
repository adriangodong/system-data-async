using System.Data;
using System.Data.Async;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moq
{
    [TestClass]
    public class Moq
    {

        [TestMethod]
        public async Task OpenAsync()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionAsync>();

            // Act
            await mockConnection.Object.OpenAsync();

            // Assert
            mockConnection.Verify(mock => mock.OpenAsync(), Times.Once);
        }

        [TestMethod]
        public async Task CreateCommand_ExecuteNonQueryAsync()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionAsync>();
            var mockCommand = new Mock<IDbCommandAsync>();
            mockConnection.Setup(mock => mock.CreateCommand()).Returns(mockCommand.Object);

            // Act
            await mockConnection.Object.CreateCommand().ExecuteNonQueryAsync();

            // Assert
            mockCommand.Verify(mock => mock.ExecuteNonQueryAsync(), Times.Once);
        }

        [TestMethod]
        public async Task CreateCommand_ExecuteReaderAsync()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionAsync>();
            var mockCommand = new Mock<IDbCommandAsync>();
            mockConnection.Setup(mock => mock.CreateCommand()).Returns(mockCommand.Object);

            // Act
            await mockConnection.Object.CreateCommand().ExecuteReaderAsync();

            // Assert
            mockCommand.Verify(mock => mock.ExecuteReaderAsync(), Times.Once);
        }

        [TestMethod]
        public async Task CreateCommand_ExecuteScalarAsync()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionAsync>();
            var mockCommand = new Mock<IDbCommandAsync>();
            mockConnection.Setup(mock => mock.CreateCommand()).Returns(mockCommand.Object);

            // Act
            await mockConnection.Object.CreateCommand().ExecuteScalarAsync();

            // Assert
            mockCommand.Verify(mock => mock.ExecuteScalarAsync(), Times.Once);
        }

        [TestMethod]
        public void CreateCommand_ExecuteReader_Read()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionAsync>();
            var mockCommand = new Mock<IDbCommandAsync>();
            var mockDataReader = new Mock<IDataReader>();
            mockConnection.Setup(mock => mock.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(mock => mock.ExecuteReader()).Returns(mockDataReader.Object);

            // Act
            mockConnection.Object.CreateCommand().ExecuteReader().Read();

            // Assert
            mockDataReader.Verify(mock => mock.Read(), Times.Once);
        }

        [TestMethod]
        public async Task CreateCommand_ExecuteReaderAsync_ReadAsync()
        {
            // Arrange
            var mockConnection = new Mock<IDbConnectionAsync>();
            var mockCommand = new Mock<IDbCommandAsync>();
            var mockDataReader = new Mock<IDataReaderAsync>();
            mockConnection.Setup(mock => mock.CreateCommand()).Returns(mockCommand.Object);
            mockCommand.Setup(mock => mock.ExecuteReaderAsync()).ReturnsAsync(mockDataReader.Object);

            // Act
            await (await mockConnection.Object.CreateCommand().ExecuteReaderAsync()).ReadAsync();

            // Assert
            mockDataReader.Verify(mock => mock.ReadAsync(), Times.Once);
        }

    }
}
