using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    /// <summary>
    /// Locations Response
    /// </summary>
    public class LocationsResponse : Response
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Location> Data { get; set; }
    }
}
