using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;
using RestSharp;

namespace InstaSharp.Endpoints {

    public class Relationships : InstagramAPI {

        public enum Action {
            Follow,
            Unfollow,
            Block,
            Unblock,
            Approve,
            Deny
        }

        /// <summary>
        /// Relationships Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="oauthResponse">An instance of the OAuthResponse class.</param>
        public Relationships(InstagramConfig config, OAuthResponse oauthResponse)
            : base("/users/", config, oauthResponse) { }

        /// <summary>
        /// Get the list of users this user follows.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// <para>
        /// <c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <param name="userId">The list of users that this user id is following.</param>
        public IRestResponse<UsersResponse> Follows(int? userId = null) {
            var request = base.Request("{id}/follows");
            request.AddUrlSegment("id", userId.HasValue ? userId.ToString() : base.OAuthResponse.User.Id.ToString());
            return base.Client.Execute<UsersResponse>(request);
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// <para>
        /// <c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <param name="userId">The id of the user to get the followers of.</param>
        public IRestResponse<UsersResponse> FollowedBy(int? userId = null) {
            var request = base.Request(string.Format("{0}/followed-by", userId.HasValue ? userId.ToString() : OAuthResponse.User.Id.ToString()));
            return base.Client.Execute<UsersResponse>(request);
        }

        /// <summary>
        /// List the users who have requested this user's permission to follow.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// <para>
        /// <c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        public IRestResponse<UsersResponse> RequestedBy() {
            var request = base.Request("self/requested-by");
            return base.Client.Execute<UsersResponse>(request);
        }

        /// <summary>
        /// Get information about a relationship to another user.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// </summary>
        public IRestResponse<RelationshipResponse> Relationship(int userId) {
            var request = base.Request(string.Format("{0}/relationship", userId.ToString()));
            return base.Client.Execute<RelationshipResponse>(request);
        }

        /// <summary>
        /// Modify the relationship between the current user and the target user.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// <para>
        /// <c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <param name="userId">The user id about which to get relationship information.</param>
        /// <param name="action">One of Action enum.</param>
        public IRestResponse<RelationshipResponse> Relationship(int userId, Action action) {
            var request = base.Request(string.Format("{0}/relationship", userId.ToString()), Method.POST);
            request.AddParameter("action", action.ToString().ToLower());
            return base.Client.Execute<RelationshipResponse>(request);
        }
    }
}
