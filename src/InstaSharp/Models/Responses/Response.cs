using System.Linq;
using System.Net.Http;

namespace InstaSharp.Models.Responses
{
    public abstract class Response
    {
        public Meta Meta { get; set; }
        public void SetLimits(HttpResponseMessage responseMesssage)
        {
            CallsRemainingThisHour = responseMesssage.Headers.GetValues("X-Ratelimit-Remaining").FirstOrDefault();
            TotalHourlyCallLimit = responseMesssage.Headers.GetValues("X-Ratelimit-Limit").FirstOrDefault();
        }

        /// <summary>
        /// The remaining number of calls available to your app within the 1-hour window
        /// </summary>
        public string CallsRemainingThisHour { get; private set; }

        /// <summary>
        /// the total number of calls allowed within the 1-hour window
        /// </summary>
        public string TotalHourlyCallLimit { get; private set; }
    }
}
