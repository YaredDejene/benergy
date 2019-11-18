using System;

namespace Benergy.Core.Common
{
    public class SiteSettings
    {
        public static string ConnectionString { get; set; }

        public static string WebPath { get; set; }

        public static string EnvironmentName { get; set; }

        public static string SendGridApiKey {get;set;}

        public static bool IsEnvironment(string environmentName)
        {
            return string.Equals(environmentName, EnvironmentName, StringComparison.OrdinalIgnoreCase);
        }
    }
}