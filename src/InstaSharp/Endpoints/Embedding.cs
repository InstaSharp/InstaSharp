using System;
using System.Net.Http;
using System.Threading.Tasks;
using InstaSharp.Extensions;
using InstaSharp.Models;
using InstaSharp.Models.Responses;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// The Embedding Api.
    /// Instagram provides two simple ways to get information about a shared link in order to display a preview: an OEmbed endpoint 
    /// and a simple URL append endpoint. Neither requires an access_token or client_id.
    /// </summary>
    /// <remarks><see href="http://instagram.com/developer/embedding/"/></remarks>
    public class Embedding : InstagramApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Embedding"/> class.
        /// </summary>
        public Embedding()
            : base(String.Empty, new InstagramConfig(null, null, null, null, "http://api.instagram.com/", null, null)) // for some reason it doesnt like the v1 suffix in the url
        {
        }

        /// <summary>
        /// Given a short link, returns information about the media associated with that link.
        /// </summary>
        /// <param name="shortlink">The shortlink.</param>
        /// <param name="maximumHeight">The maximum height.</param>
        /// <param name="maximumWidth">The maximum width.</param>
        /// <param name="hidecaption">If set to true, the embed code hides the caption. Defaults to false. 
        /// NOTE: If this is set to true the <see cref="maximumHeight"/> property appears to be disregarded</param>
        /// <param name="omitscript">If set to true, the embed code does not include the script tag. This is useful for websites that want to handle the loading of the embeds.js script by themselves.
        /// NOTE: If this is set to true the <see cref="maximumHeight"/> property appears to be disregarded. A different thumbnail url appears to also be returned</param>
        /// <returns></returns>
        public Task<OEmbedResponse> MediaInfo(string shortlink, int? maximumHeight = null, int? maximumWidth = null, bool? hidecaption = null, bool? omitscript = null)
        {
            if (maximumWidth != null && maximumWidth < 320)
            {
                throw new ArgumentException("Maximum width must be greater or equal to 320 if specified","maximumWidth");
            }

            var request = Request("/oembed/?url=" + shortlink + (maximumHeight == null ? String.Empty : "&maxheight=" + maximumHeight)
                                                              + (maximumWidth == null ? String.Empty : "&maxwidth=" + maximumWidth)
                                                              + (hidecaption == null ? String.Empty : "&hidecaption=" + hidecaption)
                                                              + (omitscript == null ? String.Empty : "&omitscript=" + omitscript));
            return Client.ExecuteAsync<OEmbedResponse>(request);
        }

        ///<summary>
        ///Given a short link, issues a redirect to that media's JPG file.
        ///Search media by shortcode from url. An example shortlink is http://instagram.com/p/D/ Its corresponding shortcode is D.
        ///</summary>
        ///<param name="shortcode">A media object's shortcode can be found in its shortlink URL.</param>
        ///<param name="mediaSize">Size of the media.</param>
        ///<returns>An HttpResponse Message with the Content containting the image data</returns>
        public Task<HttpResponseMessage> ShortCode(string shortcode, MediaSize mediaSize = MediaSize.Medium)
        {
            var request = Request("/p/" + shortcode + "/media/?size=" + (char)mediaSize);
            return Client.SendAsync(request);
        }
    }
}
