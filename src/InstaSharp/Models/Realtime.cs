using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Realtime {

        public int SubScription_ID { get; set; }
        public string Object { get; set; }
        public string Object_ID { get; set; }
        public string Changed_Aspect { get; set; }
        public string Time { get; set; }
    
    }
}
