using TcpServer.Connections;
using Xunit;

namespace TcpServer.UnitTests.Connections
{
    public class GpsDataReaderTests
    {
        [Fact]
        public void ReadDataShouldSuccessfullyReturnGpsMessage()
        {
            var data = new byte[65536];
            const string time = "20201117134047";
            var content = $"000\u0004n??\0{time}\0\0";

            var gpsMessage = GpsDataReader.ReadData(data, content);

            Assert.Contains(time, gpsMessage.UTime);
        }
    }
}
