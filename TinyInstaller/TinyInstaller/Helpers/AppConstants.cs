using System;

namespace TinyInstaller.Helpers
{
    internal class AppConstants
    {
        private const string configFile = "PackagesConfig.json";

        public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public static string ConfigFile => configFile;
    }
}