using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Models.Responses;

namespace InstaSharp.Endpoints {
    public class Geographies : InstagramAPI {

        /// <summary>
        /// Geographies Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        public Geographies(InstagramConfig config) : base("/geographies/", config) {}

        /// <summary>
        /// Get very recent media from a geography subscription that you created. Note: you can only access Geographies that were explicitly created by your OAuth client. To backfill photos from the location covered by this geography, use the media search endpoint.
        /// <para>
        /// <c>Requires Authentication: </c>False
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media about which to retrieve data</param>
        /// <param name="count">Max number of media to return.</param>
        /// <param name="min_id">Return media before this min_id.</param>
        /// <returns>MediaResponse</returns>
        public MediaResponse Recent(string mediaId, int? count = null, string min_id = "") {
            return (MediaResponse)Mapper.Map<MediaResponse>(RecentJson(mediaId, count, min_id));
        }

        /// <summary>
        /// Get very recent media from a geography subscription that you created. Note: you can only access Geographies that were explicitly created by your OAuth client. To backfill photos from the location covered by this geography, use the media search endpoint.
        /// <para>
        /// <c>Requires Authentication: </c>False
        /// </para>
        /// </summary>
        /// <param name="mediaId">The id of the media about which to retrieve data</param>
        /// <param name="count">Max number of media to return.</param>
        /// <param name="min_id">Return media before this min_id.</param>
        /// <returns>String</returns>
        public string RecentJson(string mediaId, int? count = null, string min_id = "") {
            base.FormatUri(string.Format("{0}/media/recent", mediaId));

            if (count != null) base.Uri.AppendFormat("&count={0}", count);
            if (!string.IsNullOrEmpty(min_id)) base.Uri.AppendFormat("&min_id={0}", min_id);

            return HttpClient.GET(base.Uri.ToString());
        }
    }
}
