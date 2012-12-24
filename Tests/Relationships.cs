using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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
            Assert.IsTrue(result.Meta.Code == 200);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public void Follows_Id() {
            var result = _relationships.Follows(auth.User.Id);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Relationships.Follows")]
        public void Follows_Json() {
            var result = _relationships.FollowsJson(base.auth.User.Id);
            Console.WriteLine(result);
        }
    }
}
