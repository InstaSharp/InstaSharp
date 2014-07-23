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
        public  void SubscribeTag()
        {
            var result = _realtime.Create(Subscription.Object.Tag, Subscription.Aspect.Media, "csharp");
            Assert.AreEqual(result.Status, TaskStatus.WaitingForActivation);// This is where Instagram tries to call your callback
        }

        [TestMethod]
        public void SubscribeUser()
        {
            var result = _realtime.Create(Subscription.Object.User, Subscription.Aspect.Media, "joeb");
            Assert.AreEqual(result.Status, TaskStatus.WaitingForActivation);// This is where Instagram tries to call your callback
        }
    }
}
