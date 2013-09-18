#if DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using InstaSharp.Endpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {
    [TestClass]
    public class Comments : TestBase {
        readonly Endpoints.Comments _comments;

        public Comments() {
            _comments = new Endpoints.Comments(config, auth);
        }

        [TestMethod, TestCategory("Comments.Get")]
        public void Get() {
            Assert.IsTrue(_comments.Get("371269465633127413_6860189").Data.Data.Count > 0);
        }

        // Gotta come back to this one because commenting is white-list only now via API
        /*[TestMethod, TestCategory("Comments.Post")]
        public void Post() {
            
            Assert.IsTrue(_comments.Post("371269465633127413_6860189", "I have beiber fever").Meta.Code == 200);
        }*/
    }
}

#endif