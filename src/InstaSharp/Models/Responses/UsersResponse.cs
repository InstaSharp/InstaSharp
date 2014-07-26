using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    public class UsersResponse : Response
    {
        public List<User> Data { get; set; }

        public Pagination Pagination { get; set; }
    }
}
