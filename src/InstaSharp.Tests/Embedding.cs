using System.Threading.Tasks;
using InstaSharp.Endpoints;
using InstaSharp.Models;
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

        //[TestMethod, TestCategory("Media.Search")]
        //public async Task ShortCode()
        //{
        //    var result = await embedding.ShortCode("BUG", MediaSize.Thumbnail);
        //    Assert.AreEqual("http://distillery.s3.amazonaws.com/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_6.jpg", result.Location);
        //}

        [TestMethod, TestCategory("Embedding")]
        public async Task MediaInfo()
        {
            var result = await embedding.MediaInfo("http://instagr.am/p/BUG/");
            Assert.AreEqual("http://instagram.com/", result.ProviderUrl);
            Assert.AreEqual(72, result.AuthorId);
            Assert.AreEqual("5382_72", result.MediaId);
            Assert.AreEqual("danrubin", result.AuthorName);
            Assert.AreEqual("http://instagram.com/danrubin", result.AuthorUrl);
            Assert.AreEqual(612, result.Height);
            Assert.AreEqual(612, result.Width);
            Assert.AreEqual("Instagram", result.ProviderName);
            Assert.AreEqual("http://instagram.com/", result.ProviderUrl);
            Assert.AreEqual("Rays", result.Title);
            Assert.AreEqual("photo", result.Type);
            Assert.AreEqual("http://images.ak.instagram.com/media/2010/10/02/7e4051fdcf1d45ab9bc1fba2582c0c6b_7.jpg", result.Url);
            Assert.AreEqual("1.0", result.Version);
        }
    }
}