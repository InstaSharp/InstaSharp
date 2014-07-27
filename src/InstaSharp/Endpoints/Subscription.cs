using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    public class Subscription
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

        private readonly InstagramConfig _config;
        private readonly HttpClient _client;

        public Subscription(InstagramConfig config)
        {
            this._config = config;
            _client = new HttpClient { BaseAddress = new Uri(config.RealTimeApi) };
        }
        private void AddClientCredentialParameters(HttpRequestMessage request)
        {
            request.AddParameter("client_id", _config.ClientId);
            request.AddParameter("client_secret", _config.ClientSecret);
        }

        /// <summary>
        /// Create a subscription
        /// </summary>
        /// <param name="type"></param>
        /// <param name="aspect"></param>
        /// <param name="objectId">This is required, i.e. if <see cref="type"/> is<see cref="Object.Tag"/> or <see cref="Object.Location"/></param>
        /// <param name="verifyToken"></param>
        /// <returns></returns>
        public Task<SubscriptionsResponse> Create(Object type, Aspect aspect, String objectId = null, String verifyToken = null)
        {
            // create a new guid that uniquely identifies this subscription request
            verifyToken = String.IsNullOrWhiteSpace(verifyToken) ? Guid.NewGuid().ToString() : verifyToken;
            var postParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", _config.ClientId),
                new KeyValuePair<string, string>("client_secret", _config.ClientSecret),
                new KeyValuePair<string, string>("object", type.ToString().ToLower()),
                new KeyValuePair<string, string>("aspect", aspect.ToString().ToLower()),
                new KeyValuePair<string, string>("verify_token", verifyToken),
                new KeyValuePair<string, string>("callback_url", _config.CallbackUri)
            };

            if ((type == Object.Tag || type == Object.Location) && objectId != null)
            {
                postParams.Add(new KeyValuePair<string, string>("object_id", objectId.ToLower()));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, _client.BaseAddress)
            {
                Content = new FormUrlEncodedContent(postParams)
            };

            return _client.ExecuteAsync<SubscriptionsResponse>(request);
        }

        /// <summary>
        /// Deletes a subscription by subscription id
        /// </summary>
        /// <param name="id">The subscription id</param>
        /// <returns></returns>
        public Task<SubscriptionsResponse> UnsubscribeUser(string id)
        {
            var request = new HttpRequestMessage { Method = HttpMethod.Delete, RequestUri = _client.BaseAddress };

            AddClientCredentialParameters(request);
            request.AddParameter("id", id);

            return _client.ExecuteAsync<SubscriptionsResponse>(request);
        }

       

        /// <summary>
        /// Deletes a subscription by type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<SubscriptionsResponse> RemoveSubscription(Object type)
        {
            var request = new HttpRequestMessage { Method = HttpMethod.Delete, RequestUri = _client.BaseAddress };

            AddClientCredentialParameters(request);
            request.AddParameter("object", type.ToString().ToLower());

            return _client.ExecuteAsync<SubscriptionsResponse>(request);
        }

        /// <summary>
        /// Removes all subscriptions
        /// </summary>
        /// <returns></returns>
        public Task<SubscriptionsResponse> RemoveAllSubscriptions()
        {
            var request = new HttpRequestMessage { Method = HttpMethod.Delete, RequestUri = _client.BaseAddress };

            AddClientCredentialParameters(request);
            request.AddParameter("object", "all");

            return _client.ExecuteAsync<SubscriptionsResponse>(request);
        }

        /// <summary>
        /// Lists all subscriptions
        /// </summary>
        /// <returns></returns>
        public Task<SubscriptionsResponse> ListAllSubscriptions()
        {
            var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = _client.BaseAddress };
            AddClientCredentialParameters(request);

            return _client.ExecuteAsync<SubscriptionsResponse>(request);
        }
    }
}
