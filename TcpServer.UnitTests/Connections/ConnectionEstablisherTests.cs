using Newtonsoft.Json;
using TcpServer.Connections;
using TcpServer.Models;
using Xunit;

namespace TcpServer.UnitTests.Connections
{
    public class ConnectionEstablisherTests
    {
        [Fact]
        public void CreateResponseForFirstMessageShouldReturnNullForEmptyContent()
        {
            var content = string.Empty;

            var dataInfo = new ReceivedDataInfo(content, DataType.InitialMessage);
            var response = ConnectionEstablisher.CreateResponseForFirstMessage(dataInfo);

            Assert.Null(response);
        }

        [Fact]
        public void CreateResponseForFirstMessageShouldThrowJsonReaderExceptionForInvalidJson()
        {
            const string invalidContent = "some content";

            var dataInfo = new ReceivedDataInfo(invalidContent, DataType.InitialMessage);
            
            Assert.Throws<JsonReaderException>(() => ConnectionEstablisher.CreateResponseForFirstMessage(dataInfo));
        }

        [Fact]
        public void CreateResponseForFirstMessageShouldSucceedAndSendResponse()
        {
            const string content = "{\"MODULE\":\"CERTIFICATE\",\"OPERATION\":\"CONNECT\",\"PARAMETER\":{\"DEVTYPE\":1,\"PRO\":\"1.0.5\"},\"SESSION\":\"GUID\"}";
            const string expectedResponse = "{\"MODULE\":\"CERTIFICATE\",\"OPERATION\":\"CONNECT\",\"SESSION\":\"GUID\"";
            
            var dataInfo = new ReceivedDataInfo(content, DataType.InitialMessage);
            var response = ConnectionEstablisher.CreateResponseForFirstMessage(dataInfo);
            
            Assert.Contains(expectedResponse, response);
        }
    }
}
