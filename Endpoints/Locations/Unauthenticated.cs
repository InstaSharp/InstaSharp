using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Locations {
    public class Unauthenticated : InstagramAPI {
        public Unauthenticated(InstagramConfig config) : base(config, "/locations/") { }

        public enum FoursquareVersion {
            None,
            One,
            Two
        }

        public LocationResponse Get(string locationId) {
            return (LocationResponse)Mapper.Map<LocationResponse>(GetJson(locationId));
        }

        public string GetJson(string locationId) {
            string uri = string.Format(base.Uri + "{0}?client_id={1}", locationId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public MediasResponse Recent(string locationId) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(locationId));
        }

        public string RecentJson(string locationId) {
            string uri = string.Format(base.Uri + "{0}/media/recent/?client_id={1}", locationId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public LocationsResponse Search(double latitude, double longitude) {
            return (LocationsResponse)Mapper.Map<LocationsResponse>(SearchJson(latitude, longitude, null, FoursquareVersion.None, 0));
        }

        public LocationsResponse Search(string foursquare_id, FoursquareVersion foursquare_version) {
            return Search(foursquare_id, foursquare_version, 0);
        }

        public LocationsResponse Search(string foursquare_id, FoursquareVersion foursquare_version, int distance) {
            return (LocationsResponse)Mapper.Map<LocationsResponse>(SearchJson(0, 0, foursquare_id, foursquare_version, distance));
        }

        private string SearchJson(double latitude, double longitude, string foursquare_id, FoursquareVersion foursquare_version, int distance) {
            string uri = string.Format(base.Uri + "search?client_id={0}", InstagramConfig.ClientId);

            if (foursquare_version != FoursquareVersion.None) {
                switch (foursquare_version) {
                    case FoursquareVersion.One:
                        uri += "&foursquare_id=" + foursquare_id;
                        break;
                    case FoursquareVersion.Two:
                        uri += "&foursquare_id=" + foursquare_id;
                        break;
                    default:
                        break;
                }
            }
            else {
                uri = string.Format(uri + "&lat={0}&lng={1}", latitude, longitude);
            }

            if (distance != 0) uri += "&distance=" + distance;

            return HttpClient.GET(uri);
        }
    }
}
