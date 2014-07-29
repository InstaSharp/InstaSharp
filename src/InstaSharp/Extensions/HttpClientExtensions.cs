using System.Linq;
using InstaSharp.Models.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Extensions
{
    internal static class HttpClientExtensions
    {
        public static async Task<T> ExecuteAsync<T>(this HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);
            string resultData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(resultData);

            var endpointResponse = result as Response;

            if (endpointResponse != null)
            {
                endpointResponse.RateLimitLimit = response.Headers.GetValues("X-Ratelimit-Limit").Select(int.Parse).SingleOrDefault();
                endpointResponse.RateLimitRemaining = response.Headers.GetValues("X-Ratelimit-Remaining").Select(int.Parse).SingleOrDefault();
            }

            return result;
        }
    }
}
