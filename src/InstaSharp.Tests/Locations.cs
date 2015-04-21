using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace InstaSharp.Tests
{

    [TestClass]
    public class Locations : TestBase
    {
        readonly Endpoints.Locations locations;

        public Locations()
        {
            locations = new Endpoints.Locations(Config, Auth);
        }

        [TestMethod, TestCategory("Locations.Get")]
        public async Task Get()
        {
            var result = await locations.Get("1");
            Assert.IsTrue(result != null);
        }

        [TestMethod, TestCategory("Locations.Recent")]
        public async Task Recent()
        {
            var result = await locations.Recent("1");
            Assert.IsTrue(result != null);
        }

        [TestMethod, TestCategory("Locations.Search")]
        public async Task Search()
        {
            var result = await locations.Search(36.100000, -86.783333, 2000);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Locations")]
        public async Task SearchFourSquareV2()
        {
            var result = await locations.Search("40b52f80f964a52052001fe3", Endpoints.Locations.FoursquareVersion.Two);
            Assert.AreEqual(result.Data.Count, 1);
            Assert.AreEqual(result.Data.Single().Name, "Microsoft");
        }

        [TestMethod, TestCategory("Locations.Search")]
        public async Task SearchFacebookPlaces()
        {
            var result = await locations.Search(104999729569954);
            var locationItem = result.Data.Single();
            Assert.AreEqual(1.379678091M, locationItem.Latitude);
            Assert.AreEqual(103.848876663M, locationItem.Longitude);
            Assert.AreEqual(locationItem.Id, 906462);
            Assert.AreEqual("Nanyang Polytechnic", locationItem.Name);
        }
    }
}
