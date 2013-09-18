using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InstaSharp.Tests {
    
    [TestClass]
    public class Media : TestBase {

        readonly Endpoints.Media media;

        public Media() {
            media = new Endpoints.Media(Config, Auth);
        }

        [TestMethod, TestCategory("Media.Get")]
        public async void Get()
        {
            var result = await media.Get("371269465633127413_6860189");
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod, TestCategory("Media.Popular")]
        public async void Popular()
        {
            var result = await media.Popular();
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod, TestCategory("Media.Search")]
        public async void Search()
        {
            var result = await media.Search(36.166667, -86.783333, DateTime.Now, DateTime.Now.AddDays(-7), 2000);
            Assert.IsTrue(result.Data.Count > 0);
        }
    }
}
