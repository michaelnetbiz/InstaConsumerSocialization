using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Caption
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public Identifier Id { get; set; }

        [DataMember]
        public Incrementer Index { get; set; }

        public Caption(string caption)
        {
            this.Id = new Identifier();
            this.Index = new Incrementer();
            this.Text = caption;
        }
    }
}