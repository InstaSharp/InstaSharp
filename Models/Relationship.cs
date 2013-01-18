using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Relationship {
        [JsonMapping("outgoing_status", JsonMapping.MappingType.Primitive)]
        public string OutgoingStatus { get; set; }
        [JsonMapping("incoming_status", JsonMapping.MappingType.Primitive)]
        public string IncomingStatus { get; set; }
        [JsonMapping("target_user_is_private", JsonMapping.MappingType.Primitive)]
        public bool TargetUserIsPrivate { get; set; }
    }

}
