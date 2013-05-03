using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Subscription {

        public enum Object {
            User,
            Tag,
            Location,
            Geography
        }

        public enum Aspect {
            Media
        }

        public string Mode { get; set; }
        public string Challenge { get; set; }
        public string VerifyToken { get; set; }

    }
}
