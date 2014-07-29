using System.Collections.Generic;

namespace InstaSharp.Models {
    public class Likes {
        public int Count { get; set; }
        public List<UserInfo> Data { get; set; }
    }
}
