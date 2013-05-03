using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Comments {
        public DateTime CreatedTime { get; set; }
        public string Text { get; set; }
        public Models.User From { get; set; }
        public string Id { get; set; }
        public int Count { get; set; }
    }
}
