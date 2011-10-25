using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    public class Count {
        [JsonMapping("media", JsonMapping.MappingType.Primitive)]
        public int Media { get; set; }
        [JsonMapping("follows", JsonMapping.MappingType.Primitive)]
        public int Follows { get; set; }
        [JsonMapping("followed_by", JsonMapping.MappingType.Primitive)]
        public int FollowedBy { get; set; }
    }
}
