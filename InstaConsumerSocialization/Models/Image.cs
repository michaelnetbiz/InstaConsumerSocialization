using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Image
    {
        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public Identifier Id { get; set; }

        [DataMember]
        public Incrementer Index { get; set; }

        public Image(string path)
        {
            this.Id = new Identifier();
            this.Index = new Incrementer();
            this.Path = path;
        }
    }
}