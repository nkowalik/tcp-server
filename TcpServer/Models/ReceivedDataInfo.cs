namespace TcpServer.Models
{
    public class ReceivedDataInfo
    {
        public string Content { get; }

        public DataType DataType { get; }

        public ReceivedDataInfo(string content, DataType dataType)
        {
            Content = content;
            DataType = dataType;
        }
    }
}
