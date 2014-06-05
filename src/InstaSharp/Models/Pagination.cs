using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace InstaSharp.Models {
    public class Pagination {
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
        [JsonProperty("next_max_id")]
        public string NextMaxId { get; set; }
        [JsonProperty("next_min_id")]
        public string NextMinId { get; set; }
    }
}
