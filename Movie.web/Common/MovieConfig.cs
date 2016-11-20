using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Movie.web.Common
{
    public static class MovieConfig
    {
        public static string WebAPIUrl
        {
            get
            {
                return GetWebConfigValue(WebConfigKey.MovieWebApi);
            }
        }

        public static string RequesetHeader1Key
        {
            get
            {
                return GetWebConfigValue(WebConfigKey.RequestHeader1Key);
            }
        }

        public static string RequestHeader1Value
        {
            get
            {
                return GetWebConfigValue(WebConfigKey.RequestHeader1Value);
            }
        }

        public static int CacheExpirationMinute
        {
            get
            {
                var val = GetWebConfigValue(WebConfigKey.CacheExpirationMinute);
                if (val != null)
                {
                    int min;
                    if (int.TryParse(val.ToString(), out min))
                    {
                        return min;
                    }
                }
                return 5;
            }
        }

        private static string GetWebConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }



    }

    public static class WebConfigKey
    {
        public static readonly string MovieWebApi = "MovieWebAPIUrl";
        public static readonly string RequestHeader1Key = "RequestHeader1Key";
        public static readonly string RequestHeader1Value = "RequestHeader1Value";
        public static readonly string CacheExpirationMinute = "CacheExpirationMinute";
    }
}