using System.Linq;
using InstaSharp.Models.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Extensions
{
    internal static class HttpClientExtensions
    {
        private const string RateLimitRemainingHeader = "X-Ratelimit-Remaining";
        private const string RateLimitHeader = "X-Ratelimit-Limit";

        public static async Task<T> ExecuteAsync<T>(this HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);
            string resultData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(resultData);

            var endpointResponse = result as Response;

            if (endpointResponse != null)
            {
                if (response.Headers.Contains(RateLimitHeader))
                {
                    endpointResponse.RateLimitLimit =
                        response.Headers
                            .GetValues(RateLimitHeader)
                            .Select(int.Parse)
                            .SingleOrDefault();
                }

                if (response.Headers.Contains(RateLimitRemainingHeader))
                {
                    endpointResponse.RateLimitRemaining =
                        response.Headers
                            .GetValues(RateLimitRemainingHeader)
                            .Select(int.Parse)
                            .SingleOrDefault();
                }
            }

            return result;
        }
    }
}
