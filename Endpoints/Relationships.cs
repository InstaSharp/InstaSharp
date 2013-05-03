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
        /// <returns>UsersResponse</returns>
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
        /// <returns>UsersResponse</returns>
        public UsersResponse FollowedBy(int? userId = null) {
            return (UsersResponse)Mapper.Map<UsersResponse>(FollowedByJson(userId));
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
        /// <returns>String</returns>
        public string FollowedByJson(int? userId = null) {
            var uri = base.FormatUri(string.Format("{0}/followed-by", userId ?? OAuthResponse.User.Id));
            return HttpClient.GET(uri.ToString());
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
        /// <returns>UsersResponse</returns>
        public UsersResponse RequestedBy() {
            return (UsersResponse)Mapper.Map<UsersResponse>(RequestedByJson());
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
        /// <returns>String</returns>
        public string RequestedByJson() {
            var uri = base.FormatUri("/self/requested-by");
            return HttpClient.GET(uri.ToString());
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
        /// <returns>RelationshipResponse</returns>
        public RelationshipResponse Relationship(int userId, Action action) {
            return (RelationshipResponse)Mapper.Map<RelationshipResponse>(RelationshipJson(userId, action));
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
        /// <returns>String</returns>
        public string RelationshipJson(int userId, Action action) {
            var uri = base.FormatUri(string.Format("{0}/relationship", userId));
            var parameters = new Dictionary<string, string>() { { "action", action.ToString().ToLower() } };
            return HttpClient.POST(uri.ToString(), parameters);
        }

    }
}
