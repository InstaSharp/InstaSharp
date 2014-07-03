using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {
    [TestClass]
    public class Relationships : TestBase {
        readonly Endpoints.Relationships relationships;

        public Relationships() {
            relationships = new Endpoints.Relationships(Config, Auth);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public async Task Follows()
        {
            var result = await relationships.Follows();
            Assert.IsTrue(result.Meta.Code == 200);
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
        public async Task FollowedBy_NextCursor()
        {
            //This test will fail if testing with an account with less than one page of followers
            var result = await relationships.FollowedBy();
            result = await relationships.FollowedBy(null, result.Pagination.NextCursor);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.RequestedBy")]
        public async Task RequestedBy()
        {
            var result = await relationships.RequestedBy();
            // TODO: How to test requests if there aren't any?
            Assert.IsTrue(result.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Relationships.Relationship")]
        public async Task Relationship()
        {
            var follow = await relationships.Relationship(3);
            Assert.AreEqual(follow.Data.OutgoingStatus, "none");
            Assert.AreEqual(follow.Data.IncomingStatus, "none");
        }

        [TestMethod, TestCategory("Relationships.Relationship")]
        public async Task RelationshipAction()
        {
            var follow = await relationships.Relationship(3, Endpoints.Relationships.Action.Follow);
            Assert.IsTrue(follow.Data.OutgoingStatus == "follows", "Failed on follow");

            var unfollow = await relationships.Relationship(3, Endpoints.Relationships.Action.Unfollow);
            Assert.IsTrue(unfollow.Data.OutgoingStatus == "none", "Failed on unfollow");
        }
    }
}
