using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Incrementer
    {
        [DataMember]
        public int Value { get; set; }

        public Incrementer()
        {
            Value = Value++;
        }
    }
}