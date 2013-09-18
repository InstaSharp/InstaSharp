using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Subscription {

        public int Id { get; set; }
        public string Type { get; set; }
        public string Object { get; set; }
        public string Aspect { get; set; }
        public string Callback_Url { get; set; }

    }
}
