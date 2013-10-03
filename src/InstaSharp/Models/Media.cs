using InstaSharp.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InstaSharp.Models {
    public class Media {
        public Location Location { get; set; }
        public Comments Comments { get; set; }
        public Caption Caption { get; set; }
        public bool UserHasLiked { get; set; }
        public string Link { get; set; }
        public Likes Likes { get; set; }
        [JsonProperty("created_time"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedTime { get; set; }
        public Image Images { get; set; }
        public string Type { get; set; }
        public string Filter { get; set; }
        public List<string> Tags { get; set; }
        public string Id { get; set; }
        public User User { get; set; }
    }
}
