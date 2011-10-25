using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Tags {
    public class Unauthenticated : InstagramAPI {

        public Unauthenticated(InstagramConfig config) : base(config, "/tags/") { }

        public TagResponse Get(string tagName) {
            return (TagResponse)Json.Map<TagResponse>(GetJson(tagName));
        }

        public string GetJson(string tagName) {
            string uri = string.Format(base.Uri + "{0}?client_id={1}", tagName, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public MediaResponse Recent(string tagName) {
            return (MediaResponse)Json.Map<MediaResponse>(RecentJson(tagName));
        }

        public string RecentJson(string tagName) {
            string uri = string.Format(base.Uri + "{0}/media/recent?client_id={1}", tagName, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public TagsResponse Search(string searchTerm) {
            return (TagsResponse)Json.Map<TagsResponse>(SearchJson(searchTerm));
        }

        public string SearchJson(string searchTerm) {
            string uri = string.Format(base.Uri + "/search/?q={0}&client_id={1}", searchTerm, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }
    }
}
