using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace InstaSharp {
    public static class HttpClient {
        public static string GET(string uri) {
            try {
                var request = HttpWebRequest.Create(uri);
                request.Method = "GET";

                return ReadResponse(request.GetResponse().GetResponseStream());
            }
            catch (WebException ex) {
                return ReadResponse(ex.Response.GetResponseStream());
            }
        }

        public static string POST(string url) {
            return POST(url, new Dictionary<string, string>());
        }

        public static string POST(string url, IDictionary<string, string> args) {
            try {
                NameValueCollection parameters = new NameValueCollection();
                foreach (var arg in args) {
                    parameters.Add(arg.Key, arg.Value);
                }

                WebClient client = new WebClient();

                var result = client.UploadValues(url, "POST", parameters);

                return Encoding.Default.GetString(result);
            }
            catch (WebException ex) {
                return ReadResponse(ex.Response.GetResponseStream());
            }
        }

        public static string DELETE(string uri) {
            var request = HttpWebRequest.Create(uri);
            request.Method = "DELETE";

            return DELETE(uri, new Dictionary<string, string>());

            // return ReadResponse(request.GetResponse().GetResponseStream());
        }

        public static string DELETE(string uri, IDictionary<string, string> args) {
            try {
                NameValueCollection parameters = new NameValueCollection();
                foreach (var arg in args) {
                    parameters.Add(arg.Key, arg.Value);
                }

                WebClient client = new WebClient();

                var result = client.UploadValues(uri, "DELETE", parameters);

                return Encoding.Default.GetString(result);
            }
            catch (WebException ex) {
                return ReadResponse(ex.Response.GetResponseStream());
            }
        }

        private static string ReadResponse(Stream response) {
            StreamReader reader = new StreamReader(response);
            string line;
            StringBuilder result = new StringBuilder();
            while ((line = reader.ReadLine()) != null) {
                result.Append(line);
            }
            return result.ToString();
        }
    }
}
