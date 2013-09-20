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
            Assert.IsTrue((await comments.Get("555")).Data.Count > 0);
        }

        // Gotta come back to this one because commenting is white-list only now via API
        /*[TestMethod, TestCategory("Comments.Post")]
        public void Post() {
            
            Assert.IsTrue(_comments.Post("371269465633127413_6860189", "I have beiber fever").Meta.Code == 200);
        }*/
    }
}
