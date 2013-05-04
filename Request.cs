using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp {
    internal class Request : RestRequest {

        public Request() : base() { }

        public Request(Method method = Method.GET) : base(method) { }

        public Request(string fragment, Method method = Method.GET) : base(fragment, method) { }

        public void AddParameter(string id, string value) {
            if (!string.IsNullOrEmpty(value)) base.AddParameter(id, value);
        }

        public void AddParameter(string id, int? value) {
            if (value.HasValue) base.AddParameter(id, value.ToString());
        }

        public void AddParameter(string id, DateTime? value) {
            if (value.HasValue) base.AddParameter(id, value.ToString());
        }

        public void AddParameter(string id, double? value) {
            if (value.HasValue) base.AddParameter(id, value.ToString());
        }
    }
}
