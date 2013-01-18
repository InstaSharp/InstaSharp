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
    public class Geographies : TestBase {
        readonly Endpoints.Geographies _geographies;

        public Geographies() : base() {
            _geographies = new Endpoints.Geographies(base.config);
        }

        // gotta get the realtime subscriptions working first...
        /*[TestMethod, TestCategory("Geographies.Recent")]
        public void Recent() {
            var result = _geographies.Recent(20);
            Assert.IsTrue(result.Meta.Code == 200);
        }*/
    }
}

#endif