using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public async Task Get()
        {
            var result = await users.Get();

            // serialize the response to 

            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("Users.Get")]
        public async Task Get_Id()
        {
            var result = await users.Get("3808579");
            Assert.IsTrue(result.Data.Username == "nasagoddard", "Parameters: userId");
        }

        [TestMethod, TestCategory("Users.Get")]
        public async Task Get_Self()
        {
            var result = await users.GetSelf();
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("Users.Feed")]
        public async Task Feed()
        {
            var result = await users.Feed(null, null, null);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Feed")]
        public async Task Feed_MaxId()
        {
            var result = await users.Feed(null, null, 10);
            Assert.IsTrue(result.Data.Count > 0, "Parameters: Count");
        }

        [TestMethod, TestCategory("Users.Feed")]
        public async Task Feed_MaxId_Count()
        {
            var normalResult = await users.Feed(null, null, null);

            var result = await users.Feed(normalResult.Data.First().Id, null, 1);
            Assert.IsTrue(result.Data.First().Id == normalResult.Data.Skip(1).First().Id, "Parameters: MaxId, Count");
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent()
        {
            var result = await users.RecentSelf();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MaxId()
        {
            var result = await users.Recent("3");
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MinId()
        {
            var result = await users.RecentSelf(string.Empty, "142863708947821401_22987123", null, null, null);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MinId_Count()
        {
            const int count = 3;

            var result = await users.RecentSelf(null, null, count, null, null);
            Assert.AreEqual(count, result.Data.Count);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public async Task Recent_MaxId_Count()
        {
            var normalResult = await users.Feed(null, null, null);

            const int count = 3;

            var result = await users.RecentSelf(normalResult.Data.First().Id, string.Empty, count, null, null);
            Assert.AreEqual(count, result.Data.Count);
        }

        [TestMethod, TestCategory("Users.Search")]
        public async Task Search()
        {
            var result = await users.Search("beiber", null);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Liked")]
        public async Task Liked()
        {
            var result = await users.Liked(null, null);
            Assert.AreEqual(HttpStatusCode.OK, result.Meta.Code);
        }
    }
}
