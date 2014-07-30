using System.Net;
using Newtonsoft.Json;

namespace InstaSharp.Models
{
    public class Meta
    {
        public HttpStatusCode Code { get; set; }

        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
