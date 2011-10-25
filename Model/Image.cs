using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    public class Image {
        [JsonMapping("low_resolution", JsonMapping.MappingType.Class)]
        public Resolution LowResolution { get; set; }
        [JsonMapping("thumbnail", JsonMapping.MappingType.Class)]
        public Resolution Thumbnail { get; set; }
        [JsonMapping("standard_resolution", JsonMapping.MappingType.Class)]
        public Resolution StandardResolution { get; set; }
    }

    public class Resolution {
        [JsonMapping("url", JsonMapping.MappingType.Primitive)]
        public string Url { get; set; }
        [JsonMapping("width", JsonMapping.MappingType.Primitive)]
        public int Width { get; set; }
        [JsonMapping("height", JsonMapping.MappingType.Primitive)]
        public int Height { get; set; }
    }
}
