using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Users : TestBase
    {
        readonly Endpoints.Users users;

        public Users()
        {
            users = new Endpoints.Users(Config, Auth);
        }

        [TestMethod, TestCategory("Users.Get")]
        public async void Get()
        {
            var result = await users.Get();

            // serialize the response to 

            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("Users.Get")]
        public async void Get_Id()
        {
            var result = await users.Get("19854736");
            Assert.IsTrue(result.Data.Username.Length > 0, "Parameters: userId");
        }

        [TestMethod, TestCategory("Users.Feed")]
        public async void Feed()
        {
            var result = await users.Feed();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Feed")]
        public async void Feed_MaxId()
        {
            var result = await users.Feed(null, 10);
            Assert.IsTrue(result.Data.Count > 0, "Parameters: Count");
        }

        [TestMethod, TestCategory("Users.Feed")]
        public async void Feed_MaxId_Count()
        {
            var result = await users.Feed("347882407661562162_319505", 10);
            Assert.IsTrue(result.Data.Count > 0, "Parameters: MaxId, Count");
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async void Recent()
        {
            var result = await users.RecentSelf();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async void Recent_MaxId()
        {
            var result = await users.Recent("304848768082410173_2849381");
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async void Recent_MinId()
        {
            var result = await users.RecentSelf(string.Empty, "142863708947821401_22987123");
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async void Recent_MinId_Count()
        {
            var result = await users.RecentSelf(string.Empty, "142863708947821401_22987123", 3);
            Assert.IsTrue(result.Data.Count == 3);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async void Recent_MaxId_Count()
        {
            var result = await users.RecentSelf("304848768082410173_2849381", string.Empty, 3);
            Assert.IsTrue(result.Data.Count == 3);
        }

        [TestMethod, TestCategory("Users.Search")]
        public async void Search()
        {
            var result = await users.Search("beiber");
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Liked")]
        public async void Liked()
        {
            var result = await users.Liked();
            Assert.IsTrue(result.Meta.Code == 200);
        }
    }
}
