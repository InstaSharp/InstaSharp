using System;
using System.Linq;
using System.Threading.Tasks;
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
            var result = await locations.Search(36.166667, -86.783333, 2000);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Locations")]
        public async Task SearchFourSquareV2()
        {
            var result = await locations.Search(36.166667, -86.783333, 2000, "40b52f80f964a52052001fe3", Endpoints.Locations.FoursquareVersion.Two);
            Assert.AreEqual(result.Data.Count, 1);
            Assert.AreEqual(result.Data.Single().Name, "Microsoft");
        }

        [TestMethod, TestCategory("Locations")]
        public async Task ThrowIfPassFoursquareIdAndNotVersion()
        {
            try
            {
                var result = await locations.Search(36.166667, -86.783333, 2000, "40b52f80f964a52052001fe3");
                throw new Exception("Should throw before this");
            }
            catch (ArgumentNullException ex)
            {
                if (ex.ParamName != "foursquareVersion")
                {
                    throw;
                }
            }
        }
    }
}
