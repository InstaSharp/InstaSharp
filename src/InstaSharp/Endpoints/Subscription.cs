using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{

    /// <summary>
    /// The subscription Api
    /// </summary>
    public class Subscription : InstagramApi
    {
        /// <summary>
        /// The type of media
        /// </summary>
        public enum Object
        {
            /// <summary>
            /// User
            /// </summary>
            User,
        }

        /// <summary>
        /// Aspect, Can only be media type currently
        /// </summary>
        public enum Aspect
        {
            /// <summary>
            /// Media
            /// </summary>
            Media
        }


        /// <summary>
        /// Construct a Subscription Endpoint
        /// </summary>
        /// <param name="config">An instagram config object</param>
        public Subscription(InstagramConfig config)
            : base(config.RealTimeApi, config)
        {
        }

        protected override HttpRequestMessage AddAuth(HttpRequestMessage request)
        {
            request.AddParameter("client_id", InstagramConfig.ClientId);
            request.AddParameter("client_secret", InstagramConfig.ClientSecret);

            return request;
        }

        /// <summary>
        /// Creates a user subscription.
        /// </summary>
        /// <param name="verifyToken">The verify token.</param>
        /// <returns>Check the Meta Property for any errors. E.G. Meta.Code =HttpStatusCode.BadRequest, ErrorType="APISubscriptionError" and ErrorMessage="Unable to reach callback URL [url] will be set if the callback url has issues"</returns>
        public Task<SubscriptionResponse> CreateUser(String verifyToken = null)
        {
            var postParams = PostParams(Object.User, verifyToken);
            return ExecuteAsync(postParams);
        }

        private Task<SubscriptionResponse> ExecuteAsync(Dictionary<string, string> postParams)
        {
            var request = Request(null, HttpMethod.Post);
            request.Content = new FormUrlEncodedContent(postParams);
            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        private Dictionary<string, string> PostParams(Object type, string verifyToken)
        {
            // create a new guid that uniquely identifies this subscription request
            verifyToken = string.IsNullOrWhiteSpace(verifyToken) ? Guid.NewGuid().ToString() : verifyToken;
            var postParams = new Dictionary<string, string>
            {
                {"client_id", InstagramConfig.ClientId},
                {"client_secret", InstagramConfig.ClientSecret},
                {"object", type.ToString().ToLower()},
                {"aspect", Aspect.Media.ToString().ToLower()},
                {"verify_token", verifyToken},
                {"callback_url", InstagramConfig.CallbackUri},
            };
            return postParams;
        }

        /// <summary>
        /// Deletes a subscription by subscription id
        /// </summary>
        /// <param name="id">The subscription id</param>
        /// <returns>Subscription Response</returns>
        public Task<SubscriptionResponse> RemoveSubscription(string id)
        {
            var request = Request(null, HttpMethod.Delete);

            request.AddParameter("id", id);

            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        /// <summary>
        /// Deletes a subscription by type
        /// </summary>
        /// <param name="type">The <see cref="Object"/> type</param>
        /// <returns>Subscription Response</returns>
        public Task<SubscriptionResponse> RemoveSubscription(Object type)
        {
            var request = Request(null, HttpMethod.Delete);

            request.AddParameter("object", type.ToString().ToLower());

            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        /// <summary>
        /// Removes all subscriptions
        /// </summary>
        /// <returns>Subscription Response</returns>
        public Task<SubscriptionResponse> RemoveAllSubscriptions()
        {
            var request = Request(null, HttpMethod.Delete);

            request.AddParameter("object", "all");

            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        /// <summary>
        /// Lists all subscriptions
        /// </summary>
        /// <returns>Subscription Response</returns>
        public Task<SubscriptionsResponse> ListAllSubscriptions()
        {
            var request = Request(null);
            return Client.ExecuteAsync<SubscriptionsResponse>(request);
        }
    }
}
