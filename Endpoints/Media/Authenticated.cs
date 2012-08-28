using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Media
{
    public class Authenticated : InstagramAPI
    {

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
            string uri = string.Format(base.Uri + "popular/?access_token={0}", AuthInfo.Access_Token);
            return HttpClient.GET(uri);
        }

        public MediasResponse Search(double latitude, double longitude) {
            return Search(latitude, longitude, null, null, 0);
        }

        public MediasResponse Search(double latitude, double longitude, DateTime? minTimestamp, DateTime? maxTimestamp) {
            return Search(latitude, longitude, minTimestamp, maxTimestamp, 0);
        }

        public MediasResponse Search(double latitude, double longitude, DateTime? minTimestamp, DateTime? maxTimestamp, int distance) {
            return (MediasResponse)Mapper.Map<MediasResponse>(SearchJson(latitude, longitude, minTimestamp, maxTimestamp, distance));
        }

        private string SearchJson(double latitude, double longitude, DateTime? minTimestamp, DateTime? maxTimestamp, int distance) {
            string uri = string.Format(base.Uri + "search?access_token={0}&lat={1}&lng={2}", AuthInfo.Access_Token, latitude, longitude);

            if (maxTimestamp != null) uri += string.Format("&max_timestamp={0}&min_timestamp={1}", maxTimestamp, minTimestamp);
            if (distance != 0) uri += "&distance=" + distance;

            return HttpClient.GET(uri);
        }
    }
}
