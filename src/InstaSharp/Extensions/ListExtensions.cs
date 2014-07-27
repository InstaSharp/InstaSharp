using System.Collections.Generic;

namespace InstaSharp.Extensions
{
   public static  class ListExtensions
    {
       public static bool TrimLastAfterItem<T>(this List<T> data, T item) where T : class
       {
           if (item == null)
           {
               return false;
           }
           var indexOf = data.IndexOf(item);
           data.RemoveRange(indexOf, data.Count - indexOf);
           return true;
       }
    }
}
