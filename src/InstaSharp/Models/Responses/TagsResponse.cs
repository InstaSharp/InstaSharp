using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    public class TagsResponse : Response
    {
        public List<Tag> Data { get; set; }
    }
}
