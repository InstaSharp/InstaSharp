using InstaSharp.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    [TestClass]
   public class Extensions
    {
        [TestMethod]

        public void ContainsWhiteSpace()
        {
            Assert.IsTrue(" ".ContainsWhiteSpace());
            Assert.IsTrue(" ".ContainsWhiteSpace()); //tab
            Assert.IsTrue("justin bieber ".Trim().ContainsWhiteSpace()); 
        }
    }
}
