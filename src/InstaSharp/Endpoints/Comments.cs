using System.Collections.Generic;
using System.Net.Http;
using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints {
    public class Comments : InstagramAPI {

        /// <summary>
        /// Comments Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="authInfo">An instance of the AuthInfo class.</param>
        public Comments(InstagramConfig config, OAuthResponse authInfo) :
            base("media/", config, authInfo) { }

        /// <summary>
        /// Get a full list of comments on a media.
        /// <para>
        /// <c>Requires Authentication: </c>True
        /// </para>
        /// <param>
        /// <c>Required Scope: </c>comments
        /// </param>
        /// </summary>
        /// <param name="mediaId">The id of the media on which to retrieve comments.</param>
        /// <returns>CommentsResponse</returns>
        public Task<CommentsResponse> Get(string mediaId) {
            var request = Request(string.Format("{0}/comments", mediaId));
            return Client.ExecuteAsync<CommentsResponse>(request);
        }

        /// <summary>
        /// Create a comment on a media. Please email apidevelopers[at]instagram.com for access.
        /// <para>
        /// <c>Requires Authentication: </c>True
        /// </para>
        /// <param>
        /// <c>Required Scope: </c>comments
        /// </param>
        /// </summary>
        /// <param name="mediaId">The id of the media on which to post a comment.</param>
        /// <param name="comment">Text to post as a comment on the media as specified in media-id.</param>
        /// <returns>CommentsResponse</returns>
        public Task<CommentResponse> Post(string mediaId, string comment) {
            var request = Request(string.Format("{0}/comments", mediaId), HttpMethod.Post);
            request.Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("text", comment) });
            return Client.ExecuteAsync<CommentResponse>(request);
        }

        /// <summary>
        /// Remove a comment either on the authenticated user's media or authored by the authenticated user.
        /// <para>
        /// <c>Requires Authentication: </c>True
        /// </para>
        /// <param>
        /// <c>Required Scope: </c>comments
        /// </param>
        /// </summary>
        /// <param name="mediaId">The id of the media from which to delete the comment.</param>
        /// <param name="commentId">The id of the comment to delete.</param>
        /// <returns>CommentResponse</returns>
        public Task<CommentResponse> Delete(string mediaId, string commentId) {
            var request = Request(string.Format("{0}/comments/{1}", mediaId, commentId));
            return Client.ExecuteAsync<CommentResponse>(request);
        }
    }

}
