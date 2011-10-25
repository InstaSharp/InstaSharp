using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp {
   [Serializable]
    public class AuthInfo {
        public string Access_Token { get; set; }
        public UserInfo User { get; set; }
        public InstagramConfig Config { get; set; }
    }
}
