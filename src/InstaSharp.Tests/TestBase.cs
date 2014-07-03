using InstaSharp.Models.Responses;

namespace InstaSharp.Tests
{
    public class TestBase
    {
        protected readonly OAuthResponse Auth = new OAuthResponse();
        protected readonly InstagramConfig Config = new InstagramConfig();

        public TestBase()
        {
            // test account client id
            Config.ClientId = "554dfe9286994bbe98417d8dc7b69a24";

            // dummy account data. InstaSharpTest
            Auth.Access_Token = "1415228826.554dfe9.502432355f084ea581b679a2f94bb350";
            Auth.User = new Models.UserInfo();
            Auth.User.Id = 1415228826;
        }
    }
}
