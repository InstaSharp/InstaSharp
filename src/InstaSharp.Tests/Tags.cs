#if DEBUG

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Tests {
    [TestClass]
    public class Tags : TestBase {

        readonly Endpoints.Tags _tags;

        public Tags() {
            _tags = new Endpoints.Tags(base.config);
        }

        [TestMethod, TestCategory("Tags.Get")]
        public void Get() {
            var result = _tags.Get("beiber");
            Assert.IsTrue(result.Data.Data.Name == "beiber");
        }

        //[TestMethod, TestCategory("Tags.Recent")]
        //public void Recent() {
        //    var result = _tags.Recent("beiber");
        //    Assert.IsTrue(result.Data.Data.Count > 0);
        //}

        //[TestMethod, TestCategory("Tags.Recent")]
        //public void Recent_MinId() {
        //    var result = _tags.Recent("beiber", "1356386164843", null);
        //    Assert.IsTrue(result.Data.Data.Count > 0);
        //}

        //[TestMethod, TestCategory("Tags.Recent")]
        //public void Recent_MaxId() {
        //    var result = _tags.Recent("beiber", null, "1356386164843");
        //    Assert.IsTrue(result.Data.Data.Count > 0);
        //}
    
    }
}

#endif
