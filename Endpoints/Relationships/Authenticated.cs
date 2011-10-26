using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Relationships {
    public class Authenticated : InstagramAPI {
    
        readonly Unauthenticated _unauthenticated;

         public enum Action {
            follow,
            unfollow,
            block,
            unblock,
            approve,
            deny
        }

        public Authenticated(InstagramConfig config, AuthInfo authInfo) : base(config, authInfo, "/users/") {
            _unauthenticated = new Unauthenticated(config);
        }

        public UsersResponse Follows() {
            return Follows(AuthInfo.User.Id);
        }

        public UsersResponse Follows(int userId) {
            return (UsersResponse)Mapper.Map<UsersResponse>(FollowsJson(userId));
        }

        public string FollowsJson() {
            return FollowsJson(AuthInfo.User.Id);
        }

        public string FollowsJson(int userId) {
            return _unauthenticated.FollowsJson(userId);
        }

        public UsersResponse FollowedBy() {
            return FollowedBy(AuthInfo.User.Id);
        }

        public UsersResponse FollowedBy(int userId) {
            return (UsersResponse)Mapper.Map<UsersResponse>(FollowedByJson(userId));
        }

        public string FollowedByJson() {
            return FollowedByJson(AuthInfo.User.Id);
        }

        public string FollowedByJson(int userId) {
            return _unauthenticated.FollowedByJson(userId);
        }

        public UsersResponse RequestedBy() {
            string uri = string.Format(base.Uri + "/self/requested-by?access_token={0}", AuthInfo.Access_Token);
            return (UsersResponse)Mapper.Map<UsersResponse>(RequestedByJson());
        }

        public string RequestedByJson() {
            string uri = string.Format(base.Uri + "/self/requested-by?access_token={0}", AuthInfo.Access_Token);
            return HttpClient.GET(uri);
        }

        public RelationshipResponse Relationship(int userId) {
            return (RelationshipResponse)Mapper.Map<RelationshipResponse>(RelationshipJson(userId));
        }

        public RelationshipResponse Relationship(int userId, Action action) {
            return (RelationshipResponse)Mapper.Map<RelationshipResponse>(RelationshipJson(userId, action));
        }

        public string RelationshipJson(int userId) {
            string uri = string.Format(base.Uri + "{0}/relationship?access_token={1}", userId, AuthInfo.Access_Token);
            return HttpClient.GET(uri);
        }

        public string RelationshipJson(int userId, Action action) {
            string uri = string.Format(base.Uri + "{0}/relationship?access_token={1}", userId, AuthInfo.Access_Token);
            var parameters = new Dictionary<string, string>();
            parameters.Add("action", action.ToString());
            return HttpClient.POST(uri, parameters);
        }
    
    }
}
