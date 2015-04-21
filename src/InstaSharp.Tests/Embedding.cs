using InstaSharp.Models;
using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

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
            Assert.AreEqual(null, result.Height);
            Assert.AreEqual(658, result.Width);
            Assert.AreEqual(612, result.ThumbnailHeight);
            Assert.AreEqual(612, result.ThumbnailWidth);

            Assert.AreEqual("https://instagramimages-a.akamaihd.net/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_7.jpg", result.ThumbnailUrl);
        }

        [TestMethod, TestCategory("Embedding")]
        public async Task MediaInfoWidthDimension()
        {
            var result = await embedding.MediaInfo("http://instagr.am/p/BUG/", null, 600, null, null); // this dimension is less than the original
            AssertResponseCorrect(result);
            Assert.AreEqual(null, result.Height);
            Assert.AreEqual(600, result.Width);
            Assert.AreEqual(306, result.ThumbnailHeight);
            Assert.AreEqual(306, result.ThumbnailWidth);
            Assert.AreEqual("https://instagramimages-a.akamaihd.net/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_6.jpg", result.ThumbnailUrl);
        }

        [TestMethod, TestCategory("Embedding")]
        public async Task MediaInfoWithHideCaption()
        {
            var result = await embedding.MediaInfo("http://instagr.am/p/BUG/", null, 600, true, null); // this dimension is less than the original
            AssertResponseCorrect(result);
            Assert.AreEqual(null, result.Height);
            //Assert.AreEqual(600, result.Width);
            //Assert.AreEqual(612, result.ThumbnailHeight);
            //Assert.AreEqual(612, result.ThumbnailWidth);
            Assert.IsFalse(result.Html.Contains("data-instgrm-captioned"));
            Assert.AreEqual("https://instagramimages-a.akamaihd.net/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_6.jpg", result.ThumbnailUrl);
        }

        [TestMethod, TestCategory("Embedding")]
        public async Task MediaInfoWithOmitScript()
        {
            var result = await embedding.MediaInfo("http://instagr.am/p/BUG/", null, 600, null, true); // this dimension is less than the original
            AssertResponseCorrect(result);
            Assert.AreEqual(null, result.Height);
            //Assert.AreEqual(600, result.Width);
            //Assert.AreEqual(612, result.ThumbnailHeight);
            //Assert.AreEqual(612, result.ThumbnailWidth);
            Assert.IsFalse(result.Html.Contains("embeds.js"));
            Assert.AreEqual("https://instagramimages-a.akamaihd.net/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_6.jpg", result.ThumbnailUrl); //different url
        }

        private static void AssertResponseCorrect(OEmbedResponse result)
        {
            Assert.AreEqual("https://instagram.com/", result.ProviderUrl);
            Assert.AreEqual(72, result.AuthorId);
            Assert.AreEqual("5382_72", result.MediaId);
            Assert.AreEqual("danrubin", result.AuthorName);
            Assert.AreEqual("https://instagram.com/danrubin", result.AuthorUrl);
            Assert.AreEqual("Instagram", result.ProviderName);
            Assert.AreEqual("https://instagram.com/", result.ProviderUrl);
            Assert.AreEqual("Rays", result.Title);
            Assert.AreEqual("rich", result.Type);
            Assert.AreEqual(1.0, result.Version);
            Assert.IsNotNull(result.Html);
        }
    }
}