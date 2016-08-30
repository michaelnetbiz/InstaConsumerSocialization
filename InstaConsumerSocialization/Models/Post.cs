using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public List<string> Comments { get; set; }

        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public string Filter { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int Index { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public List<string> Likes { get; set; }

        /// <summary>
        /// Gets/sets post's location
        /// </summary>
        /// <value>
        /// Post location.
        /// </value>
        [DataMember]
        public decimal Lat { get; set; }

        [DataMember]
        public decimal Lng { get; set; }

        public IEnumerable<string> Names { get; set; }

        [DataMember]
        public List<string> Tags { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public bool ViewerLikedPost { get; set; }

        public Post(
            string captionText,
            List<string> comments,
            DateTime createdTime,
            string filter,
            string id,
            int index,
            string imagePath,
            List<string> likes,
            decimal lat,
            decimal lng,
            IEnumerable<string> names,
            List<string> tags,
            string type,
            string url,
            string user,
            bool viewerLikedPost
        )
        {
            Caption = captionText;
            Comments = comments;
            CreatedTime = createdTime;
            Filter = filter;
            Id = id;
            Index = index;
            Image = imagePath;
            Likes = likes;
            Lat = lat;
            Lng = lng;
            Names = names;
            Tags = tags;
            Type = type;
            Url = url;
            User = user;
            ViewerLikedPost = viewerLikedPost;
        }

        public Post() { }

        public string NamesAsString => string.Join(", ", new []
        {
            "lol"
        });
    }
}