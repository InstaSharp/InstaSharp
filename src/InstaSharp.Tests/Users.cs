using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

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
        public async Task Get_Id()
        {
            var result = await users.Get(InstaSharpTest2UserId);
            Assert.IsTrue(result.Data.Username == "instasharptest2");
        }

        [TestMethod, TestCategory("Users.Get")]
        public async Task Get_Self()
        {
            var result = await users.GetSelf();
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_Self()
        {
            var result = await users.RecentSelf();
            Assert.IsTrue(result.Data.Any());
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_UserId()
        {
            var result = await users.Recent(FfujiyUserId);
            Assert.IsTrue(result.Data.Any());
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_Self_Count()
        {
            const int count = 3;

            var result = await users.RecentSelf(null, null, count, null, null);
            Assert.AreEqual(count, result.Data.Count);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MinId()
        {
            var result = await users.RecentSelf(string.Empty, "142863708947821401_22987123", null, null, null);
            Assert.IsTrue(result.Data.Any());
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MinId_Count()
        {
            const int count = 3;

            var result = await users.RecentSelf(string.Empty, "142863708947821401_22987123", count, null, null);
            Assert.AreEqual(count, result.Data.Count);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MaxId()
        {
            var normalResult = await users.RecentSelf(null, null, 1, null, null);
            var result = await users.RecentSelf(normalResult.Data.First().Id, string.Empty, null, null, null);
            Assert.IsTrue(result.Data.Any());
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MaxId_Count()
        {
            const int count = 3;

            var normalResult = await users.RecentSelf(null, null, 1, null, null);
            var result = await users.RecentSelf(normalResult.Data.First().Id, string.Empty, count, null, null);
            Assert.AreEqual(count, result.Data.Count);
        }

        [TestMethod, TestCategory("Users.Search")]
        public async Task Search()
        {
            var result = await users.Search(FfujiyUserName, null);
            Assert.IsTrue(result.Data.Any());
        }

        [TestMethod, TestCategory("Users.Liked")]
        public async Task Liked()
        {
            var result = await users.Liked(null, null);
            Assert.AreEqual(HttpStatusCode.OK, result.Meta.Code);
        }
    }
}
