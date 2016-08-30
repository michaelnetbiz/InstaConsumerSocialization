using System;
using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Identifier : Object
    {
        [DataMember]
        public string Value { get; set; }

        public Identifier()
        {
            Value = Guid.NewGuid().ToString("N");
        }
    }
}