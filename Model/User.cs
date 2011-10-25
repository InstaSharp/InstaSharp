using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {

    public class User {
        
        [JsonMapping("id", JsonMapping.MappingType.Primitive)]
        public string Id { get; set; }
        
        [JsonMapping("username", JsonMapping.MappingType.Primitive)]
        public string Username { get; set; }
        
        [JsonMapping("first_name", JsonMapping.MappingType.Primitive)]
        public string FirstName { get; set; }
        
        [JsonMapping("last_name", JsonMapping.MappingType.Primitive)]
        public string LastName { get; set; }

        [JsonMapping("full_name", JsonMapping.MappingType.Primitive)]
        public string FullName { get; set; }
        
        [JsonMapping("profile_picture", JsonMapping.MappingType.Primitive)]
        public string ProfilePicture { get; set; }

        [JsonMapping("bio", JsonMapping.MappingType.Primitive)]
        public string Bio { get; set; }
        
        [JsonMapping("website", JsonMapping.MappingType.Primitive)]
        public string Website { get; set; }
        
        [JsonMapping("counts", JsonMapping.MappingType.Class)]
        public Count Counts { get; set; }
    }
}
