using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;
using RestSharp;

namespace InstaSharp.Endpoints {
    public class Likes : InstagramAPI {

        /// <summary>
        /// Likes Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="auth">An instance of the AuthInfo class.</param>
        public Likes(InstagramConfig config, OAuthResponse auth)
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
        public IRestResponse<UsersResponse> Get(string mediaId) {
            var request = base.Request(string.Format("{0}/likes", mediaId));
            return base.Client.Execute<UsersResponse>(request);
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
        public IRestResponse<LikesResponse> Post(string mediaId) {
            var request = base.Request(string.Format("{0}/likes", mediaId), Method.POST);
            return base.Client.Execute<LikesResponse>(request);
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
        public IRestResponse<LikesResponse> Delete(string mediaId) {
            var request = base.Request(string.Format("{0}/likes", mediaId), Method.DELETE);
            return base.Client.Execute<LikesResponse>(request);
        }
    }
}
