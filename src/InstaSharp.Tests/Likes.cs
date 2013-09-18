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
        public async void Get() {
            var result = await likes.Get("371269465633127413_6860189");
            Assert.IsTrue(result.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Likes.PostAndDelete")]
        public void PostAndDelete() {
            // how do I test this? You can't get the id of the liked media
            var id = likes.Post("371269465633127413_6860189");
        }
    }
}
