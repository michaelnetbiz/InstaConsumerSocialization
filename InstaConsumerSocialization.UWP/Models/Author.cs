using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Uri ImageUri { get; set; }
    }
}
