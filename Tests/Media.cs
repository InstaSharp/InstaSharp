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
    public class Media : TestBase {

        readonly Endpoints.Media _media;

        public Media() {
            _media = new Endpoints.Media(config, auth);
        }

        [TestMethod, TestCategory("Media.Get")]
        public void Get() {
            var result = _media.Get("371269465633127413_6860189");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Media.Popular")]
        public void Popular() {
            var result = _media.Popular();
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Media.Search")]
        public void Search() {
            var result = _media.Search(36.166667, -86.783333, DateTime.Now, DateTime.Now.AddDays(-7), 2000);
            Assert.IsTrue(result.Data.Data.Count > 0);
        }
    }
}

#endif