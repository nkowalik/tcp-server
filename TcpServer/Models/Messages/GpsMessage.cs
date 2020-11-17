using System;

namespace TcpServer.Models.Messages
{
    public class GpsMessage
    {
        public char Viled { get; set; }
        
        public char UExpand { get; set; }

        public char UReal { get; set; }

        public char[] Reserver { get; set; }

        public int ULongitude { get; set; }

        public int ULatitude { get; set; }

        public int UDirect { get; set; }

        public int UHigh { get; set; }

        public string UTime { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public override string ToString()
        {
            var viled = Viled switch
            {
                '\0' => "reliable and effective GPS data",
                '1' => "GPS data is not reliable",
                '2' => "device has no GPS module",
                _ => string.Empty
            };

            var real = UReal switch
            {
                '\0' => "real-time data",
                '1' => "fill data",
                _ => string.Empty
            };

            var time = new DateTime(int.Parse(UTime.Substring(0,4)), int.Parse(UTime.Substring(4, 2)),
                int.Parse(UTime.Substring(6, 2)), int.Parse(UTime.Substring(8,2)),
                int.Parse(UTime.Substring(10, 2)), int.Parse(UTime.Substring(12, 2)));

            var expand = 10000000;

            return $"GPS data\n{viled}\n{real}\nlongitude: {Longitude} {(double)ULongitude/expand}\nlatitude: {Latitude} {(double)ULatitude/expand}" +
                   $"\ndirect: {UDirect}\nhigh: {UHigh}\ntime: {time}\n";
        }
    }
}
