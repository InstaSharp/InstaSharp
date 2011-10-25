using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    public class Pagination {

        [JsonMapping("next_url", JsonMapping.MappingType.Primitive)]
        public string NextUrl { get; set; }
        
        [JsonMapping("next_max_id", JsonMapping.MappingType.Primitive)]
        public string NextMaxId { get; set; }
    }
}
