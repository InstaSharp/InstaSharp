using System;
using InstaSharp.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
    public class DateTimeExtensionsTest
    {
        [TestMethod]
        public void ToUnixTimestampTest()
        {
            var unixT = DateTimeExtensions.ToUnixTimestamp(new DateTime(2015, 5, 3, 15, 54, 20, DateTimeKind.Utc));

            Assert.AreEqual(1430668460, unixT);
        }
    }
}
