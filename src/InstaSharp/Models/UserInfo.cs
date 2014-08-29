using Newtonsoft.Json;

namespace InstaSharp.Models {
    /// <summary>
    /// User Information
    /// </summary>
    public class UserInfo {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the profile picture.
        /// </summary>
        /// <value>
        /// The profile picture.
        /// </value>
        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }
    }
}
