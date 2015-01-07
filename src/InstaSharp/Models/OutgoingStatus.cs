using Newtonsoft.Json;

namespace InstaSharp.Models
{
    public enum OutgoingStatus
    {
        [JsonProperty("follows")]
        Follows,
        [JsonProperty("requested")]
        Requested,
        [JsonProperty("none")]
        None
    }
}