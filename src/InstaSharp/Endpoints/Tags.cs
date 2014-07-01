using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    public class Tags : InstaSharp.Endpoints.InstagramApi {
        
        /// <summary>
        /// Tag Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Tags(InstagramConfig config, OAuthResponse auth = null)
            : base("tags/", config, auth) { }

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        public Task<TagResponse> Get(string tagName) {
            var request = base.Request("{tag}");
            request.AddUrlSegment("tag", tagName);
            return base.Client.ExecuteAsync<TagResponse>(request);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="min_tag_id">Return media before this min_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="max_tag_id">Return media after this max_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="count">Count of tagged media to return. Will still be governed by Instagram's enforced limit.</param>
        public Task<MediasResponse> Recent(string tagName, string min_tag_id = "", string max_tag_id = "", int? count = null) {
            var request = base.Request("{tag}/media/recent");
            request.AddUrlSegment("tag", tagName);
            
            if (count.HasValue)
            {
                request.AddParameter("count", count.Value);
            }
            
            request.AddParameter("min_tag_id", min_tag_id);
            request.AddParameter("max_tag_id", max_tag_id);

            return base.Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="searchTerm">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public Task<TagsResponse> Search(string searchTerm) {
            var request = base.Request("search");
            request.AddParameter("q", searchTerm);
            return base.Client.ExecuteAsync<TagsResponse>(request);
        }
    }
}
