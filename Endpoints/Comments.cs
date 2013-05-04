using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;
using RestSharp;

namespace InstaSharp.Endpoints {
    public class Comments : InstagramAPI {

        /// <summary>
        /// Comments Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="authInfo">An instance of the AuthInfo class.</param>
        public Comments(InstagramConfig config, OAuthResponse authInfo) :
            base("/media/", config, authInfo) { }

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
        public IRestResponse<CommentsResponse> Get(string mediaId) {
            var request = base.Request(string.Format("{0}/comments", mediaId));
            return base.Client.Execute<CommentsResponse>(request);
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
        /// <param name="comments">Text to post as a comment on the media as specified in media-id.</param>
        /// <returns>CommentsResponse</returns>
        public IRestResponse<CommentResponse> Post(string mediaId, string comment) {
            var request = base.Request(string.Format("{0}/comments", mediaId));
            request.AddParameter("text", comment);
            return base.Client.Execute<CommentResponse>(request);
        }

        /// <summary>
        /// Remove a comment either on the authenticated user's media or authored by the authenticated user.
        /// <c>Requires Authentication: </c>True
        /// </para>
        /// <param>
        /// <c>Required Scope: </c>comments
        /// </param>
        /// </summary>
        /// <param name="mediaId">The id of the media from which to delete the comment.</param>
        /// <param name="commentId">The id of the comment to delete.</param>
        /// <returns>CommentResponse</returns>
        public IRestResponse<CommentResponse> Delete(string mediaId, string commentId) {
            var request = base.Request(string.Format("{0}/comments/{1}", mediaId, commentId));
            return base.Client.Execute<CommentResponse>(request);
        }
    }

}
