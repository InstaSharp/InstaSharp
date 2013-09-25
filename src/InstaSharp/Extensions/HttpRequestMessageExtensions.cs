using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace InstaSharp.Extensions
{
    public static class HttpRequestMessageExtensions
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
            if (string.IsNullOrWhiteSpace(value) == false)
            {
                var uriBuilder = new UriBuilder(request.RequestUri);

                string queryToAppend = key.UrlEncode() + "=" + value.UrlEncode();

                if (uriBuilder.Query.Length > 1)
                    uriBuilder.Query = uriBuilder.Query.Substring(1) + "&" + queryToAppend;
                else
                    uriBuilder.Query = queryToAppend;

                request.RequestUri = uriBuilder.Uri;
            }
        }

        public static void AddUrlSegment(this HttpRequestMessage request, string key, string value)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            uriBuilder.Path = uriBuilder.Path.Replace("%7B" + key + "%7D", Uri.EscapeUriString(value));
            request.RequestUri = uriBuilder.Uri;
        }
    }
}
