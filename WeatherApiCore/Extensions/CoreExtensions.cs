using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApiCore.Extensions
{
    public static class CoreExtensions
    {
        public static bool IsGuidEmpty(this Guid me)
        {
            return me.Equals(default);
        }
        public static void ThrowOnEmpty(this Guid me, string attribName)
        {
            if (me.IsGuidEmpty())
            {
                throw new ArgumentNullException("Attribute may not be empty.", attribName);
            }
        }
        public static T CloneBySerialization<T>(this T source)
        {
            //REFERENCE : http://stackoverflow.com/questions/78536/deep-cloning-objects

            var serialized = JsonConvert.SerializeObject(source);
            var ret = JsonConvert.DeserializeObject<T>(serialized);
            return ret;
        }
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}
