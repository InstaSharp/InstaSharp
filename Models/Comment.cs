using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Comment {
        public DateTime CreatedTime { get; set; }
        public string Text { get; set; }
        public UserInfo From { get; set; }
        public string Id { get; set; }
    }
}
