using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Likes Api
    /// </summary>
    public class Likes : InstagramApi
    {
        /// <summary>
        /// Likes Endpoint
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        public Likes(InstagramConfig config)
            : this(config, null)
        {
        }

        /// <summary>
        /// Likes Endpoint
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Likes(InstagramConfig config, OAuthResponse auth)
            : base("media/", config, auth)
        {
        }

        /// <summary>
        /// Get a list of users who have liked this media.
        /// <para>Requires Authentication: False</para><para><c>Required Scope: </c> likes
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media about which to retrieve information.</param>
        /// <returns>Users Response</returns>
        public Task<UsersResponse> Get(string mediaId)
        {
            var request = Request("{id}/likes");
            request.AddUrlSegment("id", mediaId);
            return Client.ExecuteAsync<UsersResponse>(request);
        }

        /// <summary>
        /// Set a like on this media by the currently authenticated user.
        /// <para>Requires Authentication: False</para>
        /// <para>
        /// <c>Required Scope: </c>likes
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media to create a like for.</param>
        /// <returns>LikesResponse</returns>
        public Task<LikesResponse> Post(string mediaId)
        {
            AssertIsAuthenticated();

            var request = Request("{id}/likes", HttpMethod.Post);
            request.AddUrlSegment("id", mediaId);
            return Client.ExecuteAsync<LikesResponse>(request);
        }

        /// <summary>
        /// Remove a like on this media by the currently authenticated user.
        /// <para>Requires Authentication: False</para><para><c>Required Scope: </c>likes
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media from wich to remove the like.</param>
        /// <returns>LikesResponse</returns>
        public Task<LikesResponse> Delete(string mediaId)
        {
            AssertIsAuthenticated();

            var request = Request("{id}/likes", HttpMethod.Delete);
            request.AddUrlSegment("id", mediaId);
            return Client.ExecuteAsync<LikesResponse>(request);
        }
    }
}
