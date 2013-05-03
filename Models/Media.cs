using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Media {
        public Models.Location Location { get; set; }
        public Models.Comments Comments { get; set; }
        public string Caption { get; set; }
        public bool UserHasLiked { get; set; }
        public string Link { get; set; }
        public Like Likes { get; set; }
        public DateTime CreatedTime { get; set; }
        public Image Images { get; set; }
        public string Type { get; set; }
        public string Filter { get; set; }
        public IList<string> Tags { get; set; }
        public string Id { get; set; }
        public User User { get; set; }
    }
}
