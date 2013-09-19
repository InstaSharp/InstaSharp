using System;
using System.Net.Http;

namespace InstaSharp.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static void AddParameter(this HttpRequestMessage request, string key, object value)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);

            string queryToAppend = key.UrlEncode() + "=" + value.ToString().UrlEncode();

            if (uriBuilder.Query.Length > 1)
                uriBuilder.Query = uriBuilder.Query.Substring(1) + "&" + queryToAppend;
            else
                uriBuilder.Query = queryToAppend;

            request.RequestUri = uriBuilder.Uri;
        }

        public static void AddUrlSegment(this HttpRequestMessage request, string key, string value)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            uriBuilder.Path = uriBuilder.Path.Replace("{" + key + "}", Uri.EscapeUriString(value));
            request.RequestUri = uriBuilder.Uri;
        }
    }
}
