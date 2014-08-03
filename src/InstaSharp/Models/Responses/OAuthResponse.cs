namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// OAuthResponse
    /// </summary>
    public class OAuthResponse
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public UserInfo User { get; set; }
        /// <summary>
        /// Gets or sets the access_ token.
        /// </summary>
        /// <value>
        /// The access_ token.
        /// </value>
        public string Access_Token { get; set; }
    }
}
