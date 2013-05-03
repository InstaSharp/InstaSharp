using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Image {
        public Resolution LowResolution { get; set; }
        public Resolution Thumbnail { get; set; }
        public Resolution StandardResolution { get; set; }
    }

    public class Resolution {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
