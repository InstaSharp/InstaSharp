using System;
using InstaSharp.Endpoints;
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
            realtime = new Subscription(base.Config);
        }

        [TestCategory("Subscribe.Create")]
        [TestMethod]
        public async Task SubscribeTag_WithNoClientSecret()
        {
            var result = await realtime.CreateTag("csharp");
            AssertMissingClientSecretUrlParameter(result);
            // This is where Instagram tries to call your callback, without implementing the pubhubsub implementatin that authenticates, it will fail
            try
            {
                await realtime.CreateTag("");
            }
            catch (Exception exception)
            {
                Assert.IsInstanceOfType(exception,typeof(ArgumentException));
            }
        }

        [TestCategory("Subscribe.Create")]
        [TestMethod]
        public void CanDeserializeSubscriptionResponse()
        {
            var result = JsonConvert.DeserializeObject<SubscriptionResponse>(SubscriptionCreateResponseREAL);
            Assert.AreEqual(HttpStatusCode.OK, result.Meta.Code);
            Assert.AreEqual("9580368", result.Data.Id);
        }

        [TestCategory("Subscribe.Create")]
        [TestMethod]
        public async Task SubscribeUser_WithNoClientSecret()
        {
            var result = await realtime.CreateUser("joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.Unsubscribe")]
        [TestMethod]
        public async Task UnsubscribeUser_WithNoClientSecret()
        {
            var result = await realtime.RemoveSubscription("joebloggs");
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.Unsubscribe")]
        [TestMethod]
        public async Task RemoveSubscriptionByObjectType()
        {
            var result = await realtime.RemoveSubscription(Subscription.Object.Tag);
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.UnsubscribeAll")]
        [TestMethod]
        public async Task RemoveAllSubscriptions()
        {
            var result = await realtime.RemoveAllSubscriptions();
            AssertMissingClientSecretUrlParameter(result);
        }

        [TestCategory("Subscribe.ListAllSubscriptions")]
        [TestMethod]
        public async Task ListAllSubscriptions()
        {
            var result = await realtime.ListAllSubscriptions();
            AssertMissingClientSecretUrlParameter(result);
        }


        [TestCategory("Subscribe.TestHeader")]
        [TestMethod]
        public void TestHeader()
        {
            realtime.InstagramConfig.ClientSecret = "6dc1787668c64c939929c17683d7cb74";
            realtime.EnableEnforceSignedHeader("200.15.1.1");
            var result = realtime.CreateXInstaForwardedHeader();
            Assert.AreEqual("200.15.1.1|7e3c45bc34f56fd8e762ee4590a53c8c2bbce27e967a85484712e5faa0191688", result);
          
            realtime.EnableEnforceSignedHeader("200.15.1.1,131.51.1.35");
            var result2 = realtime.CreateXInstaForwardedHeader();
            Assert.AreEqual("200.15.1.1,131.51.1.35|13cb27eee318a5c88f4456bae149d806437fb37ba9f52fac0b1b7d8c234e6cee", result2);
        }
    }
}
