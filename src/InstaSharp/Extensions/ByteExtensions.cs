using System;

namespace InstaSharp.Extensions
{
    public static class ByteExtensions
    {
        public static string ByteArrayToString(this byte[] ba)
        {
            var hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
}
