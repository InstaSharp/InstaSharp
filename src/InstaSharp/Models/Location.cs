using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {
    public class Location {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
    }
}
