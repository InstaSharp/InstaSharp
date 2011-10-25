using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    
    [AttributeUsage(AttributeTargets.All, AllowMultiple=false)]
    public class JsonMapping : System.Attribute {

        public enum MappingType {
            Primitive,
            Class,
            Collection
        }

        public string MapsTo { get; private set; }
        public MappingType MapType { get; private set; }

        public JsonMapping(string mapsTo, MappingType mappingType) {
            MapsTo = mapsTo;
            MapType = mappingType;
        }
    }
}
