using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints {
    public class Users : InstagramAPI {

        /// <summary>
        /// User Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfiguration class</param>
        /// <param name="OAuthResponse">An instance of the AuthInfo class</param>
        public Users(InstagramConfig config, OAuthResponse OAuthResponse = null)
            : base("users/", config, OAuthResponse) { }

        /// <summary>
        /// Get basic information about a user.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <paramref name="userId">The id of the user who's profile you want to retreive.</paramref>
        /// <returns>
        /// IRestResponse With Data Of Type UserResponse
        /// </returns>
        public Task<UserResponse> Get(string userId = null) {
            var request = base.Request("{id}");
 
            request.AddUrlSegment("id", !string.IsNullOrEmpty(userId) ? userId.ToString() : base.OAuthResponse.User.Id.ToString());

            return Client.ExecuteAsync<UserResponse>(request);
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <returns>
        /// IRestResponse With Data Of Type MediasResponse
        /// </returns>
        public Task<MediasResponse> Feed(string maxId = null, string minId = null, int? count = null)
        {
            var request = base.Request("self/feed");

            request.AddParameter("max_id", maxId);
            request.AddParameter("min_id", minId);
            request.AddParameter("count", count);

            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Get the most recent media published by the logged in user. 
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minTimestamp">Return media after this timestamp.</param>
        /// <param name="maxTimestamp">Return media before this timestamp.</param>
        /// <returns>IRestRequest With Data Of Type MediasResponse</returns>
        public Task<MediasResponse> RecentSelf(string maxId = "", string minId = "", int? count = null, DateTime? minTimestamp = null, DateTime? maxTimestamp = null)
        {
            var request = base.Request("{id}/media/recent");

            request.AddUrlSegment("id", OAuthResponse.User.Id.ToString());

            if (!string.IsNullOrEmpty(maxId)) request.AddParameter("max_id", maxId);
            if (!string.IsNullOrEmpty(minId)) request.AddParameter("min_id", minId);
            if (count.HasValue) request.AddParameter("count", count);
            if (minTimestamp.HasValue) request.AddParameter("min_timestamp", ((DateTime)minTimestamp).ToUnixTimestamp());
            if (maxTimestamp.HasValue) request.AddParameter("max_timestamp", ((DateTime)maxTimestamp).ToUnixTimestamp());

            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Get the most recent media published by a user. 
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minTimestamp">Return media after this timestamp.</param>
        /// <param name="maxTimestamp">Return media before this timestamp.</param>
        /// <returns>IRestRequest With Data Of Type MediasResponse</returns>
        public Task<MediasResponse> Recent(string id, string maxId = "", string minId = "", int? count = null, DateTime? minTimestamp = null, DateTime? maxTimestamp = null)
        {
            var request = base.Request("{id}/media/recent");

            request.AddUrlSegment("id", id);

            if (!string.IsNullOrEmpty(maxId)) request.AddParameter("max_id", maxId);
            if (!string.IsNullOrEmpty(minId)) request.AddParameter("min_id", minId);
            if (count.HasValue) request.AddParameter("count", count);
            if (minTimestamp.HasValue) request.AddParameter("min_timestamp", ((DateTime)minTimestamp).ToUnixTimestamp());
            if (maxTimestamp.HasValue) request.AddParameter("max_timestamp", ((DateTime)maxTimestamp).ToUnixTimestamp());

            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// See the authenticated user's list of media they've liked. Note that this list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. Liked media lists are only available for the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <param name="max_like_id">Return media ealier than this max_like_id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <returns>IRestResponse With Data Of Type MediasResponse</returns> 
        public Task<MediasResponse> Liked(string max_like_id = null, int? count = 20)
        {
            var request = base.Request("self/media/liked");

            request.AddParameter("max_like_id", max_like_id);
            request.AddParameter("count", count);

            return base.Client.ExecuteAsync<MediasResponse>(request);            
        }

        /// <summary>
        /// Search for a user by name.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="searchTem">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        /// <returns>UsersResponse</returns>
        public Task<UsersResponse> Search(string searchTerm, int? count = null) {
            var request = base.Request("search");

            request.AddParameter("q", searchTerm);
            request.AddParameter("count", count);

            return base.Client.ExecuteAsync<UsersResponse>(request);
        }
    }
}
