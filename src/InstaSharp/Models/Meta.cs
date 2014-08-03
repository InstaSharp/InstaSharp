using System.Net;
using Newtonsoft.Json;

namespace InstaSharp.Models
{
    /// <summary>
    /// Metadata in response
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the error.
        /// </summary>
        /// <value>
        /// The type of the error.
        /// </value>
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
