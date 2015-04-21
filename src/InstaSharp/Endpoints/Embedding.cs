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
        /// <param name="shortlink">A short link, like http://instagr.am/p/fA9uwTtkSN/.</param>
        /// <returns></returns>
        public Task<OEmbedResponse> MediaInfo(string shortlink)
        {
            return MediaInfo(shortlink, null, null, null, null);
        }

        /// <summary>
        /// Given a short link, returns information about the media associated with that link.
        /// </summary>
        /// <param name="shortlink">A short link, like http://instagr.am/p/fA9uwTtkSN/.</param>
        /// <param name="callback">A JSON callback to be invoked.</param>
        /// <param name="maximumWidth">The maximum width.</param>
        /// <param name="hidecaption">If set to true, the embed code hides the caption. Defaults to false.</param>
        /// <param name="omitscript">If set to true, the embed code does not include the script tag. This is useful for websites that want to handle the loading of the embeds.js script by themselves.</param>
        /// <returns></returns>
        public Task<OEmbedResponse> MediaInfo(string shortlink, string callback, int? maximumWidth, bool? hidecaption, bool? omitscript)
        {
            if (maximumWidth <= 320)
            {
                throw new ArgumentException("Maximum width must be greater or equal to 320 if specified", "maximumWidth");
            }

            var request = Request("oembed");
            request.AddParameter("url", shortlink);
            request.AddParameter("callback", callback);

            if (omitscript.HasValue)
            {
                request.AddParameter("omitscript", omitscript.Value.ToString().ToLower());
            }
            if (hidecaption.HasValue)
            {
                request.AddParameter("hidecaption", hidecaption.Value.ToString().ToLower());
            }
            if (maximumWidth.HasValue)
            {
                request.AddParameter("maxwidth", maximumWidth.Value.ToString());
            }

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
