using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Comments : TestBase
    {
        readonly Endpoints.Comments comments;

        public Comments()
        {
            comments = new Endpoints.Comments(Config, Auth);
        }

        [TestMethod, TestCategory("Comments.Get")]
        public async Task Get()
        {
            var commentResponse = await comments.Get("1387365790411610021_1415228826");
            Assert.IsTrue(commentResponse.Data.Count > 0);
        }

        [TestMethod, TestCategory("Comments")]
        public async Task Post()
        {
            var postComment = await comments.Post("1387365790411610021_1415228826", "Api Test");
            Assert.AreEqual(postComment.Meta.Code, HttpStatusCode.OK);

            var deleteComment = await comments.Delete("1387365790411610021_1415228826", postComment.Data.Id);
            Assert.AreEqual(deleteComment.Meta.Code, HttpStatusCode.OK);
        }
    }
}
