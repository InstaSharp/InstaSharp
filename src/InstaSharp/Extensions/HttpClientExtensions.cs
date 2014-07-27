using InstaSharp.Models.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Extensions
{
    internal static class HttpClientExtensions
    {
        public static async Task<T> ExecuteAsync<T>(this HttpClient client, HttpRequestMessage request) // This could be constrained with   where T:Response if OAuth Inherited it
        {
            var response = await client.SendAsync(request);
            var resultData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(resultData);

            if (result is Response)
            {
                result.To<Response>().SetLimits(response);
            }
            return result;
        }
    }
}
