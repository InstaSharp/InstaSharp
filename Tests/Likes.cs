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
    public class Likes : TestBase {

        readonly Endpoints.Likes _likes;

        public Likes()
            : base() {
            _likes = new Endpoints.Likes(base.config, base.auth);
        }

        [TestMethod, TestCategory("Likes.Get")]
        public void Get() {
            var result = _likes.Get("371269465633127413_6860189");
            Assert.IsTrue(result.Data.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Likes.PostAndDelete")]
        public void PostAndDelete() {
            // how do I test this? You can't get the id of the liked media
            var id = _likes.Post("371269465633127413_6860189");
        }
    }
}

#endif
