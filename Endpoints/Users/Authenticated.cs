using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Users {
    public class Authenticated : InstagramAPI {

        readonly Unauthenticated _unauthenticated;

        public Authenticated(InstagramConfig config, AuthInfo authInfo)
            : base(config, authInfo, "/users/") {
                _unauthenticated = new Unauthenticated(config);
        }

        public UserResponse Get() {
            return (Model.Responses.UserResponse)Mapper.Map<Model.Responses.UserResponse>(GetJson(AuthInfo.User.Id));
        }

        public UserResponse Get(int userId) {
            return (UserResponse)Mapper.Map<UserResponse>(GetJson(userId));
        }

        private string GetJson(int userId) {
            return _unauthenticated.GetJson(userId);
        }

        public MediasResponse Feed(string user) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(user, string.Empty, 0));
        }

        public MediasResponse Feed(string user, string maxId) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(user, maxId, 0)); 
        }

        public MediasResponse Feed(string user, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(user, string.Empty, count));
        }

        public MediasResponse Feed(string user, string maxId, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(FeedJson(user, maxId, count));
        }

        private string FeedJson(string user, string maxId, int count) {
            string uri = string.Format(base.Uri + "self/feed?access_token={0}", AuthInfo.Access_Token);

            if (!string.IsNullOrEmpty(maxId)) uri += "&max_id=" + maxId;
            if (count > 0) uri += "&count=" + count;

            return HttpClient.GET(uri);
        }

        public MediasResponse Recent() {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson("", "", 0, null, null));
        } 

        public MediasResponse Recent(string maxId) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, "", 0, null, null));
        }

        public MediasResponse Recent(string maxId, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, "", count, null, null));
        }

        public MediasResponse Recent (string maxId, string minId, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(maxId, minId, count, null, null));
        }

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

        public MediasResponse Liked() {
            return (MediasResponse)Mapper.Map<MediasResponse>(LikedJson("", 0));
        }

        public MediasResponse Liked(string max_like_id) {
            return (MediasResponse)Mapper.Map<MediasResponse>(LikedJson(max_like_id, 0));
        }

        public MediasResponse Liked(string max_like_id, int count) {
            return (MediasResponse)Mapper.Map<MediasResponse>(LikedJson(max_like_id, count));
        }

        private string LikedJson(string max_like_id, int count) {
            string uri = string.Format(base.Uri + "self/media/liked?access_token={0}", AuthInfo.Access_Token);

            if (max_like_id != null) uri += "&max_like_id=" + max_like_id;
            if (count != 0) uri += "&count=" + count;

            return HttpClient.GET(uri);
        }

        public UsersResponse Search(string searchTerm) {
            return (UsersResponse)Mapper.Map<UsersResponse>(SearchJson(searchTerm, 0));
        }

        public UsersResponse Search(string searchTerm, int count) {
            return (UsersResponse)Mapper.Map<UsersResponse>(SearchJson(searchTerm, count));
        }

        private string SearchJson(string searchTerm, int count) {
            return _unauthenticated.SearchJson(searchTerm, count);
        }
    }
}
