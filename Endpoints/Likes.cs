using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints {
    public class Likes : InstagramAPI {

        public Likes(InstagramConfig config, AuthInfo auth)
            : base("/media/", config, auth) { }

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
        /// <returns>Users Response</returns>
        public UsersResponse Get(string mediaId) {
            return (UsersResponse)Mapper.Map<UsersResponse>(GetJson(mediaId));
        }

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
        /// <returns>String</returns>
        public string GetJson(string mediaId) {
            base.FormatUri(string.Format("{0}/likes", mediaId));
            return HttpClient.GET(base.Uri.ToString());
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
        public LikesResponse Post(string mediaId) {
            return (LikesResponse)Mapper.Map<LikesResponse>(PostJson(mediaId));
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
        /// <returns>String</returns>
        public string PostJson(string mediaId) {
            base.FormatUri(string.Format("{0}/likes", mediaId));
            return HttpClient.POST(base.Uri.ToString());
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
        /// <returns>LikesResponse</returns>
        public LikesResponse Delete(string mediaId) {
            return (LikesResponse)Mapper.Map<LikesResponse>(DeleteJson(mediaId));
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
        /// <returns>String</returns>
        public string DeleteJson(string mediaId) {
            base.FormatUri(string.Format("{0}/likes", mediaId));
            return HttpClient.DELETE(base.Uri.ToString());
        }
    }
}
