using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Users API
    /// </summary>
    public class Users : InstagramApi
    {
        /// <summary>
        /// User Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfiguration class</param>
        public Users(InstagramConfig config) : this(config, null)
        {

        }

        /// <summary>
        /// User Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfiguration class</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Users(InstagramConfig config, OAuthResponse auth) : base("users/", config, auth)
        {
            
        }

        /// <summary>
        /// Get information about authenticated user.
        /// <para>Requires Authentication: True</para>
        /// </summary>
        /// <returns>User response</returns>
        public Task<UserResponse> Get()
        {
            return Get(null);
        }

        /// <summary>
        /// Get information about a user.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>user response</returns>
        /// <paramref name="userId">The id of the user who's profile you want to retreive.</paramref>
        public Task<UserResponse> Get(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                AssertIsAuthenticated();
            }

            var request = Request("{id}");

            request.AddUrlSegment("id", !string.IsNullOrEmpty(userId) ? userId : OAuthResponse.User.Id.ToString());

            return Client.ExecuteAsync<UserResponse>(request);
        }

        /// <summary>
        /// Get information about authenticated user.
        /// <para>Requires Authentication: True</para>
        /// </summary>
        /// <returns>User response</returns>
        public Task<UserResponse> GetSelf()
        {
            AssertIsAuthenticated();

            var request = Request("self");

            return Client.ExecuteAsync<UserResponse>(request);
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>Requires Authentication: True</para>
        /// </summary>
        /// <param name="maxId">The maximum identifier.</param>
        /// <param name="minId">The minimum identifier.</param>
        /// <param name="count">The count.</param>
        /// <returns>Media Response</returns>
        public Task<MediasResponse> Feed(string maxId, string minId, int? count)
        {
            var request = Request("self/feed");

            request.AddParameter("max_id", maxId);
            request.AddParameter("min_id", minId);
            request.AddParameter("count", count);

            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Get the most recent media published by the logged in user.
        /// <para>Requires Authentication: True</para>
        /// </summary>
        /// <returns>Media Response</returns>
        public Task<MediasResponse> RecentSelf()
        {
            return RecentSelf(null, null, null, null, null);
        }

        /// <summary>
        /// Get the most recent media published by the logged in user. 
        /// <para>Requires Authentication: True</para>
        /// </summary>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minTimestamp">Return media after this timestamp.</param>
        /// <param name="maxTimestamp">Return media before this timestamp.</param>   
        /// <returns>Media Response</returns>
        public Task<MediasResponse> RecentSelf(string maxId, string minId, int? count, DateTime? minTimestamp, DateTime? maxTimestamp)
        {
            AssertIsAuthenticated();

            return Recent(OAuthResponse.User.Id.ToString(), maxId, minId, count, minTimestamp, maxTimestamp);
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>Media Response</returns>
        public Task<MediasResponse> Recent(string id)
        {
            return Recent(id, null, null, null, null, null);
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minTimestamp">Return media after this timestamp.</param>
        /// <param name="maxTimestamp">Return media before this timestamp.</param>
        /// <returns>Media Response</returns>
        public Task<MediasResponse> Recent(string id, string maxId, string minId, int? count, DateTime? minTimestamp, DateTime? maxTimestamp)
        {
            var request = Request("{id}/media/recent");

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
        /// <para>Requires Authentication: True</para>
        /// </summary>
        /// <param name="maxLikeId">Return media ealier than this maxLikeId.</param>
        /// <param name="count">Count of media to return.</param>
        /// <returns>Media Response</returns>
        public Task<MediasResponse> Liked(string maxLikeId, int? count)
        {
            AssertIsAuthenticated();

            var request = Request("self/media/liked");

            request.AddParameter("max_like_id", maxLikeId);
            request.AddParameter("count", count);

            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Search for a user by name.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="searchTerm">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        /// <returns>User response</returns>
        public Task<UsersResponse> Search(string searchTerm, int? count)
        {
            var request = Request("search");

            request.AddParameter("q", searchTerm);
            request.AddParameter("count", count);

            return Client.ExecuteAsync<UsersResponse>(request);
        }
    }
}
