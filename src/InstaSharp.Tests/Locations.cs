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
    public class Locations : TestBase {
        readonly Endpoints.Locations _locations;

        public Locations()
            : base() {
            _locations = new Endpoints.Locations(base.config, base.auth);
        }

        [TestMethod, TestCategory("Locations.Get")]
        public void Get() {
            var result = _locations.Get("1");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Locations.Recent")]
        public void Recent() {
            var result = _locations.Recent("1");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Locations.Search")]
        public void Search() {
            var result = _locations.Search(36.166667, -86.783333, 2000);
            Assert.IsTrue(result.Data.Data.Count > 0);
        }
    }
}

#endif