
using System;

namespace InstaConsumerSocialization.Models
{
    public class Comment
    {
        /// <summary>
        /// Get/set comment's createdTime.
        /// </summary>
        /// <value>
        /// Created time.
        /// </value>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Get/set comment's text.
        /// </summary>
        /// <value>
        /// Text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Get/set comment's source.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public UserInfo From { get; set; }

        /// <summary>
        /// Get/set comment's id.
        /// </summary>
        /// <value>
        /// Id.
        /// </value>
        public string Id { get; set; }

        public string GetText()
        {
            return Text;
        }
    }
}