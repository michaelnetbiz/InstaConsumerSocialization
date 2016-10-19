using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public decimal Lat { get; set; }

        [DataMember]
        public decimal Lng { get; set; }

        public Location(decimal lat, decimal lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}