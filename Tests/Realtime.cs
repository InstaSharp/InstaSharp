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
        readonly Endpoints.Subscription _realtime;

        public Realtime() {
            //_realtime = new Endpoints.Subscription(base.config);
        }

        [TestMethod]
        public void Subscribe() {
            // _realtime.Create(Object.User, InstaSharp.Endpoints.Subscription.Aspect.Media);
        }
    }
}

#endif
