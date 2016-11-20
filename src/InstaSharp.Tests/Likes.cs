using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace InstaSharp.Tests
{

    [TestClass]
    public class Likes : TestBase
    {

        readonly Endpoints.Likes likes;

        public Likes()
        {
            likes = new Endpoints.Likes(Config, Auth);
        }

        [TestMethod, TestCategory("Likes.Get")]
        public async Task Get()
        {
            var result = await likes.Get("1387365790411610021_1415228826");
            Assert.IsTrue(result.Meta.Code == HttpStatusCode.OK);
        }

        [TestMethod, TestCategory("Likes.PostAndDelete")]
        public async Task PostAndDelete()
        {
            var result = await likes.Post("1387365790411610021_1415228826");
            var result2 = await likes.Delete("1387365790411610021_1415228826");
        }
    }
}
