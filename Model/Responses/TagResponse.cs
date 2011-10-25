using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model.Responses {
    public class TagResponse {

        public string Json { get; set; }

         [JsonMapping("data", JsonMapping.MappingType.Class)]
        public Model.Tag Response { get; set; }
    }
}
