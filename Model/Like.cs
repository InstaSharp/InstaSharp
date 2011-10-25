using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace InstaSharp.Model {
    public class Like {
        [JsonMapping("count", JsonMapping.MappingType.Primitive)]
        public int Count { get; set; }
        [JsonMapping("data", JsonMapping.MappingType.Collection)]
        public IList<LikesData> Data { get; set; }
    }

    public class LikesData {
        [JsonMapping("username", JsonMapping.MappingType.Primitive)]
        public string Username { get; set; }
        [JsonMapping("full_name", JsonMapping.MappingType.Primitive)]
        public string FullName { get; set; }
        [JsonMapping("id", JsonMapping.MappingType.Primitive)]
        public int Id { get; set; }
        [JsonMapping("profile_picture", JsonMapping.MappingType.Primitive)]
        public string ProfilePicture { get; set; }
        [JsonMapping("likes", JsonMapping.MappingType.Collection)]
        public List<Like> Likes { get; set; }
    }
}
