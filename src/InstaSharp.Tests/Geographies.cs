using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests {
   
    [TestClass]
    public class Geographies : TestBase
    {
        readonly Endpoints.Geographies geographies;

        public Geographies()
        {
            geographies = new Endpoints.Geographies(Config);
        }

        // gotta get the realtime subscriptions working first...
        /*[TestMethod, TestCategory("Geographies.Recent")]
        public void Recent() {
            var result = _geographies.Recent(20);
            Assert.IsTrue(result.Meta.Code == HttpStatusCode.OK);
        }*/
    }
}
