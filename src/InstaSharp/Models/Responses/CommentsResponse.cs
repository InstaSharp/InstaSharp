using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    public class CommentsResponse : Response
    {
        public List<Comment> Data { get; set; }
    }
}
