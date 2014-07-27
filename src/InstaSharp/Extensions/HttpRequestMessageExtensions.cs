using System;
using System.Globalization;
using System.Net.Http;

namespace InstaSharp.Extensions
{
    internal static class HttpRequestMessageExtensions
    {
        public static void AddParameter(this HttpRequestMessage request, string key, IFormattable value)
        {
            if (value != null)
            {
                request.AddParameter(key, value.ToString(null, CultureInfo.InvariantCulture));
            }
        }
        public static void AddParameter(this HttpRequestMessage request, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }
            var uriBuilder = new UriBuilder(request.RequestUri);
            var queryToAppend = key.UrlEncode() + "=" + value.UrlEncode();
            uriBuilder.Query = uriBuilder.Query.Length > 1? uriBuilder.Query.Substring(1) + "&" + queryToAppend
                                                          : queryToAppend;

            request.RequestUri = uriBuilder.Uri;
        }

        public static void AddUrlSegment(this HttpRequestMessage request, string key, string value)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            uriBuilder.Path = uriBuilder.Path.Replace("%7B" + key + "%7D", Uri.EscapeUriString(value));
            request.RequestUri = uriBuilder.Uri;
        }
    }
}
