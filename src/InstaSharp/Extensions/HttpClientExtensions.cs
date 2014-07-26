using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InstaSharp.Models.Responses;
using Newtonsoft.Json;

namespace InstaSharp.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ExecuteAsync<T>(this HttpClient client, HttpRequestMessage request)
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string resultData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(resultData);
        }

        /// <summary>
        /// Executes async, casts result to <see cref="IResponse"/> on failure preserving meta data error response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> ExecuteAsyncWithMeta<T>(this HttpClient client, HttpRequestMessage request) where T : IResponse
        {
            var response = await client.SendAsync(request);
            var resultData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resultData);
        }
    }
}
