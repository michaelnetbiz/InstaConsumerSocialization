using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Like
    {
        [DataMember]
        public Identifier Id { get; set; }

        [DataMember]
        public Incrementer Index { get; set; }

        [DataMember]
        public User LikingUser { get; set; }


        public Like(User likingUser)
        {
            Id = new Identifier();
            Index = new Incrementer();
            LikingUser = likingUser;
        }
    }
}