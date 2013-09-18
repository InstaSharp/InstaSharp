using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class TagResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public Models.Tag Data { get; set; }
    }
}
