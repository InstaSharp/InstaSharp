using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;
using RestSharp;

namespace InstaSharp.Endpoints {
    public class Media : InstagramAPI {

        /// <summary>
        /// Media Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="auth">An instance of the AuthInfo class.</param>
        public Media(InstagramConfig config, OAuthResponse auth = null)
            : base("/media/", config, auth) { }

        /// <summary>
        /// Get information about a media object. Note: if you are authenticated, you will receive the user_has_liked key which quickly tells you whether the current user has liked this media item.
        /// <para>
        /// <c>Requires Authentication:</c> False
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media to retrieve</param>
        public IRestResponse<MediaResponse> Get(string mediaId) {
            var request = base.Request(mediaId);
            return base.Client.Execute<MediaResponse>(request);
        }

        /// <summary>
        /// Get a list of what media is most popular at the moment.
        /// <para>
        /// <c>Requires Authentication:</c> False
        /// </para>
        /// </summary>
        public IRestResponse<MediasResponse> Popular() {
            var request = base.Request("popular");
            return base.Client.Execute<MediasResponse>(request);
        }

        /// <summary>
        /// Search for media in a given area.
        /// <para>
        /// <c>Requires Authentication:</c> False
        /// </para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, longitude is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, latitude is required.</param>
        /// <param name="minTimestamp">All media returned will be taken later than this timestamp.</param>
        /// <param name="maxTimestamp">All media returned will be taken earlier than this timestamp.</param>
        /// <param name="distance">Default is 1km (distance=1000), max distance is 5km.</param>
        public IRestResponse<MediasResponse> Search(double? latitude = null, double? longitude = null, DateTime? minTimestamp = null, DateTime? maxTimestamp = null, int distance = 1000) {
            var request = base.Request("search");
            request.AddParameter("lat", latitude);
            request.AddParameter("lng", longitude);
            request.AddParameter("max_timestamp", ((DateTime)maxTimestamp).ToUnixTimestamp());
            request.AddParameter("min_timestamp", ((DateTime)minTimestamp).ToUnixTimestamp());
            request.AddParameter("distance", distance);
            return base.Client.Execute<MediasResponse>(request);
        }
    }
}
