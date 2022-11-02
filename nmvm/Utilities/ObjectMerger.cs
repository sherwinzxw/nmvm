using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nmvm.Utilities
{
    ///<summary>
    ///
    ///</summary>
    public static class ObjectMerger
    {      
        ///<summary>
        ///
        ///</summary>
        public static T Upsert<T>(T baseObject, T overrideObject) where T : new()
        {
            var t = typeof(T);
            var publicProperties = t.GetProperties();

            var output = new T();

            foreach (var propInfo in publicProperties)
            {
                var baseValue = propInfo.GetValue(baseObject);
                var overrideValue = propInfo.GetValue(overrideObject);
                var defaultValue = !propInfo.PropertyType.IsValueType ? null : Activator.CreateInstance(propInfo.PropertyType);

                switch (propInfo.PropertyType.Name) {
                    case "DateTime":
                        if (overrideValue != null)
                        {
                            if (DateTime.Equals(baseValue, overrideValue))
                            {
                                propInfo.SetValue(output, propInfo.GetValue(baseObject));
                            }
                            else if (!DateTime.Equals(baseValue, overrideValue) && DateTime.Equals(overrideValue, defaultValue))
                            {
                                propInfo.SetValue(output, propInfo.GetValue(baseObject));
                            }
                        }
                        else
                        {
                            propInfo.SetValue(output, propInfo.GetValue(baseObject));
                        }
                        break;
                    default:
                        if (overrideValue != null)
                        {
                            if (baseValue == overrideValue)
                            {
                                propInfo.SetValue(output, propInfo.GetValue(baseObject));
                            }
                            else if (baseValue != overrideValue && overrideValue != defaultValue)
                            {
                                propInfo.SetValue(output, propInfo.GetValue(overrideObject));
                            }
                        }
                        else
                        {
                            propInfo.SetValue(output, propInfo.GetValue(baseObject));
                        }
                        break;
                }
                
            }

            return output;
        }
    }
}