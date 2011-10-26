using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstaSharp.Model.Responses;

namespace InstaSharp.Endpoints.Relationships {
    public class Unauthenticated : InstagramAPI {

        public Unauthenticated(InstagramConfig config) : base(config, "/users/") {

        }

        public UsersResponse Follows(int userId) {
            string uri = string.Format(base.Uri + "{0}/follows?client_id={1}", userId, InstagramConfig.ClientId);
            return (UsersResponse)Mapper.Map<UsersResponse>(FollowsJson(userId));
        }

        public string FollowsJson(int userId) {
            string uri = string.Format(base.Uri + "{0}/follows?client_id={1}", userId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }

        public UsersResponse FollowedBy(int userId) {
            return (UsersResponse)Mapper.Map<UsersResponse>(FollowedByJson(userId));
        }

        public string FollowedByJson(int userId) {
            string uri = string.Format(base.Uri + "{0}/followed-by?client_id={1}", userId, InstagramConfig.ClientId);
            return HttpClient.GET(uri);
        }


    }
}
