using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class OAuthResponse {
        public UserInfo User { get; set; }
        public string Access_Token { get; set; }
    }
}
