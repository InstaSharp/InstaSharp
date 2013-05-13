using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Caption {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Text { get; set; }
        public User From { get; set; }
    }
}
