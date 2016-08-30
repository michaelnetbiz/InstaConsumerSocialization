using System;
using System.Collections.Generic;
using System.Linq;

namespace InstaConsumerSocialization.Models
{
    public class Post
    {
        public Caption Caption { get; set; }

        public List<Comment> Comments { get; set; }

        public DateTime CreatedTime { get; }

        public string Filter { get; set; }

        public IEnumerable<string> PossibleFilters { get; set; }

        public string Id { get; }

        public int Index { get; }

        public Image Image { get; set; }

        public List<Like> Likes { get; set; }

        /// <summary>
        /// Gets/sets post's location
        /// </summary>
        /// <value>
        /// Post location.
        /// </value>
        public Location Location { get; set; }

        public List<Tag> Tags { get; set; }

        public Enum Type { get; set; }

        public string Url { get; set; }

        public User User { get; set; }

        public bool ViewerLikedPost { get; set; }

        public string PossibleFiltersAsString => string.Join(", ", PossibleFilters);
    }
}