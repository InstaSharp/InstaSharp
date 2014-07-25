using System;
using System.Diagnostics;
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
                var result = await _realtime.Create(Subscription.Object.Tag, Subscription.Aspect.Media, "csharp");
                Assert.AreEqual(result.Meta.Code, TaskStatus.WaitingForActivation);
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
                var result = await _realtime.Create(Subscription.Object.User, Subscription.Aspect.Media, "joebloggs");
                Assert.AreEqual(result.Meta.Code, TaskStatus.WaitingForActivation);// This is where Instagram tries to call your callback
            }
            catch (Exception exception)
            {
                Assert.AreEqual("Response status code does not indicate success: 400 (BAD REQUEST).", exception.Message);
            }
        }

        //TODO: Create tests for remove methods
    }
}
