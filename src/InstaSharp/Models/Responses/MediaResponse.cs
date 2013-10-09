using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class MediaResponse : IResponse {
        public Pagination Pagination { get; set; }
        public Meta Meta { get; set; }
        public Media Data { get; set; }
    }
}
