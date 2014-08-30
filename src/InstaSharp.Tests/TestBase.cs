using System.Net;
using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InstaSharp.Tests
{
    public class TestBase
    {
        protected readonly OAuthResponse Auth = new OAuthResponse();
        protected readonly InstagramConfig Config = new InstagramConfig();

        protected TestBase()
        {
            // test account client id
            Config.ClientId = "554dfe9286994bbe98417d8dc7b69a24";

            // dummy account data. InstaSharpTest
            Auth.AccessToken = "1415228826.554dfe9.502432355f084ea581b679a2f94bb350";
            Auth.User = new Models.UserInfo { Id = 1415228826 };
        }
        protected static void AssertMissingClientSecretUrlParameter(Response result)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Meta.Code);
            Assert.AreEqual("Missing client_secret URL parameter.", result.Meta.ErrorMessage);
            Assert.AreEqual("OAuthClientException", result.Meta.ErrorType);
        }
    }
}
