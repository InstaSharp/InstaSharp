using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class RelationshipResponse : IResponse {
        public Meta Meta { get; set; }
        public Relationship Data { get; set; }
    }
}
