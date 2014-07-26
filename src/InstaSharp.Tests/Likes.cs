using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {

    [TestClass]
    public class Likes : TestBase {

        readonly Endpoints.Likes likes;

        public Likes()
        {
            likes = new Endpoints.Likes(Config, Auth);
        }

        [TestMethod, TestCategory("Likes.Get")]
        public async Task Get() {
            var result = await likes.Get("555");
            Assert.IsTrue(result.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Likes.PostAndDelete")]
        public async Task PostAndDelete()
        {
            await likes.Post("649561442972790953_457273003");
            await likes.Delete("649561442972790953_457273003");
        }
    }
}
