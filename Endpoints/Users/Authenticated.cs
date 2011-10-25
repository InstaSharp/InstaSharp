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
            return (Model.Responses.UserResponse)Json.Map<Model.Responses.UserResponse>(GetJson(AuthInfo.User.Id));
        }

        public UserResponse Get(int userId) {
            return (UserResponse)Json.Map<UserResponse>(GetJson(userId));
        }

        private string GetJson(int userId) {
            return _unauthenticated.GetJson(userId);
        }

        public MediaResponse Feed(string user) {
            return (MediaResponse)Json.Map<MediaResponse>(FeedJson(user, string.Empty, 0));
        }

        public MediaResponse Feed(string user, string maxId) {
            return (MediaResponse)Json.Map<MediaResponse>(FeedJson(user, maxId, 0)); 
        }

        public MediaResponse Feed(string user, int count) {
            return (MediaResponse)Json.Map<MediaResponse>(FeedJson(user, string.Empty, count));
        }

        public MediaResponse Feed(string user, string maxId, int count) {
            return (MediaResponse)Json.Map<MediaResponse>(FeedJson(user, maxId, count));
        }

        private string FeedJson(string user, string maxId, int count) {
            string uri = string.Format(base.Uri + "self/feed?access_token={0}", AuthInfo.Access_Token);

            if (!string.IsNullOrEmpty(maxId)) uri += "&max_id=" + maxId;
            if (count > 0) uri += "&count=" + count;

            return HttpClient.GET(uri);
        }

        public MediaResponse Recent(int? maxId, int? minId, int? count, int? minTimestamp, int? maxTimestamp) {
            return (MediaResponse)Json.Map<MediaResponse>(RecentJson(maxId, minId, count, minTimestamp, maxTimestamp));
        }

        public string RecentJson(int? maxId, int? minId, int? count, int? minTimestamp, int? maxTimestamp) {
            string uri = string.Format(base.Uri + "{0}/media/recent?access_token={1}", AuthInfo.User.Id, AuthInfo.Access_Token);

            if (maxId != null) uri += "&max_id=" + maxId;
            if (minId != null) uri += "&min_id=" + minId;
            if (count != null) uri += "&count=" + count;
            if (minTimestamp != null) uri += "&min_timestamp=" + minTimestamp;
            if (maxTimestamp != null) uri += "&max_timestamp" + maxTimestamp;

            return HttpClient.GET(uri);
        }

        public MediaResponse Liked(int? max_like_id, int? count) {
            string uri = base.Uri + "self/media/liked?access_token=" + AuthInfo.Access_Token;

            if (max_like_id > 0) uri += "&max_like_id=" + max_like_id;
            if (count > 0) uri += "&count=" + count;

            return (MediaResponse)Json.Map<MediaResponse>(LikedJson(max_like_id, count));
        }

        public string LikedJson(int? max_like_id, int? count) {
            string uri = string.Format(base.Uri + "self/media/liked?access_token={0}", AuthInfo.Access_Token);

            if (max_like_id != null) uri += "&max_like_id=" + max_like_id;
            if (count != null) uri += "&count=" + count;

            return HttpClient.GET(uri);
        }

        public UsersResponse Search(string searchTerm, int? count) {
            return (UsersResponse)Json.Map<UsersResponse>(SearchJson(searchTerm, count));
        }

        public string SearchJson(string searchTerm, int? count) {
            return _unauthenticated.SearchJson(searchTerm, count);
        }
    }
}
