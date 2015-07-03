using InstaSharp.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InstaSharp.Models
{
    public class Attribution
    {
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }
        /// <summary>
        /// Gets or sets the itunes url.
        /// </summary>
        /// <value>
        /// The itunes url.
        /// </value>
        [JsonProperty("itunes_url")]
        public string ITunesUrl { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Name { get; set; }
    }
}
