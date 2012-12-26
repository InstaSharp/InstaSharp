using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints {
    public class Comments : InstagramAPI {

        public Comments(InstagramConfig config, AuthInfo authInfo) :
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
        public CommentsResponse Get(string mediaId) {
            return (CommentsResponse)Mapper.Map<CommentsResponse>(GetJson(mediaId));
        }

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
        /// <returns>String</returns>
        public string GetJson(string mediaId) {
            base.FormatUri(string.Format("{0}/comments", mediaId));
            return HttpClient.GET(base.Uri.ToString());
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
        public CommentResponse Post(string mediaId, string comment) {
            return (CommentResponse)Mapper.Map<CommentResponse>(PostJson(mediaId, comment));
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
        /// <returns>String</returns>
        private string PostJson(string mediaId, string comment) {
            var args = new Dictionary<string, string>();
            args.Add("text", comment);

            string uri = string.Format(base.Uri + "{0}/comments?access_token={1}", mediaId, AuthInfo.Access_Token);

            return HttpClient.POST(uri, args);
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
        public CommentResponse Delete(string mediaId, string commentId) {
            return (CommentResponse)Mapper.Map<CommentResponse>(DeleteJson(mediaId, commentId));
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
        private string DeleteJson(string mediaId, string commentId) {
            string uri = string.Format(base.Uri + "{0}/comments/{1}?access_token={2}", mediaId, commentId, AuthInfo.Access_Token);
            return HttpClient.DELETE(uri);
        }
    }

}
