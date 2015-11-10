using Newtonsoft.Json.Linq;
using System;

namespace onfleet.Infrastructure
{
    public static class ExpandableProperty<T> where T : ofObject
    {
        public static void Map(object value, Action<string> updateId, Action<T> updateObject)
        {
            if (value is JObject)
            {
                T item = ((JToken)value).ToObject<T>();
                updateId(item.Id);
                updateObject(item);
            }
            else if (value is string)
            {
                updateId((string)value);
                updateObject(null);
            }
        }
    }
}
