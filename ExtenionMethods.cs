using System;

namespace InstaSharp {
    public static class ExtensionMethods  {

        public static double ToUnixTimestamp(this DateTime dateTime) {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }
    
    }
}
