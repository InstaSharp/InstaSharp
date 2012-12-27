using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;

namespace InstaSharp.Endpoints {
    public class Locations : InstagramAPI {
        
        /// <summary>
        /// Locations Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstaGram config class</param>
        /// <param name="auth">Optional: An instance of the AuthInfo class</param>
        public Locations(InstagramConfig config, AuthInfo auth = null) : base("/locations/", config, auth) { }

        /// <summary>
        /// The versions of the Foursquare API
        /// </summary>
        public enum FoursquareVersion {
            One,
            Two
        }

        /// <summary>
        /// Get information about a location.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="locationId">The id of the location to retreive information for.</param>
        /// <returns>LocationsResponse</returns>
        public LocationResponse Get(string locationId) {
            return (LocationResponse)Mapper.Map<LocationResponse>(GetJson(locationId));
        }

        /// <summary>
        /// Get information about a location.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="locationId">The id of the location to retreive information for.</param>
        /// <returns>String</returns>
        public string GetJson(string locationId) {
            base.FormatUri(locationId);
            return HttpClient.GET(base.Uri.ToString());
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="locationId">The id of the location about which to retrieve information.</param>
        /// <returns>MediasResponse</returns>
        public MediasResponse Recent(string locationId, DateTime? minTimestamp = null, DateTime? maxTimestamp = null, string minId = "", string maxId = "") {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(locationId));
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="locationId">The id of the location about which to retrieve information.</param>
        /// <returns>String</returns>
        public string RecentJson(string locationId, DateTime? minTimestamp = null, DateTime? maxTimestamp = null, string minId = "", string maxId = "") {
            base.FormatUri(string.Format("{0}/media/recent/", locationId));

            if (minTimestamp != null) base.Uri.AppendFormat("&min_timestamp={0}", ((DateTime)minTimestamp).ToUnixTimestamp());
            if (maxTimestamp != null) base.Uri.AppendFormat("&max_timestamp={0}", ((DateTime)maxTimestamp).ToUnixTimestamp());
            if (!string.IsNullOrEmpty(minId)) base.Uri.AppendFormat("&min_id={0}", minId);
            if (!string.IsNullOrEmpty(maxId)) base.Uri.AppendFormat("&max_id={0}", maxId);

            return HttpClient.GET(base.Uri.ToString());
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <param name="distance">Default is 1000m (distance=1000), max distance is 5000.</param>
        /// <param name="foursquare_id">Returns a location mapped off of a foursquare v2 api location id. If used, you are not required to use lat and lng.</param>
        /// <param name="foursquare_version">The version of the FourSquare ID  you are using.  Either version 1 or 2.</param>
        /// <returns>LocationsResponse</returns>
        public LocationsResponse Search(double? latitude = null, double? longitude = null, double distance = 1000, string foursquare_id = "", FoursquareVersion? foursquare_version = null) {
            return (LocationsResponse)Mapper.Map<LocationsResponse>(SearchJson(latitude, longitude, distance, foursquare_id, foursquare_version));
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// </summary>
        /// <param name="latitude">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="longitude">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <param name="distance">Default is 1000m (distance=1000), max distance is 5000.</param>
        /// <param name="foursquare_id">Returns a location mapped off of a foursquare v2 api location id. If used, you are not required to use lat and lng.</param>
        /// <param name="foursquare_version">The version of the FourSquare ID  you are using.  Either version 1 or 2.</param>
        /// <returns>String</returns>
        private string SearchJson(double? latitude = null, double? longitude = null, double distance = 1000, string foursquare_id = "", FoursquareVersion? foursquare_version = null) {
            base.FormatUri("search");

            if (foursquare_version != null) {
                switch (foursquare_version) {
                    case FoursquareVersion.One:
                        base.Uri.AppendFormat("&foursquare_id={0}", foursquare_id);
                        break;
                    case FoursquareVersion.Two:
                        base.Uri.AppendFormat("&foursquare_id={0}" + foursquare_id);
                        break;
                    default:
                        break;
                }
            } else {
                base.Uri.AppendFormat("&lat={0}&lng={1}&distance={2}", latitude, longitude);
            }

            base.Uri.AppendFormat("&distance={0}", distance);

            return HttpClient.GET(base.Uri.ToString());
        }
            
    }
}
