using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace nmvm.Utilities
{
    ///<summary>
    ///This class provides upsert methods to update an base object by using the values brought by the override object
    ///</summary>
    public static class ObjectMerger
    {
        ///<summary>
        /// Merge object property values.
        /// The baseObject and the overrideObject can be of different type 
        /// <param name="baseObject">The object with the base value set that awaits changes</param>
        /// <param name="overrideObject">The object with the change value set that awaits merge</param>
        ///</summary>
        public static T UpsertDynamic<T>(T baseObject, dynamic overrideObject) where T : new()
        {
            // get type of baseObject
            var t = typeof(T);

            // get baseObject model properties
            var publicProperties = t.GetProperties();

            // declare output object
            var output = new T();

            // serialize overrideObject 
            var dynamicOverrideObject =  JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(overrideObject.ToString());

            // obtains a list of property names from the dynamic object
            List<string> dynamicOverrideObjectKeys = new List<string>();
            foreach (var key in dynamicOverrideObject.Keys)
            {
                dynamicOverrideObjectKeys.Add(key);
            }

            // upsert only when property name match found between the overrideObject and the baseObject
            foreach (var propInfo in publicProperties)
            {
                var basePropertyName = propInfo.Name;
                var basePropertyValue = propInfo.GetValue(baseObject);

                // check if match found
                if (HasProperty(dynamicOverrideObjectKeys, basePropertyName.ToLowerFirstChar()))
                {
                    // get overrideVluae
                    var overrideValue = dynamicOverrideObject[basePropertyName.ToLowerFirstChar()];
                    // when overrideValue is not null, check the type of the value, and convert long to int
                    if (overrideValue != null)
                    {
                        var typeOfOverrideValue = dynamicOverrideObject[basePropertyName.ToLowerFirstChar()].GetType();
                        if (typeOfOverrideValue.Name == "Int64")
                        {
                            overrideValue = Convert.ToInt32(overrideValue);
                        }
                    }

                    // set output property value
                    propInfo.SetValue(output, overrideValue);
                }
                else if(basePropertyName == "ModifiedDateTime")
                {
                    // set ModifiedDateTime property value
                    propInfo.SetValue(output, DateTime.Now);
                }
                else {
                    // use existing baseObject property value for output when match is not found
                    propInfo.SetValue(output, basePropertyValue);
                }
            }
            return output;
        }

        private static bool HasProperty(List<string> keys, string propertyName)
        {
            var match = keys.FirstOrDefault(stringToCheck => stringToCheck.Contains(propertyName));
            if (match != null)
            {
                return true;
            }
            else {
                return false;
            }

        }
        /// <summary>
        /// Convert the first letter of a string to lower case
        /// </summary>
        /// <param name="input">the string value to be converted</param>
        /// <returns></returns>
        public static string ToLowerFirstChar(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToLower(input[0]) + input.Substring(1);
        }
    }
}