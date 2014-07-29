using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    public class Tags : InstaSharp.Endpoints.InstagramApi
    {
        /// <summary>
        /// Tag Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class</param>
        public Tags(InstagramConfig config) : this(config, null)
        {

        }

        /// <summary>
        /// Tag Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Tags(InstagramConfig config, OAuthResponse auth) : base("tags/", config, auth)
        {

        }

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <para>Requires Authentication: False</para>
        /// <param name="tagName">Return information about this tag.</param>
        public Task<TagResponse> Get(string tagName)
        {
            var request = Request("{tag}");
            request.AddUrlSegment("tag", tagName);
            return Client.ExecuteAsync<TagResponse>(request);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <para>Requires Authentication: False</para>
        /// <param name="tagName">Return information about this tag.</param>
        public Task<MediasResponse> Recent(string tagName)
        {
            return Recent(tagName, null, null, null);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <para>Requires Authentication: False</para>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="minTagId">Return media before this min_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxTagId">Return media after this max_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="count">Count of tagged media to return. Will still be governed by Instagram's enforced limit.</param>
        public Task<MediasResponse> Recent(string tagName, string minTagId, string maxTagId, int? count)
        {
            var request = Request("{tag}/media/recent");
            request.AddUrlSegment("tag", tagName);

            if (count.HasValue)
            {
                request.AddParameter("count", count.Value);
            }

            request.AddParameter("min_tag_id", minTagId);
            request.AddParameter("max_tag_id", maxTagId);

            return Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Gets a list of recently tagged media. Paginates until a predefined limit is reached or the end is reached. Note this could increase your daily limit
        /// </summary>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="min_tag_id">Return media before this min_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="max_tag_id">Return media after this max_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxPageCount">the number of pages at which you wish to stop returning data. Otherwise it keeps going until the end. Be warned, you could quickly use your daily limit</param>
        /// <returns>a response object containing a list of the media responses and the last returned Meta code</returns>
        public async Task<TagsMultiplePagesResponse> RecentMultiplePages(string tagName, string min_tag_id = "", string max_tag_id = "", int? maxPageCount = null)
        {
            var response = new TagsMultiplePagesResponse();
            if (maxPageCount == 0)
            {
                return response;
            }

            var results = await Recent(tagName, min_tag_id, max_tag_id, 100);
            response.PageCount = 1;

            while (results.Meta.Code == 200 && results.Pagination != null && results.Pagination.NextMaxId != null && results.Data != null && response.PageCount < maxPageCount)
            {
                response.Data.AddRange(results.Data);
                results = await Recent(tagName, null, results.Pagination.NextMaxId, 100);
                if (results.Meta.Code != 200 || results.Data == null || results.Data.Count <= 0)
                {
                    break;
                }
                response.PageCount++;
            }
            response.Meta = results.Meta;
            return response;
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <para>Requires Authentication: False</para>
        /// <param name="searchTerm">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public Task<TagsResponse> Search(string searchTerm)
        {
            var request = Request("search");
            request.AddParameter("q", searchTerm);
            return Client.ExecuteAsync<TagsResponse>(request);
        }
    }
}
