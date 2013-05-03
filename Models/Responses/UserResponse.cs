using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class UserResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public Models.User Data { get; set; }
    }
}
