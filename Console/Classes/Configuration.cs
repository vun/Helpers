using System.Configuration;
using System.Linq;

namespace Console.Classes
{
    public class ConfigurationHelper
    {
        public static string GetAppSetting(string key)
        {
            return GetAppSetting(key, true);
        }

        public static string GetAppSetting(string key, bool required)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value) && required)
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(value))
            {
                value = ConfigurationManager.AppSettings.AllKeys.Aggregate(value, (current, k) => current.Replace("{" + k + "}", ConfigurationManager.AppSettings[k]));
            }

            return value;
        }
    }
}
