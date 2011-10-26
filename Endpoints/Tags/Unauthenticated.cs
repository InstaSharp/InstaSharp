using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Tags {
    public class Unauthenticated : InstagramAPI {

        public Unauthenticated(InstagramConfig config) : base(config, "/tags/") { }

        public TagResponse Get(string tagName) {
            return (TagResponse)Mapper.Map<TagResponse>(GetJson(tagName));
        }

        public string GetJson(string tagName) {
            string uri = string.Format(base.Uri + "{0}?client_id={1}", tagName, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public MediasResponse Recent(string tagName) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(tagName));
        }

        private string RecentJson(string tagName) {
            string uri = string.Format(base.Uri + "{0}/media/recent?client_id={1}", tagName, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public TagsResponse Search(string searchTerm) {
            return (TagsResponse)Mapper.Map<TagsResponse>(SearchJson(searchTerm));
        }

        private string SearchJson(string searchTerm) {
            string uri = string.Format(base.Uri + "/search/?q={0}&client_id={1}", searchTerm, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }
    }
}
