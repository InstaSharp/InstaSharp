using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaSharp.Extensions
{
    public static class StringExtensions
    {
        public static string UrlEncode(this string input)
        {
            return Uri.EscapeDataString(input);
        }
    }
}
