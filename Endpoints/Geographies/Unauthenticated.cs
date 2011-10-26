using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Geographies {
    public class Unauthenticated : InstagramAPI {
        public Unauthenticated(InstagramConfig config) : base(config, "/geographies/") {}

        public MediaResponse Get(string mediaId, int? count, string min_id) {
            return (MediaResponse)Mapper.Map<MediaResponse>(GetJson(mediaId, count, min_id));
        }

        public string GetJson(string mediaId, int? count, string min_id) {
            string uri = string.Format(base.Uri + "{0}/media/recent?client_id={1}", mediaId, InstagramConfig.ClientId);
            
            if (count != null) base.Uri += "&count=" + count;
            if (!string.IsNullOrEmpty(min_id)) base.Uri += "&min_id" +  min_id;
            
            return HttpClient.GET(uri);
        }
    }
}
