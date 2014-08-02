using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// TagsMultiplePagesResponse
    /// </summary>
    public class TagsMultiplePagesResponse : Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagsMultiplePagesResponse"/> class.
        /// </summary>
        public TagsMultiplePagesResponse()
        {
            Data = new List<Media>();
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Media> Data { get; private set; }

        /// <summary>
        /// The number of pages in total which were returned
        /// </summary>
        /// <value>
        /// The page count.
        /// </value>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the pagination next maximum identifier.
        /// </summary>
        /// <value>
        /// The pagination next maximum identifier.
        /// </value>
        public string PaginationNextMaxId { get;  set; }
    }
}
