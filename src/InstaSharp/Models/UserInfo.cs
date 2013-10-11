using Newtonsoft.Json;
using System;

namespace InstaSharp.Models {
    public class UserInfo {
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }
    }
}
