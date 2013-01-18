using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;

namespace InstaSharp.Endpoints {
    public class Users : InstagramAPI {

        /// <summary>
        /// User Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfiguration class</param>
        /// <param name="authInfo">An instance of the AuthInfo class</param>
        public Users(InstagramConfig config, AuthInfo authInfo = null)
            : base("/users/", config, authInfo) { }

        /// <summary>
        /// Get basic information about a user.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <paramref name="userId">The id of the user who's profile you want to retreive.</paramref>
        /// <returns>
        /// UserResponse
        /// </returns>
        public UserResponse Get(int? userId = null) {
            return (UserResponse)Mapper.Map<UserResponse>(GetJson(userId));
        }

        /// <summary>
        /// Get basic information about a user.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <paramref name="userId">The id of the user who's profile you want to retreive.</paramref>
        /// <returns>
        /// String
        /// </returns>
        private string GetJson(int? userId) {
            var uri = base.FormatUri(userId == null ? base.AuthInfo.User.Id.ToString() : userId.ToString());
            return HttpClient.GET(uri.ToString());
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <returns>
        /// MediasResponse
        /// </returns>
        public MediasResponse Feed() {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(string.Empty, 0));
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <paramref name="maxId">Return media earlier than this max_id.</paramref>
        /// <paramref name="count">Count of media to return.</paramref>
        /// <returns>MediasResponse
        /// </returns>
        public MediasResponse Feed(string maxId = "", int? count = null) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(maxId, count));
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <paramref name="maxId">Return media earlier than this max_id.</paramref>
        /// <paramref name="count">Count of media to return.</paramref>
        /// <returns>String
        /// </returns>
        private string FeedJson(string maxId, int? count) {
            var uri = base.FormatUri("self/feed");

            if (!string.IsNullOrEmpty(maxId)) uri.AppendFormat("&max_id={0}", maxId);
            if (count != null) uri.AppendFormat("&count={0}", count);

            return HttpClient.GET(uri.ToString());
        }

        /// <summary>
        /// Get the most recent media published by a user. 
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minTimestamp">Return media after this timestamp.</param>
        /// <param name="maxTimestamp">Return media before this timestamp.</param>
        /// <returns>MediasResponse</returns>
        public MediasResponse Recent(string maxId = "", string minId = "", int? count = null, DateTime? minTimestamp = null, DateTime? maxTimestamp = null) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, minId, count, minTimestamp, maxTimestamp));
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minTimestamp">Return media after this timestamp.</param>
        /// <param name="maxTimestamp">Return media before this timestamp.</param>
        /// <returns>String</returns>
        public string RecentJson(string maxId = "", string minId = "", int? count = null, DateTime? minTimestamp = null, DateTime? maxTimestamp = null) {
            var uri = base.FormatUri(string.Format("{0}/media/recent", AuthInfo.User.Id));

            if (!string.IsNullOrEmpty(maxId)) uri.AppendFormat("&max_id={0}", maxId);
            if (!string.IsNullOrEmpty(minId)) uri.AppendFormat("&min_id={0}", minId);
            if (count != null) uri.AppendFormat("&count={0}", count);
            if (minTimestamp != null) uri.AppendFormat("&min_timestamp={0}", ((DateTime)minTimestamp).ToUnixTimestamp());
            if (maxTimestamp != null) uri.AppendFormat("&max_timestamp={1}" + ((DateTime)maxTimestamp).ToUnixTimestamp());

            return HttpClient.GET(uri.ToString());
        }

        /// <summary>
        /// See the authenticated user's list of media they've liked. Note that this list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. Liked media lists are only available for the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Liked(string max_like_id = "", int? count = 20) {
            return (MediasResponse)Mapper.Map<MediasResponse>(LikedJson(max_like_id, count));
        }

        /// <summary>
        /// See the authenticated user's list of media they've liked. Note that this list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. Liked media lists are only available for the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        /// <param name="max_like_id">Return media liked before this id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <returns>String</returns>
        public string LikedJson(string max_like_id = "", int? count = 20) {
            var uri = base.FormatUri("self/media/liked");

            if (!string.IsNullOrEmpty(max_like_id)) uri.AppendFormat("&max_like_id={0}", max_like_id);
            if (count != null) uri.AppendFormat("&count={0}", count);

            return HttpClient.GET(uri.ToString());
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
        public UsersResponse Search(string searchTerm, int? count = null) {
            return (UsersResponse)Mapper.Map<UsersResponse>(SearchJson(searchTerm, count));
        }


        /// <summary>
        /// Search for a user by name.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="searchTem">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        /// <returns>String</returns>
        private string SearchJson(string searchTerm, int? count = null) {
            var uri = base.FormatUri("search");
            uri.AppendFormat("&q={0}", searchTerm);
            if (count != null) uri.AppendFormat("&count={0}", count);
            return HttpClient.GET(uri.ToString());
        }
    }
}
