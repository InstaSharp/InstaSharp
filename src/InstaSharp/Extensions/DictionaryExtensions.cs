using System.Collections.Generic;

namespace InstaSharp.Extensions
{
    public static class DictionaryExtensions
    {
        public static void CreateNewOrUpdateExisting<TKey, TValue>(this IDictionary<TKey, TValue> map, TKey key, TValue value)
        {
            if (map.ContainsKey(key))
            {
                map[key] = value;
            }
            else
            {
                map.Add(key, value);
            }
        }
    }
}
