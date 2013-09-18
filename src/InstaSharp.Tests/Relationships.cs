using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {
    [TestClass]
    public class Relationships : TestBase {
        readonly Endpoints.Relationships relationships;

        public Relationships() {
            relationships = new Endpoints.Relationships(Config, Auth);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public async void Follows() {
            var result = await relationships.Follows();
            Assert.IsTrue(result.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public async void Follows_Id() {
            var result = await relationships.Follows(Auth.User.Id);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public async void FollowedBy() {
            var result = await relationships.FollowedBy();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public async void FollowedBy_Id()
        {
            var result = await relationships.FollowedBy(Auth.User.Id);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.RequestedBy")]
        public async void RequestedBy()
        {
            var result = await relationships.RequestedBy();
            // TODO: How to test requests if there aren't any?
            Assert.IsTrue(result.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Relationships.Relationship")]
        public async void Relationship() {
            // first follow Justin Beiber
            var follow = await relationships.Relationship(19854736, Endpoints.Relationships.Action.Follow);
            Assert.IsTrue(follow.Data.OutgoingStatus == "follows", "Failed on follow");
            // now unfollow him
            var unfollow = await relationships.Relationship(19854736, Endpoints.Relationships.Action.Unfollow);
            Assert.IsTrue(unfollow.Data.OutgoingStatus == "none", "Failed on unfollow");
        }
    }
}
