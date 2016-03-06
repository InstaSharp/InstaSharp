using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InstaSharp.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IncomingStatus
    {
        [EnumMember(Value = "followed_by")]
        FollowedBy,
        [EnumMember(Value = "requested_by")]
        RequestedBy,
        [EnumMember(Value = "blocked_by_you")]
        BlockedbyYou,
        [EnumMember(Value = "none")]
        None
    }
}