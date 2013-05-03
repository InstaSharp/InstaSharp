#if DEBUG

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Tests
{
    [TestClass]
    public class Realtime : TestBase
    {
        readonly Endpoints.Realtime _realtime;

        public Realtime() {
            _realtime = new Endpoints.Realtime(base.config);
        }

        [TestMethod]
        public void Subscribe() {
            _realtime.Subscribe(Models.Subscription.Object.User, Models.Subscription.Aspect.Media);
        }
    }
}

#endif
