using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{   [DataContract]
    public class Post
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public int CreationDay { get; set; }
        [DataMember]
        public int CreationMonth { get; set; }
        [DataMember]
        public int CreationYear { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public Uri AuthorImageUri { get; set; }
        [DataMember]
        public string Caption { get; set; }
        [DataMember]
        public int LikesNumber { get; set; }
        [DataMember]
        public int CommentsNumber { get; set; }
        [DataMember]
        public Uri PostImageUri { get; set; }

        public string NamesAsString => string.Join(", ", new[]
{
            "lol"
        });
    }
}