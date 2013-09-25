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
            Config.ClientId = "4e0171f9fcfc4015bb6300ed91fbf719";

            // dummy account data.  Kevin S no doubt.
            Auth.Access_Token = "2849381.f59def8.1e89d635370f475d94e7512faa6fb9e0";
            Auth.User = new Models.UserInfo();
            Auth.User.Id = 22987123;
            Auth.User.Username = "kevin";
        }
    }
}
