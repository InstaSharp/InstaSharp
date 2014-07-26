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
    }
}
