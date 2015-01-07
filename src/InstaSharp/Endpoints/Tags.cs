using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Tag API
    /// </summary>
    public class Tags : InstagramApi
    {
        /// <summary>
        /// The Instagram Api disallows '#', spaces, and special characters. It allows underscore
        /// </summary>
        /// <param name="tagName"></param>
        private static void ValidateTagName(string tagName)
        {
            var regex = new Regex(@"^\w+$");
            if (!regex.IsMatch(tagName))
            {
                throw new ArgumentException("'tagName' parameter contains invalid characters: " + tagName);
            }
        }

        /// <summary>
        /// Tag Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class</param>
        public Tags(InstagramConfig config)
            : this(config, null)
        {

        }

        /// <summary>
        /// Tag Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Tags(InstagramConfig config, OAuthResponse auth)
            : base("tags/", config, auth)
        {

        }

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <param name="tagName">Return information about this tag.</param>
        /// <returns>Tag Response</returns>
        /// <para>Requires Authentication: False</para>
        ///  <exception cref="ArgumentException">thrown when searchTerm contains invalida characters</exception>
        public Task<TagResponse> Get(string tagName)
        {
            ValidateTagName(tagName);
            var request = Request("{tag}");
            request.AddUrlSegment("tag", tagName);
            return Client.ExecuteAsync<TagResponse>(request);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <param name="tagName">Return information about this tag.</param>
        /// <returns>Medias Response</returns>
        /// <para>Requires Authentication: False</para>
        /// <exception cref="ArgumentException">thrown when searchTerm contains invalid characters</exception>
        public Task<MediasResponse> Recent(string tagName)
        {
            return Recent(tagName, null, null, null);
        }

        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects.
        /// </summary>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="minTagId">Return media before this min_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxTagId">Return media after this max_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="count">Count of tagged media to return. Will still be governed by Instagram's enforced limit.</param> 
        /// <exception cref="ArgumentException">thrown when searchTerm contains invalid characters</exception>
        /// <returns>Medias Response</returns>
        /// <para>Requires Authentication: False</para>
        public Task<MediasResponse> Recent(string tagName, string minTagId, string maxTagId, int? count)
        {
            ValidateTagName(tagName);

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
        /// Gets a list of recently tagged media. Paginates until a predefined limit is reached or the end is reached. Note this could increase your daily limit Check <see cref="Response.RateLimitLimit" />
        /// </summary>
        /// <param name="tagName">Return information about this tag.</param>
        /// <param name="minTagId">Return media [before]after  this min_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxTagId">Return media [after] before this max_tag_id. If you don't want to use this parameter, use null.</param>
        /// <param name="maxPageCount">the number of pages at which you wish to stop returning data. Otherwise it keeps going until the end. Be warned, you could quickly use your daily limit</param>
        /// <param name="stopatMediaId">Doesnt return any data older than or including this id</param>
        /// <returns>
        /// a response object containing a list of the media responses and the last returned Meta code
        /// </returns>
        /// <remarks>
        /// http://stackoverflow.com/questions/20625173/how-does-instagrams-get-tags-tag-media-recent-pagination-actually-work?rq=1
        /// </remarks>
        public async Task<TagsMultiplePagesResponse> RecentMultiplePages(string tagName, string minTagId = "", string maxTagId = "", int? maxPageCount = null, string stopatMediaId = null)
        {
            ValidateTagName(tagName);

            var response = new TagsMultiplePagesResponse();
            if (maxPageCount == 0)
            {
                return response;
            }


            var results = await Recent(tagName, minTagId, maxTagId, 100);
            if (results.Data == null)
            {
                response.Meta = results.Meta;
                return response;
            }

            response.PageCount = 1;
            var idFound = CropDataIfIdFound(results.Data, stopatMediaId);
            response.Data.AddRange(results.Data);

            if (idFound)
            {
                response.PaginationNextMaxId = results.Pagination.MinTagId;
                response.Meta = results.Meta;
                return response;
            }

            // keep paging back in time until a recent is found
            while (results.Meta.Code == HttpStatusCode.OK
                                    && results.Pagination != null
                                    && results.Pagination.NextMaxTagId != null
                                    && results.Data != null
                                    && response.PageCount < maxPageCount
                                    && !(stopatMediaId != null && idFound)) //results.Pagination.NextMaxId
            {
                results = await Recent(tagName, null, results.Pagination.NextMaxTagId, 100);
                if (results.Meta.Code != HttpStatusCode.OK || results.Data == null || results.Data.Count <= 0)
                {
                    break;
                }
                idFound = CropDataIfIdFound(results.Data, stopatMediaId);
                response.Data.AddRange(results.Data);
                response.PageCount++;
            }
            if (results.Pagination != null)
            {
                response.PaginationNextMaxId = results.Pagination.NextMaxTagId;
            }
            response.Meta = results.Meta;
            return response;
        }

        /// <summary>
        /// Crops data if id found
        /// </summary>
        /// <param name="data">List of media data</param>
        /// <param name="stopatMediaId">The media id without the _user suffix</param>
        /// <returns>true if id found, false otherwise</returns>
        private static bool CropDataIfIdFound(List<Models.Media> data, string stopatMediaId)
        {
            if (stopatMediaId == null)
            {
                return false;
            }
            var count = data.Count;
            data = data.TakeWhile(x => x.Id != stopatMediaId).ToList();
            return count != data.Count;
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="searchTerm">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        /// <returns>a <see cref="TagsResponse"/> object</returns>
        /// <para>Requires Authentication: False</para>
        /// <exception cref="ArgumentException">thrown when searchTerm contains invalid characters</exception>
        public Task<TagsResponse> Search(string searchTerm)
        {
            ValidateTagName(searchTerm);
            var request = Request("search");
            request.AddParameter("q", searchTerm);
            return Client.ExecuteAsync<TagsResponse>(request);
        }
    }
}
