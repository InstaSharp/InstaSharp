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

        [TestCategory("Subscribe.Create")]
        [TestMethod]
        public async Task SubscribeTag_WithNoClientSecret()
        {
            var result = await _realtime.Create(Subscription.Object.Tag, Subscription.Aspect.Media, "csharp");
            AssertMissingClientSecretUrlParameter(result);
            // This is where Instagram tries to call your callback, without implementing the pubhubsub implementatin that authenticates, it will fail
        }
        [TestCategory("Subscribe.Create")]
        [TestMethod]
        public async Task SubscribeUser_WithNoClientSecret()
        {
            var result = await _realtime.Create(Subscription.Object.User, Subscription.Aspect.Media, "joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.Unsubscribe")]
        [TestMethod]
        public async Task UnsubscribeUser_WithNoClientSecret()
        {
            var result = await _realtime.UnsubscribeUser("joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }
        [TestCategory("Subscribe.Unsubscribe")]
        [TestMethod]
        public async Task RemoveSubscriptionByObjectType()
        {
            var result = await _realtime.RemoveSubscription(Subscription.Object.Tag);
            AssertMissingClientSecretUrlParameter(result);
        }
        [TestCategory("Subscribe.UnsubscribeAll")]
        [TestMethod]
        public async Task RemoveAllSubscriptions()
        {
            var result = await _realtime.RemoveAllSubscriptions();
            AssertMissingClientSecretUrlParameter(result);
        }
        [TestCategory("Subscribe.ListAllSubscriptions")]
        [TestMethod]
        public async Task ListAllSubscriptions()
        {
            var result = await _realtime.ListAllSubscriptions();
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.DeserializeRealTimeUpdateData")]
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

        [TestCategory("Subscribe.GetUpdatedTagMediaItems")]
        [TestMethod]
        public async Task GetUpdatedTagMediaItems()
        {
            String tagName = null;
            String lastId = null;

            var result = await _realtime.GetUpdatedTagMediaItems(new MemoryStream(Encoding.UTF8.GetBytes(RealTimeUpdateJson)), 2, (t, l) =>
                    {
                        tagName = t;
                        lastId = l;
                    });

            Assert.IsNotNull(tagName);
            Assert.IsNotNull(lastId);
            Assert.AreEqual(result.TagMedia.First().Value.Last().Id, lastId);
            Assert.AreEqual(1, result.TagMedia.Count()); // only the 'tag' item types should be returned, of which there is one ('csharp')
            Assert.AreEqual(true, result.TagMedia.First().Value.Any()); // we should have some nedia objects in there 

            var result2 = await _realtime.GetUpdatedTagMediaItems(new MemoryStream(Encoding.UTF8.GetBytes(RealTimeUpdateJson)));
            Assert.AreEqual(result2.TagMedia.First().Value.Last().Id, lastId);
        }
    }
}
