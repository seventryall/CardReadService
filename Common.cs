using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardReaderService
{
    public static class Common
    {
        public static string ToJSON(this object oo)
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();

            var iso = new IsoDateTimeConverter();
            iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            setting.Converters = new List<JsonConverter> { new StringEnumConverter(), iso };
            setting.Formatting = Formatting.Indented;
            setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // setting.en
            return JsonConvert.SerializeObject(oo, setting);
        }

        public static T  ParseJson<T>(this string s){
           return  JsonConvert.DeserializeObject<T>(s);
        }


    }
}