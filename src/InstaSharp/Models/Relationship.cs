using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Relationship {
        public string OutgoingStatus { get; set; }
        public string IncomingStatus { get; set; }
        public bool TargetUserIsPrivate { get; set; }
    }

}
