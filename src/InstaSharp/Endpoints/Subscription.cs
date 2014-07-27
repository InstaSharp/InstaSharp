using System.IO;
using System.Linq;
using System.Net;
using InstaSharp.Extensions;
using InstaSharp.Models;
using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        private static RealTimeMediaUpdateCache _realTimeMediaUpdateCache;

        public Subscription(InstagramConfig config, RealTimeMediaUpdateCache realTimeMediaUpdateCache = null)
        {
            _config = config;
            _client = new HttpClient { BaseAddress = new Uri(config.RealTimeApi) };
            _realTimeMediaUpdateCache = realTimeMediaUpdateCache ?? new RealTimeMediaUpdateCache();
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

        /// <summary>
        /// When someone posts a new photo and it triggers an update of one of your subscriptions, Instagram makes a POST request to the callback URL that you defined in the subscription. 
        /// The post body contains a raw text JSON body with update objects
        /// </summary>
        /// <param name="updatedMediaItems"></param>
        /// <returns></returns>

        public List<RealtimeUpdateItem> DeserializeUpdatedMediaItems(Stream updatedMediaItems)
        {
            using (var str = new StreamReader(updatedMediaItems))
            {
                return JsonConvert.DeserializeObject<IEnumerable<RealtimeUpdateItem>>(str.ReadToEnd()).ToList();
            }
        }

        /// <summary>
        /// "When someone posts a new photo and it triggers an update of one of your subscriptions, Instagram makes a POST request to the callback URL that you defined in the subscription. 
        /// The post body contains a raw text JSON body with update objects."
        /// The kicker is that it doesnt return the objectIds so you can go and snag them, so this implementation grabs recent items that have not been recently grabbed
        /// This method grabs tag media types only </summary>
        /// <param name="updatedMediaItems"></param>
        /// <param name="maxPageCount">set a reasonable limit on how much will be pulled back</param>
        /// <param name="tagIdPersisterCallback">This callback is invoked with the tag name and the most recent id</param>
        /// <returns></returns>
        /// remarks>See http://stackoverflow.com/questions/18589445/instagram-realtime-api-does-not-return-content-ids#</remarks>
        public async Task<UpdatedRealTimeItems> GetUpdatedTagMediaItems(Stream updatedMediaItems, int maxPageCount = 2, Action<string, string> tagIdPersisterCallback = null)
        {
            var result = new UpdatedRealTimeItems();
            var newMediaItems = DeserializeUpdatedMediaItems(updatedMediaItems);

            var tags = new Tags(_config);
            foreach (var tagName in newMediaItems.Where(x => x.ObjectId != null && x.Object == "tag").Select(x => x.ObjectId)) //InstaSharp.Endpoints.Subscription.Object.Tag.ToString().ToLower()
            {
                string mostRecentMediaIdForTagName = _realTimeMediaUpdateCache.MostRecentMediaTagId(tagName);
                var query = mostRecentMediaIdForTagName != null ? tags.RecentMultiplePages(tagName, mostRecentMediaIdForTagName, null, maxPageCount)
                                                                : tags.RecentMultiplePages(tagName, null, null, maxPageCount);
                var mediasResponse = await query;
                if (mediasResponse.Meta.Code == (int)HttpStatusCode.OK)
                {
                    if (mediasResponse.Data.Any())
                    {
                        var lastId = mediasResponse.Data.Last().Id;
                        if (mostRecentMediaIdForTagName == null)
                        {
                            _realTimeMediaUpdateCache.MostRecentMediaTagIds.Add(tagName, lastId);
                            if (tagIdPersisterCallback != null)
                            {
                                tagIdPersisterCallback(tagName, lastId);
                            }
                        }
                        result.AddTag(tagName, mediasResponse.Data);
                    }
                }
            }
            return result;
        }
    }
}
