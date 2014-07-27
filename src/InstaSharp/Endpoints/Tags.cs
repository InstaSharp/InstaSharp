using System.Collections.Generic;
using System.Linq;
using System.Net;
using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    public class Tags : InstagramApi
    {

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
        public Task<TagResponse> Get(string tagName)
        {
            var request = base.Request("{tag}");
            request.AddUrlSegment("tag", tagName);
            return base.Client.ExecuteAsync<TagResponse>(request);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. 
        /// Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="minTagId">Return media before this min_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxTagId">Return media after this max_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="count">Count of tagged media to return. Will still be governed by Instagram's enforced limit.</param>
        public Task<MediasResponse> Recent(string tagName, string minTagId = "", string maxTagId = "", int? count = null)
        {
            var request = base.Request("{tag}/media/recent");
            request.AddUrlSegment("tag", tagName);

            if (count.HasValue)
            {
                request.AddParameter("count", count.Value);
            }

            request.AddParameter("min_tag_id", minTagId);
            request.AddParameter("max_tag_id", maxTagId);

            return base.Client.ExecuteAsync<MediasResponse>(request);
        }

        /// <summary>
        /// Gets a list of recently tagged media. Paginates until a predefined limit is reached or the end is reached. Note this could increase your daily limit Check <see cref="Response.CallsRemainingThisHour"/>
        /// </summary>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="minTagId">Return media [before]after  this min_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxTagId">Return media [after] before this max_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxPageCount">the number of pages at which you wish to stop returning data. Otherwise it keeps going until the end. Be warned, you could quickly use your daily limit</param>
        /// <param name="stopatMediaId">Doesnt return any data older than or including this id</param>
        /// <returns>a response object containing a list of the media responses and the last returned Meta code</returns>
        /// <remarks>http://stackoverflow.com/questions/20625173/how-does-instagrams-get-tags-tag-media-recent-pagination-actually-work?rq=1 </remarks>
        public async Task<TagsMultiplePagesResponse> RecentMultiplePages(string tagName, string minTagId = "", string maxTagId = "", int? maxPageCount = null, string stopatMediaId = null)
        {
            var response = new TagsMultiplePagesResponse();
            if (maxPageCount == 0)
            {
                return response;
            }

            var results = await Recent(tagName, minTagId, maxTagId, 100);
            response.PageCount = 1;
            var idFound = CropDataIfIdFound(results.Data, stopatMediaId);
            if (idFound)
            {
                response.Data.AddRange(results.Data);
                response.PaginationNextMaxId = results.Pagination.NextMaxId;
                return response;
            }

            // keep paging back in time until a recent is found
            while (results.Meta.Code == (int)HttpStatusCode.OK
                                    && results.Pagination != null
                                    && results.Pagination.NextMaxId != null
                                    && results.Data != null
                                    && response.PageCount < maxPageCount
                                    && (stopatMediaId != null && !idFound)) //results.Pagination.NextMaxId
            {
                response.Data.AddRange(results.Data);

                results = await Recent(tagName, null, results.Pagination.NextMaxId, 100);
                if (results.Meta.Code != (int)HttpStatusCode.OK || results.Data == null || results.Data.Count <= 0)
                {
                    break;
                }
                idFound = CropDataIfIdFound(results.Data, stopatMediaId);
                response.PageCount++;
            }
            if (results.Pagination != null)
            {
                response.PaginationNextMaxId = results.Pagination.NextMaxId;
            }
            response.Meta = results.Meta;
            return response;
        }

        private static bool CropDataIfIdFound(List<Models.Media> data, string stopatMediaId)
        {
            if (stopatMediaId == null)
            {
                return false;
            }
            var item = data.FirstOrDefault(x => x.Id == stopatMediaId);
            return TrimLastAfterItem(data, item);
        }

        private static bool TrimLastAfterItem<T>(List<T> data, T item) where T : class
        {
            if (item == null)
            {
                return false;
            }
            var indexOf = data.IndexOf(item);
            data.RemoveRange(indexOf, data.Count - indexOf);
            return true;
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <para>
        /// <c>Requires Authentication: False</c>
        /// </para>
        /// <param name="searchTerm">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public Task<TagsResponse> Search(string searchTerm)
        {
            var request = base.Request("search");
            request.AddParameter("q", searchTerm);
            return base.Client.ExecuteAsync<TagsResponse>(request);
        }
    }
}
