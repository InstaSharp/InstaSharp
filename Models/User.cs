using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Models {

    public class User {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public Count Counts { get; set; }
    }
}
