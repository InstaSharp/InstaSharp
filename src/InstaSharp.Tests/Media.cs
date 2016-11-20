using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using InstaSharp.Models.Responses;

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
            var result = await media.Get("756098485446234014_1415228826");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task Get_WithSignedHeader()
        {
            var media = new Endpoints.Media(ConfigWithSecret, Auth);
            media.EnforceSignedRequests = true;

            var result = await media.Get("756098485446234014_1415228826");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task Shortcode()
        {
            var result = await media.Shortcode("p-M5EIO8-e");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task GetVideo()
        {
            var result = await media.Get("579991339860422858_457273003");
            Assert.IsTrue(result.Data != null);
            Assert.IsTrue(result.Data.Videos != null);
            Assert.IsTrue(result.Data.Videos.LowResolution != null);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task UserHasLikedTrue()
        {
            var result = await media.Get("756098117387669401_1415228826");
            Assert.IsTrue(result.Data.UserHasLiked.Value);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async Task UserHasLikedFalse()
        {
            var result = await media.Get("756098040556408727_1415228826");
            Assert.IsFalse(result.Data.UserHasLiked.Value);
        }

        [TestMethod, TestCategory("Media.Search")]
        public async Task SearchWithLocal()
        {
            var result = await media.Search(47.608013, -122.335167);
            Assert.IsTrue(result.Data.Count > 0);
        }
    }
}
