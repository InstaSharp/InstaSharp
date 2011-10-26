using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    public class Media {

        [JsonMapping("location", JsonMapping.MappingType.Class)]
        public Model.Location Location { get; set; }
        
        [JsonMapping("comments", JsonMapping.MappingType.Class)]
        public Model.Comments Comments { get; set; }
        
        [JsonMapping("caption", JsonMapping.MappingType.Primitive)]
        public string Caption { get; set; }

        [JsonMapping("link", JsonMapping.MappingType.Primitive)]
        public string Link { get; set; }
        
        [JsonMapping("likes", JsonMapping.MappingType.Class)]
        public Like Likes { get; set; }
        
        [JsonMapping("created_time", JsonMapping.MappingType.Primitive)]
        public DateTime CreatedTime { get; set; }
        
        [JsonMapping("images", JsonMapping.MappingType.Class)]
        public Image Images { get; set; }
        
        [JsonMapping("type", JsonMapping.MappingType.Primitive)]
        public string Type { get; set; }
        
        [JsonMapping("filter", JsonMapping.MappingType.Primitive)]
        public string Filter { get; set; }
        
        [JsonMapping("tags", JsonMapping.MappingType.Collection)]
        public IList<string> Tags { get; set; }
        
        [JsonMapping("id", JsonMapping.MappingType.Primitive)]
        public string Id { get; set; }
        
        [JsonMapping("user", JsonMapping.MappingType.Class)]
        public User User { get; set; }
    }
}
