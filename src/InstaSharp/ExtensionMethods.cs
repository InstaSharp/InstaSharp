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


namespace System
{
    internal class SerializableAttribute : Attribute
    {
    }
}

namespace System.Runtime.InteropServices
{
    [AttributeUsageAttribute(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    internal class ComVisibleAttribute : Attribute
    {
        public ComVisibleAttribute(bool visible)
        {

        }
    }

    [AttributeUsageAttribute(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    internal sealed class GuidAttribute : Attribute
    {
        public GuidAttribute(string guid)
        {
            
        }
    }
}
