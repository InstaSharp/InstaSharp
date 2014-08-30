using InstaSharp.Extensions;
using InstaSharp.Models;
using InstaSharp.Models.Responses;
using System;
using System.Threading.Tasks;


namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Media API
    /// </summary>
    public class Media : InstagramApi
    {
        /// <summary>
        /// Media Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        public Media(InstagramConfig config)
            : this(config, null)
        {
        }

        /// <summary>
        /// Media Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Media(InstagramConfig config, OAuthResponse auth)
            : base("media/", config, auth)
        {
        }

        /// <summary>
        /// Get information about a media object. Note: if you are authenticated, you will receive the user_has_liked key which quickly tells you whether the current user has liked this media item.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="mediaId">The id of the media to retrieve</param>
        /// <returns>
        /// Media Response
        /// </returns>
        public Task<MediaResponse> Get(string mediaId)
        {
            var request = Request(mediaId);
            return Client.ExecuteAsync<MediaResponse>(request);
        }

        /// <summary>
        /// Get a list of what media is most popular at the moment.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <returns>
        /// Media Response
        /// </returns>
        public Task<MediasResponse> Popular()
        {
            var request = Request("popular");
            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Search for media in a given area.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, longitude is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, latitude is required.</param> /// <returns>
        /// Media Response
        /// </returns>
        public Task<MediasResponse> Search(double latitude, double longitude)
        {
            return Search(latitude, longitude, null, null, null);
        }

        /// <summary>
        /// Search for media in a given area.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, longitude is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, latitude is required.</param>
        /// <param name="distance">Default is 1km (distance=1000), max distance is 5km.</param> /// <returns>
        /// Media Response
        /// </returns>
        public Task<MediasResponse> Search(double latitude, double longitude, int? distance)
        {
            return Search(latitude, longitude, distance, null, null);
        }

        /// <summary>
        /// Search for media in a given area.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, longitude is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, latitude is required.</param>
        /// <param name="distance">Default is 1km (distance=1000), max distance is 5km.</param>
        /// <param name="minTimestamp">All media returned will be taken later than this timestamp.</param>
        /// <param name="maxTimestamp">All media returned will be taken earlier than this timestamp.</param> 
        /// <returns>
        /// Media Response
        /// </returns>
        public Task<MediasResponse> Search(double latitude, double longitude, int? distance, DateTime? minTimestamp, DateTime? maxTimestamp)
        {
            var request = Request("search");
            request.AddParameter("lat", latitude);
            request.AddParameter("lng", longitude);
            if (maxTimestamp.HasValue)
            {
                request.AddParameter("max_timestamp", (maxTimestamp.Value).ToUnixTimestamp());
            }
            if (minTimestamp.HasValue)
            {
                request.AddParameter("min_timestamp", (minTimestamp.Value).ToUnixTimestamp());
            }
            request.AddParameter("distance", distance);
            return Client.ExecuteAsync<MediasResponse>(request);
        }

    }
}
