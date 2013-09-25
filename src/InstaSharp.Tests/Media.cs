using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InstaSharp.Tests {
    
    [TestClass]
    public class Media : TestBase {

        readonly Endpoints.Media media;

        public Media() {
            media = new Endpoints.Media(Config, Auth);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task Get()
        {
            var result = await media.Get("555");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Media.Popular")]
        public async Task Popular()
        {
            var result = await media.Popular();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Media.Search")]
        public async Task Search()
        {
            var result = await media.Search(36.166667, -86.783333, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6), 2000);
            Assert.IsTrue(result.Data.Count > 0);
        }
    }
}
