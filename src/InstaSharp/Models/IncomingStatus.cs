using Newtonsoft.Json;

namespace InstaSharp.Models
{
    public enum IncomingStatus
    {
        [JsonProperty("followed_by")]
        FollowedBy,
        [JsonProperty("requested_by")]
        RequestedBy,
        [JsonProperty("blocked_by_you")]
        BlockedbyYou,
        [JsonProperty("none")]
        None
    }
}