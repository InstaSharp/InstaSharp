using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    public class Relationship {
        [JsonMapping("outgoing_status", JsonMapping.MappingType.Primitive)]
        public string OutgoingStatus { get; set; }
        [JsonMapping("incoming_status", JsonMapping.MappingType.Primitive)]
        public string IncomingStatus { get; set; }
    }

}
