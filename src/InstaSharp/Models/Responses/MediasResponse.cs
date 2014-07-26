using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    public class MediasResponse : Response
    {
        public Pagination Pagination { get; set; }

        public List<Media> Data { get; set; }
    }
}
