using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {
    [TestClass]
    public class Tags : TestBase {

        readonly Endpoints.Tags tags;

        public Tags() {
            tags = new Endpoints.Tags(Config);
        }

        [TestMethod, TestCategory("Tags.Get")]
        public async void Get() {
            var result = await tags.Get("beiber");
            Assert.IsTrue(result.Data.Name == "beiber");
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
