using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {
    [TestClass]
    public class Comments : TestBase {
        readonly Endpoints.Comments comments;

        public Comments() {
            comments = new Endpoints.Comments(Config, Auth);
        }

        [TestMethod, TestCategory("Comments.Get")]
        public async Task Get()
        {
            var commentResponse = await comments.Get("555");
            Assert.IsTrue(commentResponse.Data.Count > 0);
        }

        // Gotta come back to this one because commenting is white-list only now via API
        /*[TestMethod, TestCategory("Comments")]
        public async Task Post()
        {
            var postComment = await comments.Post("555", "Api Test");
            Assert.AreEqual(postComment.Meta.Code, HttpStatusCode.OK);
        }*/
    }
}
