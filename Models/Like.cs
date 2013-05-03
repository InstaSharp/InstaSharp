using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace InstaSharp.Models {
    public class Like {
        public int Count { get; set; }
        public IList<LikesData> Data { get; set; }
    }

    public class LikesData {
        public string Username { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }
        public string ProfilePicture { get; set; }
        public List<Like> Likes { get; set; }
    }
}
