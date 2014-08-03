using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// Tags Response
    /// </summary>
    public class TagsResponse : Response
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Tag> Data { get; set; }
    }
}
