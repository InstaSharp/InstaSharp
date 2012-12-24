using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints {

    public class Relationships : InstagramAPI {

        public enum Action {
            none,
            follow,
            unfollow,
            block,
            unblock,
            approve,
            deny
        }

        /// <summary>
        /// The Relationships endpoint.  All calls on this endpoint require authentication.
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="authInfo">An instance of the AuthInfo class.</param>
        public Relationships(InstagramConfig config, AuthInfo authInfo)
            : base(config, authInfo, "/users/") { }

        /// <summary>
        /// Get the list of users this user follows.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// <para>
        /// <c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <returns>UsersResponse</returns>
        public UsersResponse Follows() {
            return Follows(AuthInfo.User.Id);
        }

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
        public UsersResponse Follows(int userId) {
            return (UsersResponse)Mapper.Map<UsersResponse>(FollowsJson(userId));
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// <para>
        /// <c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <returns>String</returns>
        public string FollowsJson() {
            return FollowsJson(AuthInfo.User.Id);
        }

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
        /// <returns>String</returns>
        public string FollowsJson(int userId) {
            string uri = string.Format(base.Uri + "{0}/follows?client_id={1}", userId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// <para>
        /// <c>Required scope:</c> relationships
        /// </para>
        /// <returns>UsersResponse</returns>
        public UsersResponse FollowedBy() {
            return FollowedBy(AuthInfo.User.Id);
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
        public UsersResponse FollowedBy(int userId) {
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
        /// <returns>String</returns>
        public string FollowedByJson() {
            return FollowedByJson(base.AuthInfo.User.Id);
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
        public string FollowedByJson(int userId) {
            string uri = string.Format(base.Uri + "{0}/followed-by?client_id={1}", userId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
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
            string uri = string.Format(base.Uri + "/self/requested-by?access_token={0}", AuthInfo.Access_Token);
            return HttpClient.GET(uri);
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
        public RelationshipResponse Relationship(int userId, Action? action = null) {
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
        public string RelationshipJson(int userId, Action? action) {
            string uri = string.Format(base.Uri + "{0}/relationship?access_token={1}", userId, AuthInfo.Access_Token);
            var parameters = new Dictionary<string, string>();
            if (action != null) {
                parameters.Add("action", action.ToString());
            }
            return HttpClient.POST(uri, parameters);
        }

    }
}
