using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;

namespace FashionBoutik.Web.Utils
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var obj = JsonConvert.SerializeObject(value, typeof(T), null);
            session.SetString(key, obj);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static void SetDouble(this ISession session, string key, double value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static double? GetDouble(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToDouble(data, 0);
        }
    }

    public static class RedisCachExtensions
    {
        public static void SetObject(this IDistributedCache cach, string key, object value)
        {
            var obj = JsonConvert.SerializeObject(value, Formatting.Indented);
            cach.SetString(key, obj);
        }

        public static T GetObject<T>(this IDistributedCache cach, string key)
        {
            var value = cach.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        //public static void SetBoolean(this IDistributedCache cach, string key, bool value)
        //{
        //    cach.Set(cach, BitConverter.GetBytes(value));
        //}

        public static bool? GetBoolean(this IDistributedCache cach, string key)
        {
            var data = cach.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static void SetDouble(this IDistributedCache cach, string key, double value)
        {
            cach.Set(key, BitConverter.GetBytes(value));
        }

        public static double? GetDouble(this IDistributedCache cach, string key)
        {
            var data = cach.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToDouble(data, 0);
        }
    }
}
