using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Media {
    public class Unauthenticated : InstagramAPI {

        public Unauthenticated(InstagramConfig config) : base(config, "/media/") {
            
        }

        public MediaResponse Get(string mediaId) {
            return (MediaResponse)Json.Map<MediaResponse>(GetJson(mediaId));         
        }

        public string GetJson(string mediaId) {
            string uri = string.Format(base.Uri + "{0}?client_id={1}", mediaId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public MediaResponse Popular() {
            return (MediaResponse)Json.Map<MediaResponse>(PopularJson());
        }

        public string PopularJson() {
            string uri = string.Format(base.Uri + "popular/?client_id={0}", InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public MediaResponse Search(decimal latitude, decimal longitude, int? maxTimestamp, int? minTimestamp, int? distance) {
            return (MediaResponse)Json.Map<MediaResponse>(SearchJson(longitude, longitude, maxTimestamp, minTimestamp, distance));
        }

        public string SearchJson(decimal latitude, decimal longitude, int? maxTimestamp, int? minTimestamp, int? distance) {
            string uri = string.Format("search?client_id={0}lat={1}&long={2}", InstagramConfig.ClientId, latitude, longitude);

            if (maxTimestamp != 0) uri += "&max_timestamp=" + maxTimestamp;
            if (minTimestamp != 0) uri += "&min_timestamp=" + minTimestamp;
            if (distance != 0) uri += "&distance=" + distance;

            return HttpClient.GET(uri);
        }
    }
}
