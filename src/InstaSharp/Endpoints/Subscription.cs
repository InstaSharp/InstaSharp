using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
  
    public class Subscription : InstagramApi
    {
        public enum Object
        {
            User,
            Tag,
            Location,
            Geography
        }

        public enum Aspect
        {
            Media
        }


        public Subscription(InstagramConfig config)
            : base(config.RealTimeApi, config)
        {
        }

        internal override HttpRequestMessage AddAuth(HttpRequestMessage request)
        {
            request.AddParameter("client_id", InstagramConfig.ClientId);
            request.AddParameter("client_secret", InstagramConfig.ClientSecret);

            return request;
        }

        /// <summary>
        /// Create a subscription
        /// </summary>
        /// <param name="type"></param>
        /// <param name="aspect"></param>
        /// <param name="objectId">The tag name to subscribe to. This is required, i.e. if <see cref="type"/> is<see cref="Object.Tag"/> or <see cref="Object.Location"/></param>
        /// <param name="verifyToken"></param>
        /// <exception cref="ArgumentException">If objectId contains spaces and <see cref="type"/>  is objectTag </exception>
        /// <returns></returns>
        public Task<SubscriptionResponse> Create(Object type, Aspect aspect, string objectId = null, string verifyToken = null)
        {
            string searchTerm = null;
            if (type == Object.Tag || type == Object.Location)
            {
                if (string.IsNullOrWhiteSpace(objectId))
                {
                    throw new ArgumentException("objectId must be populated when type is Tag or Location", "objectId");
                }
                searchTerm = objectId.Trim().ToLower();
                if (searchTerm.ContainsWhiteSpace() && type == Object.Tag)
                {
                    throw new ArgumentException("subscribing to an objectid with spaces is ignored by Instagram", "objectId");
                }
            }

            // create a new guid that uniquely identifies this subscription request
            verifyToken = string.IsNullOrWhiteSpace(verifyToken) ? Guid.NewGuid().ToString() : verifyToken;
            var postParams = new Dictionary<string, string>
            {
                {"client_id", InstagramConfig.ClientId},
                {"client_secret", InstagramConfig.ClientSecret},
                {"object", type.ToString().ToLower()},
                {"aspect", aspect.ToString().ToLower()},
                {"verify_token", verifyToken},
                {"callback_url", InstagramConfig.CallbackUri},
            };

            if (type == Object.Tag || type == Object.Location)
            {
                postParams["object_id"] = searchTerm;
            }

            var request = Request(null, HttpMethod.Post);

            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        /// <summary>
        /// Deletes a subscription by subscription id
        /// </summary>
        /// <param name="id">The subscription id</param>
        /// <returns></returns>
        public Task<SubscriptionResponse> UnsubscribeUser(string id)
        {
            var request = Request(null, HttpMethod.Delete);
            
            request.AddParameter("id", id);

            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        /// <summary>
        /// Deletes a subscription by type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<SubscriptionResponse> RemoveSubscription(Object type)
        {
            var request = Request(null, HttpMethod.Delete);
            
            request.AddParameter("object", type.ToString().ToLower());

            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        /// <summary>
        /// Removes all subscriptions
        /// </summary>
        /// <returns></returns>
        public Task<SubscriptionResponse> RemoveAllSubscriptions()
        {
            var request = Request(null, HttpMethod.Delete);

            request.AddParameter("object", "all");

            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }

        /// <summary>
        /// Lists all subscriptions
        /// </summary>
        /// <returns></returns>
        public Task<SubscriptionResponse> ListAllSubscriptions()
        {
            var request = Request(null);
            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }
    }
}
