using System.Collections.Generic;
using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints {

    public class Relationships : InstagramApi {

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
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Relationships(InstagramConfig config, OAuthResponse auth)
            : base("users/", config, auth) { }

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
        /// <param name="cursor">The next cursor id</param>
        public Task<UsersResponse> Follows(int? userId = null, string cursor = null)
        {
            var request = base.Request("{id}/follows");
            request.AddUrlSegment("id", userId.HasValue ? userId.ToString() : base.OAuthResponse.User.Id.ToString());
            if (cursor != null)
            {
                request.AddParameter("cursor", cursor);
            }
            return base.Client.ExecuteAsync<UsersResponse>(request);
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
        /// <param name="cursor">The next cursor id</param>
        public Task<UsersResponse> FollowedBy(int? userId = null, string cursor = null) {
            var request = base.Request(string.Format("{0}/followed-by", userId.HasValue ? userId.ToString() : OAuthResponse.User.Id.ToString()));
            if (cursor != null)
            {
                request.AddParameter("cursor", cursor);
            }
            return base.Client.ExecuteAsync<UsersResponse>(request);
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
        public Task<UsersResponse> RequestedBy() {
            var request = base.Request("self/requested-by");
            return base.Client.ExecuteAsync<UsersResponse>(request);
        }

        /// <summary>
        /// Get information about a relationship to another user.
        /// <para>
        /// <c>Requires Authentication:</c> True
        /// </para>
        /// </summary>
        public Task<RelationshipResponse> Relationship(int userId) {
            var request = base.Request(string.Format("{0}/relationship", userId.ToString()));
            return base.Client.ExecuteAsync<RelationshipResponse>(request);
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
        public Task<RelationshipResponse> Relationship(int userId, Action action) {
            var request = base.Request(string.Format("{0}/relationship", userId.ToString()), HttpMethod.Post);
            request.Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("action", action.ToString().ToLower()) });
            return base.Client.ExecuteAsync<RelationshipResponse>(request);
        }
    }
}
