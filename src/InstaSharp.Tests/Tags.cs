using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    internal class Tags : TestBase
    {

        readonly Endpoints.Tags tags;

        public Tags()
        {
            tags = new Endpoints.Tags(Config);
        }

        [TestMethod, TestCategory("Tags.Get")]
        public async Task Get()
        {
            var result = await tags.Get("beiber");
            Assert.IsTrue(result.Data.Name == "beiber");
        }

        [TestMethod, TestCategory("Tags.Search")]
        public async Task Search()
        {
            var result = await tags.Search("Cats");
            Assert.IsTrue(result.Data.Any());
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task Recent()
        {
            var result = await tags.Recent("csharp");
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task Recent_MinId()
        {
            var result = await tags.Recent("csharp");
            result = await tags.Recent("csharp", result.Pagination.NextMinId, null, null);
            Assert.IsTrue(result.Data.Count == 0);
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task Recent_MaxId()
        {
            var result = await tags.Recent("csharp");
            result = await tags.Recent("csharp", null, result.Pagination.NextMaxId, null);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task RecentMultiplePages()
        {
            var result = await tags.RecentMultiplePages("csharp", minTagId: null, maxTagId: null, maxPageCount: 3);
            Assert.IsTrue(result.Data.Any());
        }
    }
}
