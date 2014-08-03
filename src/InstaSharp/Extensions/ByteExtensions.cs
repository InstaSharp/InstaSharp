using System;

namespace InstaSharp.Extensions
{
    internal static class ByteExtensions
    {
        internal static string ByteArrayToString(this byte[] ba)
        {
            var hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
}
