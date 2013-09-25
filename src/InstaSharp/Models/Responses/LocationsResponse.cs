using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class LocationsResponse : IResponse {
        public Models.Meta Meta { get; set; }
        public List<Location> Data { get; set; }
    }
}
