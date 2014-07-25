using System;
using System.Threading.Tasks;
using InstaSharp.Endpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Realtime : TestBase
    {
        readonly Subscription _realtime;

        public Realtime()
        {
           _realtime = new Subscription(base.Config);
        }

        [TestMethod]
        public async Task SubscribeTag()
        {
            try
            {
                await _realtime.Create(Subscription.Object.Tag, Subscription.Aspect.Media, "csharp");
                // This is where Instagram tries to call your callback, without implementing the pubhubsub implementatin that authenticates, it will fail
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Response status code does not indicate success: 400 (BAD REQUEST).", exception.Message);
            }
        }

        [TestMethod]
        public async Task SubscribeUser()
        {
            try
            {
                await _realtime.Create(Subscription.Object.User, Subscription.Aspect.Media, "joebloggs");
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Response status code does not indicate success: 400 (BAD REQUEST).", exception.Message);
            }
        }

        [TestMethod]
        public async Task UnsubscribeUser()
        {
            try
            {
                await _realtime.UnsubscribeUser("joebloggs");
            }
            catch (Exception exception) // This method will fail unless the full unpubsubhub challenge has been completed
            {
                Assert.AreEqual("Response status code does not indicate success: 400 (BAD REQUEST).", exception.Message);
            }
        }


        [TestMethod]
        public async Task RemoveSubscriptionByObjectType()
        {
            try
            {
                var result = await _realtime.RemoveSubscription(Subscription.Object.Tag);
            }
            catch (Exception exception) // This method will fail unless the full unpubsubhub challenge has been completed
            {
                Assert.AreEqual("Response status code does not indicate success: 400 (BAD REQUEST).", exception.Message);
            }
        }

        [TestMethod]
        public async Task RemoveAllSubscriptions()
        {
            try
            {
                var result = await _realtime.RemoveAllSubscriptions();
            }
            catch (Exception exception) // This method will fail unless the full unpubsubhub challenge has been completed
            {
                Assert.AreEqual("Response status code does not indicate success: 400 (BAD REQUEST).", exception.Message);
            }
        }
    }
}
