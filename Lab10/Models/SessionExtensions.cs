using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab10.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string jsonString = session.GetString(key);
            if (string.IsNullOrEmpty(jsonString))
            {
                Debug.WriteLine("return default object");
                return default(T);
            }
            else
            {
                Debug.WriteLine("return deserialize object");
               
                return JsonConvert.DeserializeObject<T>(jsonString);
                
            }
        }
    }
}
