using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp {
    public class Request : RestRequest {

        public Request() : base() { }

        public Request(string fragment) : base(fragment) { }

        public void AddParameter(string id, string value) {
            if (!string.IsNullOrEmpty(value)) base.AddParameter(id, value);
        }

        public void AddParameter(string id, int? value) {
            if (value.HasValue) base.AddParameter(id, value.ToString());
        }

        public void AddParameter(string id, DateTime? value) {
            if (value.HasValue) base.AddParameter(id, value.ToString());
        }
    }
}
