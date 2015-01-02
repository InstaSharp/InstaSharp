using System;
using Newtonsoft.Json;

namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// oEmbed is a format for allowing an embedded representation of a URL on third party sites. 
    /// </summary>
    public class OEmbedResponse
    {
        /// <summary>
        /// Gets the provider URL.
        /// </summary>
        /// <value>
        /// The provider URL.
        /// </value>
        [JsonProperty("provider_url")]
        public String ProviderUrl { get; set; }

        /// <summary>
        /// Gets the media identifier.
        /// </summary>
        /// <value>
        /// The media identifier.
        /// </value>
        [JsonProperty("media_id")]
        public String MediaId { get; set; }

        /// <summary>
        /// Getsthe title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title")]
        public String Title { get; set; }

        /// <summary>
        /// Gets the name of the author.
        /// </summary>
        /// <value>
        /// The name of the author.
        /// </value>
        [JsonProperty("author_name")]
        public String AuthorName { get; set; }

        /// <summary>
        /// Gets the height in pixels
        /// </summary>
        /// <value>
        /// The height. This may be null, as instagram images are square, use the width property
        /// 
        /// </value>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets the width in pixels </summary>
        /// <value>
        /// The width.
        /// </value>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [JsonProperty("version")]
        public float Version { get; set; }

        /// <summary>
        /// Gets the author Url.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [JsonProperty("author_url")]
        public String AuthorUrl { get; set; }

        /// <summary>
        /// Gets the author identifier.
        /// </summary>
        /// <value>
        /// The author identifier.
        /// </value>
        [JsonProperty("author_id")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        /// <example>always "rich"</example>
        [JsonProperty("type")]
        public String Type { get; set; }

        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        /// <value>
        /// The name of the provider.
        /// </value>
        /// <example>Instagram</example>
        [JsonProperty("provider_name")]
        public String ProviderName { get; set; }

        /// <summary>
        /// Gets the thumbnail url
        /// </summary>
        /// <value>
        /// The thumbnail url
        /// </value>
        /// <example>Instagram</example>
        [JsonProperty("thumbnail_url")]
        public String ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets the thumbnail url
        /// </summary>
        /// <value>
        /// The thumbnail url
        /// </value>
        /// <example>Instagram</example>
        [JsonProperty("thumbnail_width")]
        public int ThumbnailWidth { get; set; }

        /// <summary>
        /// Gets the height of the thumbnail.
        /// </summary>
        /// <value>
        /// The height of the thumbnail.
        /// </value>
        [JsonProperty("thumbnail_height")]
        public int ThumbnailHeight { get; set; }

        /// <summary>
        /// Gets the HTML.
        /// </summary>
        /// <value>
        /// The HTML.
        /// </value>
        /// <example>
        /// "<blockquote class="instagram-media" data-instgrm-captioned data-instgrm-version="4" style=" background:#FFF; border:0; border-radius:3px; box-shadow:0 0 1px 0 rgba(0,0,0,0.5),0 1px 10px 0 rgba(0,0,0,0.15); margin: 1px; max-width:658px; padding:0; width:99.375%; width:-webkit-calc(100% - 2px); width:calc(100% - 2px);"><div style="padding:8px;"> <div style=" background:#F8F8F8; line-height:0; margin-top:40px; padding:50% 0; text-align:center; width:100%;"> <div style=" background:url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACwAAAAsCAMAAAApWqozAAAAGFBMVEUiIiI9PT0eHh4gIB4hIBkcHBwcHBwcHBydr+JQAAAACHRSTlMABA4YHyQsM5jtaMwAAADfSURBVDjL7ZVBEgMhCAQBAf//42xcNbpAqakcM0ftUmFAAIBE81IqBJdS3lS6zs3bIpB9WED3YYXFPmHRfT8sgyrCP1x8uEUxLMzNWElFOYCV6mHWWwMzdPEKHlhLw7NWJqkHc4uIZphavDzA2JPzUDsBZziNae2S6owH8xPmX8G7zzgKEOPUoYHvGz1TBCxMkd3kwNVbU0gKHkx+iZILf77IofhrY1nYFnB/lQPb79drWOyJVa/DAvg9B/rLB4cC+Nqgdz/TvBbBnr6GBReqn/nRmDgaQEej7WhonozjF+Y2I/fZou/qAAAAAElFTkSuQmCC); display:block; height:44px; margin:0 auto -44px; position:relative; top:-22px; width:44px;"></div></div> <p style=" margin:8px 0 0 0; padding:0 4px;"> <a href="https://instagram.com/p/BUG/" style=" color:#000; font-family:Arial,sans-serif; font-size:14px; font-style:normal; font-weight:normal; line-height:17px; text-decoration:none; word-wrap:break-word;" target="_top">Rays</a></p> <p style=" color:#c9c8cd; font-family:Arial,sans-serif; font-size:14px; line-height:17px; margin-bottom:0; margin-top:8px; overflow:hidden; padding:8px 0 7px; text-align:center; text-overflow:ellipsis; white-space:nowrap;">A photo posted by Dan Rubin (@danrubin) on <time style=" font-family:Arial,sans-serif; font-size:14px; line-height:17px;" datetime="2010-10-02T21:16:51+00:00">Oct 10, 2010 at 2:16pm PDT</time></p></div></blockquote><script async defer src="//platform.instagram.com/en_US/embeds.js"></script>"
        /// </example>
        [JsonProperty("html")]
        public String Html { get; set; }
    }
}