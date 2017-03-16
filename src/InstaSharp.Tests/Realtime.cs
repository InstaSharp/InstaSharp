using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Subscription = InstaSharp.Endpoints.Subscription;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Realtime : TestBase
    {
        Subscription realtime;
        Subscription realtimeWithoutSecret;

        /// <summary>
        /// This is what the instagram docuomentation says (http://instagram.com/developer/realtime/), which is WRONG!, it doesn't contain an array
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
            realtime = new Subscription(ConfigWithSecret);
            realtimeWithoutSecret = new Subscription(Config);
        }

        [TestCategory("Subscribe.Create")]
        [TestMethod]
        public void CanDeserializeSubscriptionResponse()
        {
            //TODO
            //var result = JsonConvert.DeserializeObject<SubscriptionResponse>(SubscriptionCreateResponseREAL);
            //Assert.AreEqual(HttpStatusCode.OK, result.Meta.Code);
            //Assert.AreEqual("9580368", result.Data.Id);
        }

        [TestCategory("Subscribe.ListAllSubscriptions")]
        [TestMethod]
        public async Task ListAllSubscriptions()
        {
            var result = await realtime.ListAllSubscriptions();
        }

        [TestCategory("Subscribe.Create")]
        [TestMethod]
        public async Task SubscribeUser_WithNoClientSecret()
        {
            var result = await realtimeWithoutSecret.CreateUser("joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.Unsubscribe")]
        [TestMethod]
        public async Task UnsubscribeUser_WithNoClientSecret()
        {
            var result = await realtimeWithoutSecret.RemoveSubscription("joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.UnsubscribeAll")]
        [TestMethod]
        public async Task RemoveAllSubscriptions_WithNoClientSecret()
        {
            var result = await realtimeWithoutSecret.RemoveAllSubscriptions();
            AssertMissingClientSecretUrlParameter(result);
        }
    }
}
