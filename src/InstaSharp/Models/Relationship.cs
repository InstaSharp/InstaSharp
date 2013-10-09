using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace InstaSharp.Models
{
    public class Relationship
    {
        [JsonProperty("outgoing_status")]
        public string OutgoingStatus { get; set; }

        [JsonProperty("incoming_status")]
        public string IncomingStatus { get; set; }

        [JsonProperty("target_user_is_private")]
        public bool TargetUserIsPrivate { get; set; }
    }

}
