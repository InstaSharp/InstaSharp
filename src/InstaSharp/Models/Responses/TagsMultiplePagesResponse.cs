using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    public class TagsMultiplePagesResponse : Response
    {
        public TagsMultiplePagesResponse()
        {
            Data = new List<Media>();
        }

        public List<Media> Data { get; set; }

        /// <summary>
        /// The number of pages in total which were returned
        /// </summary>
        public int PageCount { get; set; }
    }
}
