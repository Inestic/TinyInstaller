using System;
using System.Reflection;

namespace TinyInstaller.Helpers
{
    internal class AppHelper
    {
        private static readonly string configFile = "PackagesConfig.json";
        internal static string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;
        internal static string ConfigFile { get => configFile; }
        public static string Name { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public static string VersionString { get; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}