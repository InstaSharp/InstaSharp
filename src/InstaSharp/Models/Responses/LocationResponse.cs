using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class LocationResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public Location Data { get; set; }
    }
}
