using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// Media Response object contains a list of media and pagination
    /// </summary>
    public class MediasResponse : Response
    {
        /// <summary>
        /// Gets or sets the pagination.
        /// </summary>
        /// <value>
        /// The pagination.
        /// </value>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Media> Data { get; set; }
    }
}
