using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints {
    public class Media : InstagramAPI {

        public Media(InstagramConfig config, AuthInfo auth = null)
            : base("/media/", config, auth) { }

        /// <summary>
        /// Get information about a media object. Note: if you are authenticated, you will receive the user_has_liked key which quickly tells you whether the current user has liked this media item.
        /// <para>
        /// <c>Requires Authentication:</c> False
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media to retrieve</param>
        /// <returns>MediaResponse</returns>
        public MediaResponse Get(string mediaId) {
            return (MediaResponse)Mapper.Map<MediaResponse>(GetJson(mediaId));
        }

        /// <summary>
        /// Get information about a media object. Note: if you are authenticated, you will receive the user_has_liked key which quickly tells you whether the current user has liked this media item.
        /// <para>
        /// <c>Requires Authentication:</c> False
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media to retrieve</param>
        /// <returns>String</returns>
        public string GetJson(string mediaId) {
            string uri = string.Format(base.Uri + "{0}?access_token={1}", mediaId, AuthInfo.Access_Token);
            return HttpClient.GET(uri);
        }

        /// <summary>
        /// Get a list of what media is most popular at the moment.
        /// <para>
        /// <c>Requires Authentication:</c> False
        /// </para>
        /// </summary>
        /// <returns>MediasResponse</returns>
        public MediasResponse Popular() {
            return (MediasResponse)Mapper.Map<MediasResponse>(PopularJson());
        }

        /// <summary>
        /// Get a list of what media is most popular at the moment.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication:</c> False
        /// </para>
        /// <returns>String</returns>
        public string PopularJson() {
            string uri = string.Format(base.Uri + "popular/?access_token={0}", AuthInfo.Access_Token);
            return HttpClient.GET(uri);
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
        /// <returns>MediasResponse</returns>
        public MediasResponse Search(double? latitude = null, double? longitude = null, DateTime? minTimestamp = null, DateTime? maxTimestamp = null, int distance = 1000) {
            return (MediasResponse)Mapper.Map<MediasResponse>(SearchJson(latitude, longitude, minTimestamp, maxTimestamp, distance));
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
        /// <returns>MediasResponse</returns>
        private string SearchJson(double? latitude = null, double? longitude = null, DateTime? minTimestamp = null, DateTime? maxTimestamp = null, int distance = 1000) {
            string uri = string.Format(base.Uri + "search?access_token={0}&distance={1}", AuthInfo.Access_Token, distance);

            if (latitude != null || longitude != null) uri += string.Format("&lat={0}&lng={1}", latitude, longitude);
            if (maxTimestamp != null) uri += "&max_timestamp=" + maxTimestamp;
            if (minTimestamp != null) uri += "&min_timestamp=" + minTimestamp;

            return HttpClient.GET(uri);
        }
    }
}
