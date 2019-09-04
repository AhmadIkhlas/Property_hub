using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS362.PropertyHub.WebUI
{
    public static class WebUtil
    {
        public const int ADMIN = 1;
        public const string CURRENT_USER = "CurrentUser";


        public static void Set<T>(this ISession session, string key, T obj)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            session.SetString(key, jsonData);
        }

        public static T Get<T>(this ISession session, string key)
        {
            string jsonData = session.GetString(key);
            if (jsonData != null) return JsonConvert.DeserializeObject<T>(jsonData);
            return default(T);
        }

    }
}
