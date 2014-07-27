using System;
using Newtonsoft.Json;

namespace InstaSharp.Models {
    public class Subscription {

        public int Id { get; set; }
        public string Type { get; set; }
        public string Object { get; set; }
        public string Aspect { get; set; }

        [JsonProperty("Callback_Url")]
        public string CallbackUrl { get; set; }
 
        [JsonProperty("Object_Id")]
        public String ObjectId { get; set; }

    }
}
