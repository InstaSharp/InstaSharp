using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// Comments Response
    /// </summary>
    public class CommentsResponse : Response
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Comment> Data { get; set; }
    }
}
