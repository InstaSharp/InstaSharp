using System.Collections.Generic;

namespace InstaSharp.Models.Responses
{
    public class LocationsResponse : Response
    {
        public List<Location> Data { get; set; }
    }
}
