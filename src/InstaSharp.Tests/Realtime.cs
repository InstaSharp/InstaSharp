using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Subscription = InstaSharp.Endpoints.Subscription;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Realtime : TestBase
    {
        Subscription _realtime;

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

        /// <summary>
        /// This is what the instagram docuomentation says, which is wrong, it doesnt contain a list
        /// </summary>
        private const string SubscriptionCreateResponse = @"
            {
                ""meta"": {
                    ""code"": 200
                },
                ""data"": [
                    {
                        ""id"": ""1"",
                        ""type"": ""subscribe"",
                        ""object"": ""user"",
                        ""aspect"": ""media"",
                        ""callback_url"": ""http://your-callback.com/url/""
                    },
                    {
                        ""id"": ""2"",
                        ""type"": ""subscription"",
                        ""object"": ""location"",
                        ""object_id"": ""2345"",
                        ""aspect"": ""media"",
                        ""callback_url"": ""http://your-callback.com/url/""
                    }
                ]
            }";

        /// <summary>
        /// This is an actual response
        /// </summary>
        private const string SubscriptionCreateResponseREAL = @"{""meta"":{""code"":200},""data"":{""object"":""tag"",""object_id"":""fdsfsdf"",""aspect"":""media"",""callback_url"":""http:\/\/86.146.99.110\/api\/instagram\/"",""type"":""subscription"",""id"":""9580368""}}";

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
        public void CanDeserializeSubscriptionResponse()
        {
            var result = JsonConvert.DeserializeObject<SubscriptionsResponse>(SubscriptionCreateResponseREAL);
            Assert.AreEqual(200, result.Meta.Code);
            Assert.AreEqual(9580368, result.Data.Id);
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
            //_realtime = new Subscription(base.Config, new RealTimeMediaUpdateCache()
            //{
            //    MostRecentMediaTagIds = new Dictionary<string, string>()
            //    {
            //        { "csharp", "772775173742246857_265022413" }
            //    }
            //});
            var result = await _realtime.GetUpdatedTagMediaItems(new MemoryStream(Encoding.UTF8.GetBytes(RealTimeUpdateJson)), 2, (t, l) =>
                    {
                        tagName = t;
                        lastId = l;
                    });

            Assert.IsNotNull(tagName);
            Assert.IsNotNull(lastId);
            Assert.AreEqual(result.TagMedia.First().Value.First().Id, lastId);
            Assert.AreEqual(1, result.TagMedia.Count()); // only the 'tag' item types should be returned, of which there is one ('csharp')
            Assert.AreEqual(true, result.TagMedia.First().Value.Any()); // we should have some media objects in there 

            //var result2 = await _realtime.GetUpdatedTagMediaItems(new MemoryStream(Encoding.UTF8.GetBytes(RealTimeUpdateJson)));
            //  Assert.AreEqual(result2.TagMedia.First().Value.Last().Id, lastId);
        }
    }
}
