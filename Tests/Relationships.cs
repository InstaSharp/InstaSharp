#if DEBUG

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using InstaSharp.Endpoints;

namespace InstaSharp.Tests {
    [TestClass]
    public class Relationships : TestBase {
        readonly Endpoints.Relationships _relationships;

        public Relationships() {
            _relationships = new Endpoints.Relationships(config, auth);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public void Follows() {
            var result = _relationships.Follows();
            Assert.IsTrue(result.Data.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public void Follows_Id() {
            var result = _relationships.Follows(auth.User.Id);
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public void FollowedBy() {
            var result = _relationships.FollowedBy();
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.FollowedBy")]
        public void FollowedBy_Id() {
            var result = _relationships.FollowedBy(auth.User.Id);
            Assert.IsTrue(result.Data.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.RequestedBy")]
        public void RequestedBy() {
            var result = _relationships.RequestedBy();
            // TODO: How to test requests if there aren't any?
            Assert.IsTrue(result.Data.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Relationships.Relationship")]
        public void Relationship() {
            // first follow Justin Beiber
            var follow = _relationships.Relationship(19854736, Endpoints.Relationships.Action.Follow);
            Assert.IsTrue(follow.Data.Data.OutgoingStatus == "follows", "Failed on follow");
            // now unfollow him
            var unfollow = _relationships.Relationship(19854736, Endpoints.Relationships.Action.Unfollow);
            Assert.IsTrue(unfollow.Data.Data.OutgoingStatus == "none", "Failed on unfollow");
        }
    }
}

#endif