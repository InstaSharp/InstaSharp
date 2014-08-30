using System.Threading.Tasks;
using InstaSharp.Models;
using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Embedding : TestBase
    {
        readonly Endpoints.Embedding embedding;
        public Embedding()
        {
            embedding = new Endpoints.Embedding();
        }

        [TestMethod, TestCategory("Embedding")]
        public async Task ShortCode()
        {
            var result = await embedding.ShortCode("BUG", MediaSize.Thumbnail);
            Assert.AreEqual(true, result.IsSuccessStatusCode);
        }

        [TestMethod, TestCategory("Embedding")]
        public async Task MediaInfo()
        {
            var result = await embedding.MediaInfo("http://instagr.am/p/BUG/");
            AssertResponseCorrect(result);
            Assert.AreEqual(612, result.Height);
            Assert.AreEqual(612, result.Width);
            Assert.AreEqual("http://images.ak.instagram.com/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_7.jpg", result.Url);
        }

        [TestMethod, TestCategory("Embedding")]
        public async Task MediaInfoWithDimension()
        {
            var result = await embedding.MediaInfo("http://instagr.am/p/BUG/", maximumWidth: 600); // this dimension is less than the orignal one
            AssertResponseCorrect(result);
            Assert.AreEqual(306, result.Height);
            Assert.AreEqual(306, result.Width);
            Assert.AreEqual("http://images.ak.instagram.com/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_6.jpg", result.Url);
        }

        [TestMethod, TestCategory("Embedding")]
        public async Task MediaInfoWithHeightDimension()
        {
            var result = await embedding.MediaInfo("http://instagr.am/p/BUG/",  600); // this dimension is less than the orignal one
            AssertResponseCorrect(result);
            Assert.AreEqual(306, result.Height);
            Assert.AreEqual(306, result.Width);
            Assert.AreEqual("http://images.ak.instagram.com/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_6.jpg", result.Url);
        }

        private static void AssertResponseCorrect(OEmbedResponse result)
        {
            Assert.AreEqual("http://instagram.com/", result.ProviderUrl);
            Assert.AreEqual(72, result.AuthorId);
            Assert.AreEqual("5382_72", result.MediaId);
            Assert.AreEqual("danrubin", result.AuthorName);
            Assert.AreEqual("http://instagram.com/danrubin", result.AuthorUrl);
            Assert.AreEqual("Instagram", result.ProviderName);
            Assert.AreEqual("http://instagram.com/", result.ProviderUrl);
            Assert.AreEqual("Rays", result.Title);
            Assert.AreEqual("photo", result.Type);
            Assert.AreEqual("1.0", result.Version);
        }
    }
}