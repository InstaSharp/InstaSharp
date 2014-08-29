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
            /// <summary>
            /// Tag
            /// </summary>
            Tag,
            /// <summary>
            /// Location
            /// </summary>  
            Location,
            /// <summary>
            /// Geography
            /// </summary>
            Geography
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

        internal override HttpRequestMessage AddAuth(HttpRequestMessage request)
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

        /// <summary>
        /// Creates a tag subscription.
        /// </summary>
        /// <param name="tag">The hashtag, e.g. 'csharp'</param>
        /// <param name="verifyToken">The verify token.</param>
        /// <returns>
        /// Check the Meta Property for any errors. E.G. Meta.Code =HttpStatusCode.BadRequest, ErrorType="APISubscriptionError" and ErrorMessage="Unable to reach callback URL [url] will be set if the callback url has issues"
        /// </returns>
        /// <exception cref="System.ArgumentException">tag must be populated;tag
        /// or
        /// subscribing to a tag with spaces is ignored by Instagram;tag</exception>
        public Task<SubscriptionResponse> CreateTag(string tag, String verifyToken = null)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentException("tag must be populated", "tag");
            }
            var searchTerm = tag.Trim().ToLower();
            if (searchTerm.ContainsWhiteSpace())
            {
                throw new ArgumentException("subscribing to a tag with spaces is ignored by Instagram", "tag");
            }
            var postParams = PostParams(Object.Tag, verifyToken);
            postParams["object_id"] = searchTerm;
            return ExecuteAsync(postParams);
        }

        /// <summary>
        /// Creates a location subscription.
        /// </summary>
        /// <param name="locationId">The locationId, e.g. '1257285'</param>
        /// <param name="verifyToken">The verify token.</param>
        /// <returns>
        /// Check the Meta Property for any errors. E.G. Meta.Code =HttpStatusCode.BadRequest, ErrorType="APISubscriptionError" and ErrorMessage="Unable to reach callback URL [url] will be set if the callback url has issues"
        /// </returns>
        /// <exception cref="System.ArgumentException">locationId must be populated;locationId</exception>
        public Task<SubscriptionResponse> CreateLocation(String locationId, String verifyToken = null)
        {
            if (string.IsNullOrWhiteSpace(locationId))
            {
                throw new ArgumentException("locationId must be populated", "locationId");
            }
            var postParams = PostParams(Object.Location, verifyToken);
            postParams["object_id"] = locationId;
            return ExecuteAsync(postParams);
        }

        /// <summary>
        /// Creates a geography subscription.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="radius">The radius. Must be less than 5000m</param>
        /// <param name="verifyToken">The verify token.</param>
        /// <returns>
        /// Check the Meta Property for any errors. E.G. Meta.Code =HttpStatuu stil lcomin over tonmgsCode.BadRequest, ErrorType="APISubscriptionError" and ErrorMessage="Unable to reach callback URL [url] will be set if the callback url has issues"
        /// </returns>
        /// <exception cref="System.ArgumentException">radius must be greater than 0 and less tha 5000;radius</exception>
        public Task<SubscriptionResponse> CreateGeography(double latitude, double longitude, int radius, String verifyToken = null)
        {
            if (radius < 0 || radius > 5000)
            {
                throw new ArgumentException("radius must be greater than 0 and less tha 5000", "radius");
            }
            var postParams = PostParams(Object.Geography, verifyToken);
            postParams["lat"] = latitude.ToString();
            postParams["lng"] = latitude.ToString();
            postParams["radius"] = radius.ToString();
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
        public Task<SubscriptionResponse> ListAllSubscriptions()
        {
            var request = Request(null);
            return Client.ExecuteAsync<SubscriptionResponse>(request);
        }
    }
}
