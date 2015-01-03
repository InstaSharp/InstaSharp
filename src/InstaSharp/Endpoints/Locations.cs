using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Locations API
    /// </summary>
    public class Locations : InstagramApi
    {
        /// <summary>
        /// Locations Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstaGram config class</param>
        public Locations(InstagramConfig config)
            : this(config, null)
        {
        }

        /// <summary>
        /// Locations Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstaGram config class</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Locations(InstagramConfig config, OAuthResponse auth)
            : base("locations/", config, auth)
        {
        }

        /// <summary>
        /// The versions of the Foursquare API
        /// </summary>   
        [Obsolete]
        public enum FoursquareVersion
        {
            /// <summary>
            ///  one
            /// </summary>
            [Obsolete]
            One,
            /// <summary>
            ///  two
            /// </summary>
            Two
        }

        /// <summary>
        /// Get information about a location.
        /// <para><c>Requires Authentication: False</c></para>
        /// </summary>
        /// <param name="locationId">The id of the location to retreive information for.</param>
        /// <returns>location response</returns>
        public Task<LocationResponse> Get(string locationId)
        {
            var request = Request(locationId);
            return Client.ExecuteAsync<LocationResponse>(request);
        }

        /// <summary>
        ///  Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns>Media Response</returns>
        public Task<MediasResponse> Recent(string locationId)
        {
            return Recent(locationId, null, null, null, null);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="locationId">The id of the location about which to retrieve information.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp</param>
        /// <param name="minId">Return media before this min_id</param>
        /// <param name="maxId">Return media after this max_id</param>
        /// <returns>media response</returns>
        public Task<MediasResponse> Recent(string locationId, DateTime? minTimestamp, DateTime? maxTimestamp, string minId, string maxId)
        {
            var request = Request("{id}/media/recent");
            request.AddUrlSegment("id", locationId);

            request.AddParameter("min_timestamp", minTimestamp);
            request.AddParameter("max_timestamp", maxTimestamp);
            request.AddParameter("min_id", minId);
            request.AddParameter("max_id", maxId);

            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <returns>Locations Response</returns>
        public Task<LocationsResponse> Search(double latitude, double longitude)
        {
            return Search(latitude, longitude, null);
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <param name="distance">Default is 1000m (distance=1000), max distance is 5000.</param>
        /// <returns>Locations Response</returns>
        public Task<LocationsResponse> Search(double latitude, double longitude, double? distance)
        {
            if (distance != null && distance > 5000)
            {
                throw new ArgumentException("distance must be less than 5000", "distance");
            }

            var request = Request("search");

            request.AddParameter("lat", latitude);
            request.AddParameter("lng", longitude);
            if (distance != null)
            {
                request.AddParameter("distance", distance);
            }
            return base.Client.ExecuteAsync<LocationsResponse>(request);
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="facebookPlacesId">Facebook places id</param>
        /// <returns>Locations Response</returns>
        public Task<LocationsResponse> Search(long facebookPlacesId)
        {
            var request = Request("search");
            request.AddParameter("facebook_places_id", facebookPlacesId);

            return base.Client.ExecuteAsync<LocationsResponse>(request);
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// <para>Requires Authentication: False</para>
        /// </summary>
        /// <param name="foursquareId">Returns a location mapped off of a foursquare v2 api location id. If used, you are not required to use lat and lng.</param>
        /// <param name="foursquareVersion">The version of the FourSquare ID  you are using.  Either version 1 or 2.</param>
        /// <returns>location response</returns>
        /// <exception cref="System.ArgumentException">foursquareId empty;foursquareId</exception>
        public Task<LocationsResponse> Search(string foursquareId, FoursquareVersion foursquareVersion)
        {
            if (string.IsNullOrWhiteSpace(foursquareId))
            {
                throw new ArgumentException("foursquareId empty", "foursquareId");
            }

            var request = Request("search");

            switch (foursquareVersion)
            {
                case FoursquareVersion.One:
                    request.AddParameter("foursquare_id", foursquareId);
                    break;
                case FoursquareVersion.Two:
                    request.AddParameter("foursquare_v2_id", foursquareId);
                    break;
            }

            return Client.ExecuteAsync<LocationsResponse>(request);
        }
    }
}
