using System;
using System.Reflection;
using TinyInstaller.Interfaces;

namespace TinyInstaller.Helpers
{
    internal class AppConstants : IConstantsValues
    {
        private const string configFile = "PackagesConfig.json";

        public string AppName => Assembly.GetExecutingAssembly().GetName().Name;
        public string AppVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public string ConfigFile => configFile;
    }
}