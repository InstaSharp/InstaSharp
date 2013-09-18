#if DEBUG

using InstaSharp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaSharp.Tests
{
    public class TestBase
    {
        public readonly OAuthResponse auth = new OAuthResponse();
        public readonly InstagramConfig config = new InstagramConfig();

        public TestBase()
        {
            // test account client id
            config.ClientId = "4e0171f9fcfc4015bb6300ed91fbf719";

            // dummy account data.  Kevin S no doubt.
            auth.Access_Token = "2849381.f59def8.1e89d635370f475d94e7512faa6fb9e0";
            auth.User = new Models.UserInfo();
            auth.User.Id = 22987123;
            auth.User.Username = "kevin";
        }
    }
}

#endif
