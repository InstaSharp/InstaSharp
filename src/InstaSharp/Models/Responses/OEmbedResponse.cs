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
        /// Gets the full URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>  
        [JsonProperty("url")]
        public String Url { get; set; }


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
        /// The height.
        /// </value>
        [JsonProperty("height")]
        public int Height { get; set; }

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
        public String Version { get; set; }

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
        /// <example>"photo"</example>
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
    }
}