using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints
{
    public class Tags : InstaSharp.Endpoints.InstagramAPI {
        
        /// <summary>
        /// The Tags endpoint. None of its methods require authentication.
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class</param>
        public Tags(InstagramConfig config)
            : base(config, "/tags/") { }

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        /// <returns>TagResponse</returns>
        public TagResponse Get(string tagName) {
            return (TagResponse)Mapper.Map<TagResponse>(GetJson(tagName));
        }

        private string GetJson(string tagName) {
            string uri = string.Format(base.Uri + "{0}?client_id={1}", tagName, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        /// <returns>MediasResponse</returns>
        public MediasResponse Recent(string tagName) {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(tagName, null, null));
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="min_id">Return media before this min_id. If you don't want to use this parameter, use null.</param>
        /// <param name="max_id">Return media after this max_id. If you don't want to use this parameter, use null.</param>
        /// <returns>MediasResponse</returns>
        public MediasResponse Recent(string tagName, string min_id = "", string max_id = "") {
            return (MediasResponse)Mapper.Map<MediasResponse>(RecentJson(tagName, min_id, max_id));
        }

        private string RecentJson(string tagName, string min_id = "", string max_id = "") {
            string uri = string.Format(base.Uri + "{0}/media/recent?client_id={1}", tagName, InstagramConfig.ClientId);
            if (!string.IsNullOrEmpty(min_id)) uri += "&min_tag_id=" + min_id;
            if (!string.IsNullOrEmpty(max_id)) uri += "&max_tag_id=" + max_id;

            return HttpClient.GET(uri);
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="searchTerm">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        /// <returns>TagsResponse</returns>
        public TagsResponse Search(string searchTerm) {
            return (TagsResponse)Mapper.Map<TagsResponse>(SearchJson(searchTerm));
        }

        private string SearchJson(string searchTerm) {
            string uri = string.Format(base.Uri + "/search/?q={0}&client_id={1}", searchTerm, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }
    }
}
