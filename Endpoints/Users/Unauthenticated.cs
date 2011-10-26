using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Users {
    public class Unauthenticated : InstagramAPI {
        
        public Unauthenticated (InstagramConfig config) : base(config, "/users/")  { }

        public UserResponse Get(int userId) {
            return (UserResponse)Mapper.Map<UserResponse>(GetJson(userId));
        }

        public string GetJson(int userId) {
            string uri = string.Format(base.Uri + "{0}/?client_id={1}", userId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public UsersResponse Search(string searchTerm, int? count) {
            return (UsersResponse)Mapper.Map<UsersResponse>(SearchJson(searchTerm, count));
        }

        public string SearchJson(string searchTerm, int? count) {
            string uri = string.Format(base.Uri + "/search?q={0}&client_id={1}", searchTerm, InstagramConfig.ClientId);
            
            if (count != null) uri += "&count=" + count;

            return HttpClient.GET(uri);
        }
    }
}
