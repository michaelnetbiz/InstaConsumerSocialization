
using System;
using System.Runtime.Serialization;

namespace InstaConsumerSocialization.Models
{
    [DataContract]
    public class Comment
    {
        /// <summary>
        /// Get/set comment's createdTime.
        /// </summary>
        /// <value>
        /// Created time.
        /// </value>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Get/set comment's text.
        /// </summary>
        /// <value>
        /// Text.
        /// </value>
        [DataMember]
        public string Text { get; set; }

        /// <summary>
        /// Get/set comment's source.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        [DataMember]
        public UserInfo From { get; set; }

        /// <summary>
        /// Get/set comment's id.
        /// </summary>
        /// <value>
        /// Id.
        /// </value>
        [DataMember]
        public string Id { get; set; }

        public string GetText()
        {
            return Text;
        }
    }
}