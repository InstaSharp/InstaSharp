using System;
using System.Net;
using System.Threading.Tasks;
using InstaSharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Relationships : TestBase
    {
        readonly Endpoints.Relationships relationships;

        public Relationships()
        {
            relationships = new Endpoints.Relationships(Config, Auth);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public async Task Follows()
        {
            var result = await relationships.Follows();
            Assert.IsTrue(result.Meta.Code == HttpStatusCode.OK);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public async Task Follows_Id()
        {
            var result = await relationships.Follows(Auth.User.Id);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public async Task Follows_NextCursor()
        {
            //This test will fail if testing with an account with less than one page of follows
            var result = await relationships.Follows();
            result = await relationships.Follows(457273003/*ffujiy*/, result.Pagination.NextCursor);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public async Task FollowsAll()
        {
            var result = await relationships.FollowsAll(457273003);/*ffujiy*/
            Assert.IsTrue(result.Count > 50);
        }
        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public async Task FollowedBy()
        {
            var result = await relationships.FollowedBy();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public async Task FollowedBy_Id()
        {
            var result = await relationships.FollowedBy(Auth.User.Id);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public async Task FollowedByAll()
        {
            var result = await relationships.FollowedByAll();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public async Task FollowedBy_NextCursor()
        {
            //This test will fail if testing with an account with less than one page of followers
            var result = await relationships.FollowedBy();
            result = await relationships.FollowedBy(Auth.User.Id, result.Pagination.NextCursor);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.RequestedBy")]
        public async Task RequestedBy()
        {
            var result = await relationships.RequestedBy();

            Assert.IsTrue(result.Meta.Code == HttpStatusCode.OK);
        }

        [TestMethod, TestCategory("Relationships.Relationship")]
        public async Task Relationship()
        {
            var follow = await relationships.Relationship(3);
            Assert.AreEqual(follow.Data.OutgoingStatus, OutgoingStatus.None);
            Assert.AreEqual(follow.Data.IncomingStatus, IncomingStatus.None);
        }

        [TestMethod, TestCategory("Relationships.Relationship")]
        public async Task RelationshipAction()
        {
            var follow = await relationships.Relationship(3, Endpoints.Relationships.Action.Follow);
            Assert.IsTrue(follow.Data.OutgoingStatus == OutgoingStatus.Follows, "Failed on follow");

            var unfollow = await relationships.Relationship(3, Endpoints.Relationships.Action.Unfollow);
            Assert.IsTrue(unfollow.Data.OutgoingStatus == OutgoingStatus.None, "Failed on unfollow");
        }
    }
}
