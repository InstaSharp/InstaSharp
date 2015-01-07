using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InstaSharp.Tests
{

    [TestClass]
    public class Media : TestBase
    {

        readonly Endpoints.Media media;

        public Media()
        {
            media = new Endpoints.Media(Config, Auth);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task Get()
        {
            var result = await media.Get("555");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task GetVideo()
        {
            var result = await media.Get("673935902211830157_3808579");
            Assert.IsTrue(result.Data != null);
            Assert.IsTrue(result.Data.Videos != null);
            Assert.IsTrue(result.Data.Videos.LowResolution != null);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task UserHasLikedTrue()
        {
            var result = await media.Get("3_3");
            Assert.IsTrue(result.Data.UserHasLiked.Value);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task UserHasLikedFalse()
        {
            var result = await media.Get("678318766466527577_3808579");
            Assert.IsFalse(result.Data.UserHasLiked.Value);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task UserHasLikedNull()
        {
            var mediaService = new Endpoints.Media(Config);
            var result = await mediaService.Get("678318766466527577_3808579");
            Assert.IsNull(result.Data.UserHasLiked);
        }

        [TestMethod, TestCategory("Media.Popular")]
        public async Task Popular()
        {
            var result = await media.Popular();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Media.Search")]
        public async Task SearchWithLocalAndDate()
        {
            var result = await media.Search(36.166667, -86.783333, 2000, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6));
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Media.Search")]
        public async Task SearchWithLocal()
        {
            var result = await media.Search(36.166667, -86.783333);
            Assert.IsTrue(result.Data.Count > 0);
        }
    }
}
