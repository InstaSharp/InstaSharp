using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Diagnostics;

namespace InstaSharp {
    class Mapper {
        public static object Map<T>(string json) where T : new() {

            //var t = new T();
            var j = JObject.Parse(json);
            var t = typeof(T);

            try {
                var instance = Map(t, j);
                
                // add the pure json back
                if (instance != null) {
                    var prop = instance.GetType().GetProperty("Json");
                    if (prop != null) {
                        prop.SetValue(instance, json, null);
                    }
                }

                return instance;
            
            } 
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private static object Map(Type t, JObject json) {

                var instance = Activator.CreateInstance(t);

                Array.ForEach(instance.GetType().GetProperties(), prop => {

                    var attribute = prop.GetCustomAttributes(typeof(Models.JsonMapping), false);

                    if (attribute.Length > 0) {
                        var propertyType = prop.PropertyType;
                        var mapsTo = ((Models.JsonMapping)attribute[0]).MapsTo;
                        var mappingType = ((Models.JsonMapping)attribute[0]).MapType;

                        switch (mappingType) {
                            case Models.JsonMapping.MappingType.Class:
                                if (json[mapsTo] != null) {
                                    if (json[mapsTo].HasValues) {
                                        var obj = Map(propertyType, (JObject)json[mapsTo]);
                                        prop.SetValue(instance, obj, null);
                                    }
                                }
                                break;
                            case Models.JsonMapping.MappingType.Collection:
                                var col = Map(propertyType, (JArray)json[mapsTo]);
                                prop.SetValue(instance, col, null);
                                break;
                            default:
                                if (json != null) {
                                    if (json[mapsTo] != null) {
                                        // special case for datetime because it comes in Unix format
                                        if (prop.PropertyType == typeof(DateTime))
                                            prop.SetValue(instance, json[mapsTo].ToString().ToDateTimeFromUnix(), null);
                                        else
                                            prop.SetValue(instance, Convert.ChangeType(json[mapsTo].ToString(), prop.PropertyType), null);
                                    }
                                }
                                break;
                        }
                    }
                });

                return instance;
        }

        private static IList Map(Type t, JArray json) {
            var type = t.GetGenericArguments()[0];
            // This will produce List<Image> or whatever the original element type is
            var listType = typeof(List<>).MakeGenericType(type);
            var result = (IList)Activator.CreateInstance(listType);

            if (json != null) {
                foreach (var j in json)
                    if (type.Name == "String" || type.Name == "Int32")
                        result.Add(j.ToString());
                    else result.Add(Map(type, (JObject)j));
            }

            return result;
        }

        private static void SetPropertyValue(PropertyInfo prop, object instance, object value) {
            prop.SetValue(instance, Convert.ChangeType(value, prop.PropertyType), null);
        }
    }
}
