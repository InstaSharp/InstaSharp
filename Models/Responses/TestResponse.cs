using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models.Responses {
    public class TestResponse {
        public Pagination Pagination { get; set; }
        public Meta Meta { get; set; }
        public List<Media> Data { get; set; }   
    }
}
