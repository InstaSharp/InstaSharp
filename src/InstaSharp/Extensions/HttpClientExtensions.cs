using InstaSharp.Models.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ExecuteAsync<T>(this HttpClient client, HttpRequestMessage request) where T : Response
        {
            HttpResponseMessage response = await client.SendAsync(request);

            string resultData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(resultData);
        }
    }
}
