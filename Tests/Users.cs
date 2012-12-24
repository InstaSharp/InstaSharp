

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

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
            Assert.IsNotNull(result.Data.Username);
        }

        [TestMethod, TestCategory("Users.Get")]
        public void Get_Id()
        {
            var result = _users.Get(3);
            Assert.IsTrue(result.Data.Username.Length > 0, "Parameters: userId");
        }

        [TestMethod, TestCategory("Users.Feed")]
        public void Feed()
        {
            var result = _users.Feed();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Feed")]
        public void Feed_MaxId() {
            var result = _users.Feed(null, 10);
            Assert.IsTrue(result.Data.Count > 0, "Parameters: Count");
        }

        [TestMethod, TestCategory("Users.Feed")]
        public void Feed_MaxId_Count()
        {
            var result = _users.Feed("347882407661562162_319505", 10);
            Assert.IsTrue(result.Data.Count > 0, "Parameters: MaxId, Count");
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent()
        {
            var result = _users.Recent();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent_MaxId()
        {
            var result = _users.Recent("304848768082410173_2849381");
            Assert.IsTrue(result.Data.Count > 0, "Parameters: MaxId");
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent_MaxId_Count()
        {
            var result = _users.Recent("304848768082410173_2849381", "", 10);
            Assert.IsTrue(result.Data.Count > 0, "Parameters: MaxId, Count");
        }

        [TestMethod, TestCategory("Users.Recent")]
        public void Recent_MaxId_MinId_Count()
        {
            var result = _users.Recent("307891304812280686_2849381", "304848768082410173_2849381", 1);
            Assert.IsTrue(result.Data.Count > 0, "Parameters: MaxId, MinId, Count");
        }
    }
}

