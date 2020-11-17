namespace TcpServer.Models
{
    public class Header
    {
        public int VersionNumber { get; set; }

        public int PaddingField { get; set; }

        public int ImportantEvents { get; set; }

        public int ContributorsCount { get; set; }

        public int PayloadType { get; set; }

        public int SynchronizationSourceIdentifier { get; set; }

        public int PayloadDataLength { get; set; }

        public int ContributingSource { get; set; }
    }
}
