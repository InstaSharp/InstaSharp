#if DEBUG

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using InstaSharp.Models.Responses;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Users : TestBase
    {
        readonly Endpoints.Users _users;

        public Users() : base() {
            _users = new Endpoints.Users(base.config, base.auth);
        }

        [TestMethod, TestCategory("Users.Get")]
        public void Get()
        {
            var result = _users.Get();

            // serialize the response to 

            Assert.IsNotNull(result.Data);
        }

        [TestMethod, TestCategory("Users.Get")]
        public void Get_Id()
        {
            var result = _users.Get("19854736");
            Assert.IsTrue(result.Data.Data.Username.Length > 0, "Parameters: userId");
        }

        [TestMethod, TestCategory("Users.Feed")]
        public void Feed()
        {
            var result = _users.Feed();
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Feed")]
        public void Feed_MaxId() {
            var result = _users.Feed(null, 10);
            Assert.IsTrue(result.Data.Data.Count > 0, "Parameters: Count");
        }

        [TestMethod, TestCategory("Users.Feed")]
        public void Feed_MaxId_Count()
        {
            var result = _users.Feed("347882407661562162_319505", 10);
            Assert.IsTrue(result.Data.Data.Count > 0, "Parameters: MaxId, Count");
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent()
        {
            var result = _users.RecentSelf();
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent_MaxId()
        {
            var result = _users.Recent("304848768082410173_2849381");
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent_MinId() {
            var result = _users.RecentSelf(string.Empty, "142863708947821401_22987123");
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent_MinId_Count() {
            var result = _users.RecentSelf(string.Empty, "142863708947821401_22987123", 3);
            Assert.IsTrue(result.Data.Data.Count == 3);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent_MaxId_Count()
        {
            var result = _users.RecentSelf("304848768082410173_2849381", string.Empty, 3);
            Assert.IsTrue(result.Data.Data.Count == 3);
        }

        [TestMethod, TestCategory("Users.Search")]
        public void Search() {
            var result = _users.Search("beiber");
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Liked")]
        public void Liked() {
            var result = _users.Liked();
            Assert.IsTrue(result.Data.Meta.Code == 200);
        }
    }
}

#endif