using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Tags : TestBase
    {

        readonly Endpoints.Tags tags;

        public Tags()
        {
            tags = new Endpoints.Tags(Config, Auth);
        }

        [TestMethod, TestCategory("Tags.Get")]
        public async Task Get()
        {
            var result = await tags.Get("keyboard");
            Assert.IsTrue(result.Data.Name == "keyboard");
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
            var result = await tags.Recent("keyboard");
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task Recent_MinTagId()
        {
            var result = await tags.Recent("keyboard");
            var minPageId = result.Pagination.MinTagId;
            result = await tags.Recent("keyboard", minPageId, null, null);
            Assert.IsTrue(result.Data.Count == 0);
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task Recent_NextMaxTagId()
        {
            var result = await tags.Recent("keyboard");
            var nextMaxTagId = result.Pagination.NextMaxTagId;
            result = await tags.Recent("keyboard", null, nextMaxTagId, null);
               Assert.IsTrue(result.Data.Count>0);
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task RecentIncorrectlyFormatted()
        {
            var invalidTags = new[] { "csharp.aspnet", "#csharpaspnet", "csharp aspnet" };
            var exceptionCount = 0;
            foreach (var tagName in invalidTags)
            {
                try
                {
                    await tags.Recent(tagName);
                }
                catch (Exception exception)
                {
                    Assert.IsInstanceOfType(exception, typeof(ArgumentException));
                    exceptionCount++;
                }
            }
            Assert.AreEqual(exceptionCount, invalidTags.Length);
        }

        [TestMethod, TestCategory("Tags.Recent")]
        public async Task RecentMultiplePages()
        {
            var result = await tags.RecentMultiplePages("keyboard", null, null, 3);
            Assert.IsTrue(result.Data.Any());
            Assert.AreEqual(result.Data.Select(x => x.Id).Distinct().Count(), result.Data.Count);
            Assert.AreEqual(result.Data.Select(x => x.Link).Distinct().Count(), result.Data.Count);
        }
    }
}
