using System;
using System.Reflection;

namespace TinyInstaller.Helpers
{
    internal class AppConstants
    {
        private const string configFile = "PackagesConfig.json";
        private const string packagesFolder = "Packages";
        public string AppName => Assembly.GetExecutingAssembly().GetName().Name;
        public string AppVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public string ConfigFile => configFile;
        public string PackagesFolder => packagesFolder;
    }
}