using System.Linq;
using System.Net.Http;

namespace InstaSharp.Models.Responses
{
    public abstract class Response
    {
        public Meta Meta { get; set; }
        public void SetLimits(HttpResponseMessage responseMesssage)
        {
            RateLimitRemaining = responseMesssage.Headers.GetValues("X-Ratelimit-Remaining").FirstOrDefault();
            RateLimitLimit = responseMesssage.Headers.GetValues("X-Ratelimit-Limit").FirstOrDefault();
        }

        /// <summary>
        /// The remaining number of calls available to your app within the 1-hour window
        /// </summary>
        public string RateLimitRemaining { get; private set; }

        /// <summary>
        /// the total number of calls allowed within the 1-hour window
        /// </summary>
        public string RateLimitLimit { get; private set; }
    }
}
