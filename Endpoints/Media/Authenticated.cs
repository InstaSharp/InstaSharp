using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Media {
    public class Authenticated : InstagramAPI{
        
        readonly Unauthenticated _unauthenticated;

        public Authenticated(InstagramConfig config, AuthInfo auth) : base(config, auth, "/media/") {
            _unauthenticated = new Unauthenticated(config);
        }

        public MediaResponse Get(string mediaId) {
            return (MediaResponse)Json.Map<MediaResponse>(GetJson(mediaId));         
        }

        public string GetJson(string mediaId) {
            return _unauthenticated.GetJson(mediaId);
        }

        public MediaResponse Popular() {
            return (MediaResponse)Json.Map<MediaResponse>(PopularJson());
        }

        public string PopularJson() {
            return _unauthenticated.PopularJson();
        }

        // public MediaResponse Search(decimal latitude, decimal longitude, int? maxTimestamp, int? minTimestamp, int? distance) {
        //    return (MediaResponse)Json.Map<MediaResponse>(SearchJson(longitude, longitude, maxTimestamp, minTimestamp, distance));
        //}

        //public string SearchJson(decimal latitude, decimal longitude, int? maxTimestamp, int? minTimestamp, int? distance) {
        //    return _unauthenticated.SearchJson(latitude, longitude, maxTimestamp, minTimestamp, distance);
        //}
    }
}
