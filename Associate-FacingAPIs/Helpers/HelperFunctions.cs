using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Associate_FacingAPIs.Helpers
{
    public static class HelperFunctions
    {
        public enum contacttype
        {
            [Display(Name = "Active Member")]
            Active,
            National,
            Internal
        }
        public static string AsJsonList<T>(List<T> tt)
        {
            return JsonConvert.SerializeObject(tt);
        }
        public static string AsJson<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }
        public static List<T> AsObjectList<T>(string tt)
        {
            return JsonConvert.DeserializeObject<List<T>>(tt);
        }
        public static T AsObject<T>(string t)
        {
            return JsonConvert.DeserializeObject<T>(t);
        }
        public static string GetAttribute<TAttribute>(this Enum enumValue)
             where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>().GetName();
           
        }
    }
}
