using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharp.Endpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Realtime : TestBase
    {
        readonly Subscription _realtime;

        const string RealTimeUpdateJson = @"[{ 
                 ""subscription_id"": ""1"",
                 ""object"": ""user"",
                 ""object_id"": ""1234"",
                 ""changed_aspect"": ""media"",
                 ""time"": 1297286541
             },
             {
                 ""subscription_id"": ""2"",
                 ""object"": ""tag"",
                 ""object_id"": ""csharp"",
                 ""changed_aspect"": ""media"",
                 ""time"": 1297286541
             }]";

        public Realtime()
        {
            _realtime = new Subscription(base.Config);
        }

        [TestMethod]
        public async Task SubscribeTag_WithNoClientSecret()
        {
            var result = await _realtime.Create(Subscription.Object.Tag, Subscription.Aspect.Media, "csharp");
            AssertMissingClientSecretUrlParameter(result);
            // This is where Instagram tries to call your callback, without implementing the pubhubsub implementatin that authenticates, it will fail
        }

        [TestMethod]
        public async Task SubscribeUser_WithNoClientSecret()
        {
            var result = await _realtime.Create(Subscription.Object.User, Subscription.Aspect.Media, "joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestMethod]
        public async Task UnsubscribeUser_WithNoClientSecret()
        {
            var result = await _realtime.UnsubscribeUser("joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestMethod]
        public async Task RemoveSubscriptionByObjectType()
        {
            var result = await _realtime.RemoveSubscription(Subscription.Object.Tag);
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestMethod]
        public async Task RemoveAllSubscriptions()
        {

            var result = await _realtime.RemoveAllSubscriptions();
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestMethod]
        public async Task ListAllSubscriptions()
        {
            var result = await _realtime.ListAllSubscriptions();
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestMethod]
        public void DeserializeRealTimeUpdateData()
        {
            var result = _realtime.DeserializeUpdatedMediaItems(new MemoryStream(Encoding.UTF8.GetBytes(RealTimeUpdateJson)));

            Assert.AreEqual(2, result.Count());
            var firstItem = result.First();
            Assert.AreEqual(1, firstItem.SubScriptionId);
            Assert.AreEqual("user", firstItem.Object);
            Assert.AreEqual("media", firstItem.ChangedAspect);
            Assert.AreEqual("1297286541", result.First().Time);
        }

        [TestMethod]
        public async Task GetUpdatedTagMediaItems()
        {
            String tagName = null;
            String lastId = null;
            var result =
                await
                    _realtime.GetUpdatedTagMediaItems(new MemoryStream(Encoding.UTF8.GetBytes(RealTimeUpdateJson)), 2, (t, l) =>
                    {
                        tagName = t;
                        lastId = l;
                    });
            Assert.IsNotNull(tagName);
            Assert.IsNotNull(lastId);
            Assert.AreEqual(true, result.Tags.Any());
        }
    }
}
