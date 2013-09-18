using System.Net.Http;
using PortableRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//TODO remover?
namespace InstaSharp {
    internal class Request : RestRequest {

        public Request() : base() { }

        public Request(HttpMethod method) : base(null, method) { }

        public Request(string fragment, HttpMethod method) : base(fragment, method) { }

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
