using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    public class Tag {
        [JsonMapping("media_count", JsonMapping.MappingType.Primitive)]
        public int MediaCount { get; set; }
        [JsonMapping("name", JsonMapping.MappingType.Primitive)]
        public string Name { get; set; }
    }
}
