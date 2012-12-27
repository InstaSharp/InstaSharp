using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class UsersResponse : IResponse {
        [JsonMapping("meta", JsonMapping.MappingType.Class)]
        public Models.Meta Meta { get; set; }
        [JsonMapping("data", JsonMapping.MappingType.Collection)]
        public IList<Models.User> Data { get; set; }
    }
}
