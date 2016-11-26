using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// Base class for Apis
    /// </summary>
    public abstract class InstagramApi
    {
        /// <summary>
        /// Gets the instagram configuration.
        /// </summary>
        /// <value>
        /// The instagram configuration.
        /// </value>
        public InstagramConfig InstagramConfig { get; private set; }

        /// <summary>
        /// Gets the o authentication response.
        /// </summary>
        /// <value>
        /// The o authentication response.
        /// </value>
        public OAuthResponse OAuthResponse { get; private set; }

        protected HttpClient Client { get; private set; }

        public bool EnforceSignedRequests { get; set; }

        internal InstagramApi(string endpoint, InstagramConfig instagramConfig)
            : this(endpoint, instagramConfig, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstagramApi"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="instagramConfig">The instagram configuration.</param>
        /// <param name="oauthResponse">The oauth response.</param>
        protected InstagramApi(string endpoint, InstagramConfig instagramConfig, OAuthResponse oauthResponse)
        {
            InstagramConfig = instagramConfig;
            OAuthResponse = oauthResponse;

            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip |
                                                 DecompressionMethods.Deflate;
            }

            Client = new HttpClient(handler) { BaseAddress = new Uri(new Uri(InstagramConfig.ApiUri), endpoint) };
        }

        /// <summary>
        /// Asserts if the user is authenticated.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">You are not authenticated</exception>
        protected void AssertIsAuthenticated()
        {
            if (OAuthResponse == null || OAuthResponse.User == null)
            {
                throw new InvalidOperationException("You are not authenticated");
            }
        }

        internal HttpRequestMessage Request(string fragment, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, new Uri(Client.BaseAddress, fragment));
            AddAuth(request);

            AddSignature(request);

            return request;
        }

        /// <param name="request"></param>
        private void AddSignature(HttpRequestMessage request)
        {
            if (EnforceSignedRequests && !String.IsNullOrWhiteSpace(InstagramConfig.ClientSecret))
            {
                request.AddParameter("sig", CreateRequestSignature(request));
            }
        }

        private string CreateRequestSignature(HttpRequestMessage request)
        {
            var valueToHash = request.RequestUri.AbsolutePath.StartsWith("/v1/") ? request.RequestUri.AbsolutePath.Substring(3) :  request.RequestUri.AbsolutePath;

            var queryParams = string.Join("|", request.RequestUri.Query.Substring(1).Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x));

            if(queryParams.Length > 0)
            {
                valueToHash = valueToHash + "|" + queryParams;
            }            

            var hash = Hash(InstagramConfig.ClientSecret, valueToHash);
            var digest = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return digest;
        }

        private static byte[] Hash(string key, string text)
        {
            var hmac = new HMac(new Sha256Digest());
            hmac.Init(new KeyParameter(Encoding.UTF8.GetBytes(key)));
            byte[] result = new byte[hmac.GetMacSize()];
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            hmac.BlockUpdate(bytes, 0, bytes.Length);
            hmac.DoFinal(result, 0);

            return result;
        }

        internal HttpRequestMessage Request(string fragment)
        {
            return Request(fragment, HttpMethod.Get);
        }

        protected virtual HttpRequestMessage AddAuth(HttpRequestMessage request)
        {
            if (OAuthResponse == null)
            {
                request.AddParameter("client_id", InstagramConfig.ClientId);
            }
            else
            {
                request.AddParameter("access_token", OAuthResponse.AccessToken);
            }

            return request;
        }
    }
}
