using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Locations {
    public class Authenticated : InstagramAPI {

        readonly Unauthenticated _unauthenticated;
        
        public Authenticated(InstagramConfig config, AuthInfo auth)
            : base(config, auth, "/search/") {
                _unauthenticated = new Unauthenticated(config);
        }

        public LocationResponse Get(string locationId) {
            return _unauthenticated.Get(locationId);
        }

        public MediasResponse Recent(string locationId) {
            return _unauthenticated.Recent(locationId);
        }

        public LocationsResponse Search(double latitiude, double longitude) {
            return _unauthenticated.Search(latitiude, longitude);
        }

        public LocationsResponse Search(string foursquare_id, Unauthenticated.FoursquareVersion foursquare_version) {
            return _unauthenticated.Search(foursquare_id, foursquare_version, 0);
        }

        public LocationsResponse Search(string foursquare_id, Unauthenticated.FoursquareVersion foursquare_version, int distance) {
            return _unauthenticated.Search(foursquare_id, foursquare_version, distance);
        }
    }
}
