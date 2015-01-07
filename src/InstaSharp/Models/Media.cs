using InstaSharp.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InstaSharp.Models
{
    /// <summary>
    /// The Media Object
    /// </summary>
    public class Media
    {

        /// <summary>
        /// Gets or sets the attribution.
        /// </summary>
        /// <value>
        /// The attribution.
        /// </value>
        public string Attribution { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public Comments Comments { get; set; }
        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        public Caption Caption { get; set; }

        /// <summary>
        /// Gets or sets the user has liked.
        /// </summary>
        /// <value>
        /// The user has liked.
        /// </value>
        [JsonProperty("user_has_liked")]
        public bool? UserHasLiked { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the likes.
        /// </summary>
        /// <value>
        /// The likes.
        /// </value>
        public Likes Likes { get; set; }
        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        /// <value>
        /// The created time.
        /// </value>
        [JsonProperty("created_time"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>
        /// The images.
        /// </value>
        public Image Images { get; set; }
        /// <summary>
        /// Gets or sets the videos.
        /// </summary>
        /// <value>
        /// The videos.
        /// </value>
        public Video Videos { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string Filter { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the users in photo.
        /// </summary>
        /// <value>
        /// The users in photo.
        /// </value>
        [JsonProperty("users_in_photo")]
        public List<UserInPhoto> UsersInPhoto { get; set; }
    }
}
