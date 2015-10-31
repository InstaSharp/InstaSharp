using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace InstaSharp.Tests
{
    public class TestBase
    {
        protected readonly OAuthResponse Auth;
        protected readonly InstagramConfig Config;
        protected readonly InstagramConfig ConfigWithSecret;

        protected TestBase()
        {
            // test account client id
            Config = new InstagramConfig()
            {
                ClientId = "554dfe9286994bbe98417d8dc7b69a24"
            };

            ConfigWithSecret = new InstagramConfig()
            {
                ClientId = "554dfe9286994bbe98417d8dc7b69a24",
                CallbackUri = "https://instasharpapi.azurewebsites.net/Realtime/Callback",
                ClientSecret = "39de8776637b47d2829cd1a4708ae180"
            };


            // dummy account data. InstaSharpTest
            Auth = new OAuthResponse()
            {
                AccessToken = "1415228826.554dfe9.502432355f084ea581b679a2f94bb350",
                User = new Models.UserInfo { Id = 1415228826 }
            };
        }
        protected static void AssertMissingClientSecretUrlParameter(Response result)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Meta.Code);
            Assert.AreEqual("Missing client_secret URL parameter.", result.Meta.ErrorMessage);
            Assert.AreEqual("OAuthClientException", result.Meta.ErrorType);
        }
    }
}
