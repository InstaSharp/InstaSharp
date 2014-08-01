using System;

namespace InstaSharp.Extensions
{
    internal static class Int64Extensions
    {
        public static DateTime ToDateTimeFromUnix(this long unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);

            return dtDateTime;
        }
    }
}
