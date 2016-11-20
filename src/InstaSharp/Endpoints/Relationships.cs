using InstaSharp.Extensions;
using InstaSharp.Models;
using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Relationships Endpoint
    /// </summary>
    public class Relationships : InstagramApi
    {

        /// <summary>
        /// The Action
        /// </summary>
        public enum Action
        {
            Follow,
            Unfollow,           
            Block,
            Unblock,
            Approve,		
            Ignore,
        }

        /// <summary>
        /// Relationships Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        public Relationships(InstagramConfig config)
            : this(config, null)
        {
        }

        /// <summary>
        /// Relationships Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Relationships(InstagramConfig config, OAuthResponse auth)
            : base("users/", config, auth)
        {
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// <para>Requires Authentication: True</para><para><c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <returns>UsersResponse</returns>
        public Task<UsersResponse> Follows()
        {
            AssertIsAuthenticated();
            return Follows(null);
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// <para>Requires Authentication: True</para><para><c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <returns>UsersResponse</returns>
        public Task<UsersResponse> Follows(string cursor)
        {
            AssertIsAuthenticated();

            var request = Request("self/follows");
            request.AddParameter("cursor", cursor);

            return Client.ExecuteAsync<UsersResponse>(request);
        }

        /// <summary>
        /// Get the list of users this user follows.
        /// <para>Requires Authentication: True</para><para><c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <returns>UsersResponse</returns>
        public async Task<List<User>> FollowsAll()
        {
            AssertIsAuthenticated();
            return await new PageReader<User, UsersResponse>().ReadPages(Follows);
        }

        /// <summary>
        /// Get the list of users this user is followed by (one page worth).
        /// <para>Requires Authentication: True</para><para><c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <returns>UsersResponse</returns>
        public Task<UsersResponse> FollowedBy()
        {
            AssertIsAuthenticated();
            return FollowedBy(null);
        }

        /// <summary>
        /// Get the list of users this user is followed by.
        /// <para>Requires Authentication: False</para><para><c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <param name="userId">The id of the user to get the followers of.</param>
        /// <param name="cursor">The next cursor id</param>
        /// <returns>Users response</returns>
        public Task<UsersResponse> FollowedBy(string cursor)
        {
            var request = Request("self/followed-by");
            request.AddParameter("cursor", cursor);

            return Client.ExecuteAsync<UsersResponse>(request);
        }

        /// <summary>
        /// Get the list of users this user is followed by all (pages)
        /// <para>Requires Authentication: True</para><para><c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <returns>UsersResponse</returns>
        public async Task<List<User>> FollowedByAll()
        {
            AssertIsAuthenticated();
            return await new PageReader<User, UsersResponse>().ReadPages(FollowedBy);
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
        ///   <returns>Users response</returns>
        public Task<UsersResponse> RequestedBy()
        {
            var request = Request("self/requested-by");
            return Client.ExecuteAsync<UsersResponse>(request);
        }

        /// <summary>
        /// Get information about a relationship to another user.
        /// <para><c>Requires Authentication:</c> True
        /// </para>
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>RelationshipResponse</returns>
        public Task<RelationshipResponse> Relationship(long userId)
        {
            var request = Request("{id}/relationship");
            request.AddUrlSegment("id", userId.ToString());

            return Client.ExecuteAsync<RelationshipResponse>(request);
        }

        /// <summary>
        /// Modify the relationship between the current user and the target user.
        /// <para><c>Requires Authentication:</c> True
        /// </para><para><c>Required scope:</c> relationships
        /// </para>
        /// </summary>
        /// <param name="userId">The user id about which to get relationship information.</param>
        /// <param name="action">One of Action enum.</param>
        /// <returns>RelationshipResponse</returns>
        public Task<RelationshipResponse> Relationship(long userId, Action action)
        {
            var request = Request("{id}/relationship", HttpMethod.Post);
            request.AddUrlSegment("id", userId.ToString());
            request.Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("action", action.ToString().ToLower())
            });
            return Client.ExecuteAsync<RelationshipResponse>(request);
        }
    }
}
