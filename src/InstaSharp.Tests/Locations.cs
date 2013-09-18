using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {

    [TestClass]
    public class Locations : TestBase {
        readonly Endpoints.Locations locations;

        public Locations()
        {
            locations = new Endpoints.Locations(Config, Auth);
        }

        [TestMethod, TestCategory("Locations.Get")]
        public async void Get() {
            var result = await locations.Get("1");
            Assert.IsTrue(result != null);
        }

        [TestMethod, TestCategory("Locations.Recent")]
        public async void Recent()
        {
            var result = await locations.Recent("1");
            Assert.IsTrue(result != null);
        }

        [TestMethod, TestCategory("Locations.Search")]
        public async void Search()
        {
            var result = await locations.Search(36.166667, -86.783333, 2000);
            Assert.IsTrue(result.Data.Count > 0);
        }
    }
}
