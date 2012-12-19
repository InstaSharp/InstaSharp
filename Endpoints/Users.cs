using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Users {
    public class Users : InstagramAPI {

        readonly Unauthenticated _unauthenticated;

        public Users(InstagramConfig config, AuthInfo authInfo)
            : base(config, authInfo, "/users/") {
                _unauthenticated = new Unauthenticated(config);
        }

        /// <summary>
        /// Get basic information about a user.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        public UserResponse Get() {
            return (Model.Responses.UserResponse)Mapper.Map<Model.Responses.UserResponse>(GetJson(AuthInfo.User.Id));
        }

        /// <summary>
        /// Get basic information about a user.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <para>
        /// <paramref name="userId"/>: The id of the user who's profile you want to retreive.
        /// </para>
        /// </summary>
        public UserResponse Get(int userId) {
            return (UserResponse)Mapper.Map<UserResponse>(GetJson(userId));
        }

        private string GetJson(int userId) {
            string uri = string.Format(base.Uri + "{0}/?client_id={1}", userId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Feed() {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(string.Empty, 0));
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// <para>
        /// <paramref name="maxId"/>: Return media earlier than this max_id.
        /// </para>
        /// </summary>
        public MediasResponse Feed(string maxId) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(maxId, 0)); 
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// <para>
        /// <paramref name="count"/>: Count of media to return.
        /// </para>
        /// </summary>
        public MediasResponse Feed(int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(string.Empty, count));
        }

        /// <summary>
        /// See the authenticated user's feed.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// <para>
        /// <paramref name="maxId"/>: Return media earlier than this max_id.
        /// </para>
        /// <para>
        /// <paramref name="count"/>: Count of media to return.
        /// </para>
        /// </summary>
        public MediasResponse Feed(string maxId, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(maxId, count));
        }

        private string FeedJson(string maxId, int count) {
            string uri = string.Format(base.Uri + "self/feed?access_token={0}", AuthInfo.Access_Token);

            if (!string.IsNullOrEmpty(maxId)) uri += "&max_id=" + maxId;
            if (count > 0) uri += "&count=" + count;

            return HttpClient.GET(uri);
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Recent() {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson("", "", 0, null, null));
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Recent(string maxId) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, "", 0, null, null));
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Recent(string maxId, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, "", count, null, null));
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Recent (string maxId, string minId, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, minId, count, null, null));
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Recent(string maxId, string minId, int count, DateTime minTimestamp, DateTime maxTimestamp) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, minId, count, minTimestamp, maxTimestamp));
        }

        private string RecentJson(string maxId, string minId, int count, DateTime? minTimestamp, DateTime? maxTimestamp) {
            string uri = string.Format(base.Uri + "{0}/media/recent?access_token={1}", AuthInfo.User.Id, AuthInfo.Access_Token);

            if (maxId != "") uri += "&max_id=" + maxId;
            if (minId != "") uri += "&min_id=" + minId;
            if (count != 0) uri += "&count=" + count;
            if (minTimestamp != null) uri += "&min_timestamp=" + minTimestamp;
            if (maxTimestamp != null) uri += "&max_timestamp" + maxTimestamp;

            return HttpClient.GET(uri);
        }

        /// <summary>
        /// See the authenticated user's list of media they've liked. Note that this list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. Liked media lists are only available for the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Liked() {
            return (MediasResponse)Mapper.Map<MediasResponse>(LikedJson("", 0));
        }

        /// <summary>
        /// See the authenticated user's list of media they've liked. Note that this list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. Liked media lists are only available for the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Liked(string max_like_id) {
            return (MediasResponse)Mapper.Map<MediasResponse>(LikedJson(max_like_id, 0));
        }

        /// <summary>
        /// See the authenticated user's list of media they've liked. Note that this list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. Liked media lists are only available for the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: True</c>
        /// </para>
        /// </summary>
        public MediasResponse Liked(string max_like_id, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(LikedJson(max_like_id, count));
        }

        private string LikedJson(string max_like_id, int count) {
            string uri = string.Format(base.Uri + "self/media/liked?access_token={0}", AuthInfo.Access_Token);

            if (max_like_id != null) uri += "&max_like_id=" + max_like_id;
            if (count != 0) uri += "&count=" + count;

            return HttpClient.GET(uri);
        }

        /// <summary>
        /// Search for a user by name.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        public UsersResponse Search(string searchTerm) {
            return (UsersResponse)Mapper.Map<UsersResponse>(SearchJson(searchTerm, 0));
        }

        /// <summary>
        /// Search for a user by name.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        public UsersResponse Search(string searchTerm, int count) {
            return (UsersResponse)Mapper.Map<UsersResponse>(SearchJson(searchTerm, count));
        }

        private string SearchJson(string searchTerm, int count) {
            string uri = string.Format(base.Uri + "/search?q={0}&client_id={1}", searchTerm, InstagramConfig.ClientId);
            if (count != null) uri += "&count=" + count;
            return HttpClient.GET(uri);
        }
    }
}
