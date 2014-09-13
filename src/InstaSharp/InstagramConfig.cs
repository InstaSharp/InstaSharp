using System;

namespace InstaSharp
{
    /// <summary>
    /// The Configuration
    /// </summary>
    public class InstagramConfig
    {
        private const string ApiUriDefault = "https://api.instagram.com/v1/";
        private const string OAuthUriDefault = "https://api.instagram.com/oauth/";
        private const string RealTimeApiDefault = "https://api.instagram.com/v1/subscriptions/";
        /// <summary>
        /// Gets or sets the API URI.
        /// </summary>
        /// <value>
        /// The API URI.
        /// </value>
        public string ApiUri { get; set; }
        /// <summary>
        /// Gets or sets the o authentication URI.
        /// </summary>
        /// <value>
        /// The o authentication URI.
        /// </value>
        public string OAuthUri { get; set; }
        /// <summary>
        /// Gets or sets the real time API.
        /// </summary>
        /// <value>
        /// The real time API.
        /// </value>
        public string RealTimeApi { get; set; }
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        /// <value>
        /// The client secret.
        /// </value>
        public string ClientSecret { get; set; }
        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        /// <value>
        /// The redirect URI.
        /// </value>
        public string RedirectUri { get; set; }
        /// <summary>
        /// Gets or sets the callback URI.
        /// </summary>
        /// <value>
        /// The callback URI.
        /// </value>
        public string CallbackUri { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstagramConfig"/> class.
        /// </summary>
        public InstagramConfig()
            : this(null, null, null, null, ApiUriDefault, OAuthUriDefault, RealTimeApiDefault)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstagramConfig"/> class.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        public InstagramConfig(string clientId, string clientSecret)
            : this(clientId, clientSecret, null, null, ApiUriDefault, OAuthUriDefault, RealTimeApiDefault)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstagramConfig"/> class.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        public InstagramConfig(string clientId, string clientSecret, string redirectUri)
            : this(clientId, clientSecret, redirectUri, null, ApiUriDefault, OAuthUriDefault, RealTimeApiDefault)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="InstagramConfig"/> class.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        public InstagramConfig(string clientId, string clientSecret, string redirectUri, string callbackUri)
            : this(clientId, clientSecret, redirectUri, callbackUri, ApiUriDefault, OAuthUriDefault, RealTimeApiDefault)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstagramConfig"/> class.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="redirectUri">The redirect URI.</param>
        /// <param name="callbackUri">The callback URI.</param>
        /// <param name="apiUri">The API URI.</param>
        /// <param name="oauthUri">The oauth URI.</param>
        /// <param name="realTimeApi">The real time API.</param>
        public InstagramConfig(string clientId, string clientSecret, string redirectUri, string callbackUri, string apiUri, string oauthUri, string realTimeApi)
        {
            ApiUri = apiUri;
            OAuthUri = oauthUri;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
            RealTimeApi = realTimeApi;
            CallbackUri = callbackUri;
        }
    }
}
