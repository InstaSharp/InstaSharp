using InstaSharp.Models.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace InstaSharp.Tests
{
    //InstaSharpTest - 1415228826
    //InstaSharpTest2 - 3015751092

    public class TestBase
    {
        protected readonly OAuthResponse Auth;
        protected readonly InstagramConfig Config;
        protected readonly InstagramConfig ConfigWithSecret;

        protected TestBase()
        {
            bool testingNewApiNov17 = false;

            if (testingNewApiNov17)
            {
                // test account client id
                Config = new InstagramConfig()
                {
                    ClientId = "fa50f43776ba4cfdaaaa375acc5ccab7"
                };

                ConfigWithSecret = new InstagramConfig()
                {
                    ClientId = "fa50f43776ba4cfdaaaa375acc5ccab7",
                    CallbackUri = "https://instasharpapi.azurewebsites.net/Realtime/Callback",
                    ClientSecret = "cd0d5d2f66f146c28cef06d4f4d2dc82"
                };


                // dummy account data. InstaSharpTest
                Auth = new OAuthResponse()
                {
                    AccessToken = "1415228826.fa50f43.1069f6ca1f734e2f930f70fdc7822885",
                    User = new Models.UserInfo { Id = 1415228826 }
                };
            }
            else {
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
        }
        protected static void AssertMissingClientSecretUrlParameter(Response result)
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, result.Meta.Code);
            Assert.AreEqual("Missing client_secret URL parameter.", result.Meta.ErrorMessage);
            Assert.AreEqual("OAuthClientException", result.Meta.ErrorType);
        }
    }
}
