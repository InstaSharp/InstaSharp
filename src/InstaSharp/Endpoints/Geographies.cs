using InstaSharp.Extensions;
using InstaSharp.Models.Responses;
using System.Threading.Tasks;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Geographies Api
    /// </summary>
    public class Geographies : InstagramApi
    {
        /// <summary>
        /// Geographies Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        public Geographies(InstagramConfig config)
            : this(config, null)
        {
        }

        /// <summary>
        /// Geographies Endpoints
        /// </summary>
        /// <param name="config">An instance of the InstagramConfig class.</param>
        /// <param name="auth">An instance of the OAuthResponse class.</param>
        public Geographies(InstagramConfig config, OAuthResponse auth)
            : base("geographies/", config, auth)
        {
        }

        /// <summary>
        /// Get very recent media from a geography subscription that you created. Note: you can only access Geographies that were explicitly created by your OAuth client. To backfill photos from the location covered by this geography, use the media search endpoint.
        /// <para><c>Requires Authentication: </c>False
        /// </para>
        /// </summary>
        /// <param name="geoId">The id of the media about which to retrieve data</param>
        /// <returns>A media response containing a list of media</returns>
        public Task<MediaResponse> Recent(int geoId)
        {
            return Recent(geoId, null, null);
        }

        /// <summary>
        /// Get very recent media from a geography subscription that you created. Note: you can only access Geographies that were explicitly created by your OAuth client. To backfill photos from the location covered by this geography, use the media search endpoint.
        /// <para><c>Requires Authentication: </c>False
        /// </para>
        /// </summary>
        /// <param name="geoId">The id of the media about which to retrieve data</param>
        /// <param name="count">Max number of media to return.</param>
        /// <param name="minId">Return media before this min_id.</param>
        /// <returns>A media response containing a list of media</returns>
        public Task<MediaResponse> Recent(int geoId, int? count, string minId)
        {
            var request = Request("{id}/media/recent");
            request.AddUrlSegment("id", geoId.ToString());
            request.AddParameter("count", count);
            request.AddParameter("min_id", minId);
            return Client.ExecuteAsync<MediaResponse>(request);
        }
    }
}
