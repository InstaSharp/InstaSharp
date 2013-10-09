using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints {
    public class Likes : InstagramAPI {

        /// <summary>
        /// Likes Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="auth">An instance of the AuthInfo class.</param>
        public Likes(InstagramConfig config, OAuthResponse auth)
            : base("media/", config, auth) { }

        /// <summary>
        /// Get a list of users who have liked this media.
        /// <para>
        /// <c>Requires Authentication: </c>True
        /// </para>
        /// <para>
        /// <c>Required Scope: </c> likes
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media about which to retrieve information.</param>
        public Task<UsersResponse> Get(string mediaId) {
            var request = base.Request(string.Format("{0}/likes", mediaId));
            return base.Client.ExecuteAsync<UsersResponse>(request);
        }

        /// <summary>
        /// Set a like on this media by the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: </c>True
        /// </para>
        /// <para>
        /// <c>Required Scope: </c>likes
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media to create a like for.</param>
        /// <returns>LikesResponse</returns>
        public Task<LikesResponse> Post(string mediaId) {
            var request = base.Request(string.Format("{0}/likes", mediaId), HttpMethod.Post);
            return base.Client.ExecuteAsync<LikesResponse>(request);
        }

        /// <summary>
        /// Remove a like on this media by the currently authenticated user.
        /// <para>
        /// <c>Requires Authentication: </c>True
        /// </para>
        /// <para>
        /// <c>Required Scope: </c>likes
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media from wich to remove the like.</param>
        public Task<LikesResponse> Delete(string mediaId) {
            var request = base.Request(string.Format("{0}/likes", mediaId), HttpMethod.Delete);
            return base.Client.ExecuteAsync<LikesResponse>(request);
        }
    }
}
