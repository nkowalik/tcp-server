using TcpServer.Connections;
using TcpServer.Models;
using Xunit;

namespace TcpServer.UnitTests.Connections
{
    public class KeepAliverTests
    {
        [Fact]
        public void GetKeepAliveFrameOutBufferShouldReturnEmptyArrayForEmptyContent()
        {
            var content = string.Empty;

            var dataInfo = new ReceivedDataInfo(content, DataType.KeepAlive);
            var outBuffer = KeepAliver.GetKeepAliveFrameOutBuffer(dataInfo);

            Assert.Empty(outBuffer);
        }

        [Fact]
        public void GetKeepAliveFrameOutBufferShouldSucceed()
        {
            const string content = "{\"MODULE\":\"CERTIFICATE\",\"OPERATION\":\"KEEPALIVE\",\"SESSION\":\"GUID\"}";
            
            var dataInfo = new ReceivedDataInfo(content, DataType.KeepAlive);
            var outBuffer = KeepAliver.GetKeepAliveFrameOutBuffer(dataInfo);

            Assert.NotEmpty(outBuffer);
        }
    }
}
