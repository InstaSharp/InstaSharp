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
            return (MediaResponse)Mapper.Map<MediaResponse>(GetJson(mediaId));         
        }

        private string GetJson(string mediaId) {
            string uri = string.Format(base.Uri + "{0}?access_token={1}", mediaId, AuthInfo.Access_Token);
            return HttpClient.GET(uri);
        }

        public MediasResponse Popular() {
            return (MediasResponse)Mapper.Map<MediasResponse>(PopularJson());
        }

        private string PopularJson() {
            return _unauthenticated.PopularJson();
        }

        public MediaResponse Search(double latitude, double longitude) {
            return Search(latitude, longitude, null, null, 0);   
        }
        
        public MediaResponse Search(double latitude, double longitude, DateTime? minTimestamp, DateTime? maxTimestamp) {
            return Search(latitude, longitude, minTimestamp, maxTimestamp, 0); 
        }

        public MediaResponse Search(double latitude, double longitude, DateTime? minTimestamp, DateTime? maxTimestamp, int distance) {
            return _unauthenticated.Search(latitude, longitude, minTimestamp, maxTimestamp, distance);
        }
    }
}
