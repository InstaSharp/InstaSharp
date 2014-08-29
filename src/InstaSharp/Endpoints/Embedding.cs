using System;
using System.Threading.Tasks;
using InstaSharp.Extensions;
using InstaSharp.Models.Responses;

namespace InstaSharp.Endpoints
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks><see cref="http://instagram.com/developer/embedding/"/></remarks>
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
        /// <returns></returns>
        public Task<ShortLinkMediaInfoResponse> MediaInfo(string shortlink)
        {
            var request = Request("/oembed/?url=" + shortlink);
            return Client.ExecuteAsync<ShortLinkMediaInfoResponse>(request);
        }

        /// <summary>
        /// Given a short link, issues a redirect to that media's JPG file.
        /// Search media by shortcode from url. An example shortlink is http://instagram.com/p/D/ Its corresponding shortcode is D.
        /// </summary>
        /// <param name="shortcode">A media object's shortcode can be found in its shortlink URL.</param>
        /// <param name="mediaSize">Size of the media.</param>
        /// <returns></returns>
        //public Task<ShortCodeResponse> ShortCode(string shortcode, MediaSize mediaSize = MediaSize.Medium)
        //{
        //    var request = Request("/p/" + shortcode + "/media/?size=" + (char)mediaSize);
        //    return Client.ExecuteAsync<ShortCodeResponse>(request);
        //}
    }
}
