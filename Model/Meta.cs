using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Model {
    public class Meta {
        [JsonMapping("code", JsonMapping.MappingType.Primitive)]
        public int Code { get; set; }
        [JsonMapping("error_type", JsonMapping.MappingType.Primitive)]
        public string ErrorType { get; set; }
        [JsonMapping("error_message", JsonMapping.MappingType.Primitive)]
        public string ErrorMessage { get; set; }
    }
}
