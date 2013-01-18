using System;

namespace InstaSharp {
    public static class ExtensionMethods  {

        public static double ToUnixTimestamp(this DateTime dateTime) {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        public static DateTime ToDateTimeFromUnix(this String unixTimeStamp) {
            // Unix timestamp is seconds past epoch
            double unixTime = Convert.ToDouble(unixTimeStamp);
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTime).ToLocalTime();
            return dtDateTime;
        }
    }
}
