using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaConsumerSocialization.WebAPI.Models
{
    public class Post
    {
        public string Id { get; set; }
        public int CreationDay { get; set; }
        public int CreationMonth { get; set; }
        public int CreationYear { get; set; }
        public string Author { get; set; }
        public Uri AuthorImageUri { get; set; }
        public string Caption { get; set; }
        public bool IsLikedByUser { get; set; }
        public int LikesNumber { get; set; }
        public int CommentsNumber { get; set; }
        public Uri PostImageUri { get; set; }
        public string TimeSince => string.Concat(Math.Round((Decimal)TimeLOL.TotalDays, 0, MidpointRounding.AwayFromZero), "d");
    }
}