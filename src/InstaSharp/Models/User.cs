
namespace InstaSharp.Models {
    /// <summary>
    /// The User
    /// </summary>
    public class User : UserInfo
    {
        /// <summary>
        /// Gets or sets the bio.
        /// </summary>
        /// <value>
        /// The bio.
        /// </value>
        public string Bio { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }
        /// <summary>
        /// Gets or sets the counts.
        /// </summary>
        /// <value>
        /// The counts.
        /// </value>
        public Count Counts { get; set; }
    }
}
