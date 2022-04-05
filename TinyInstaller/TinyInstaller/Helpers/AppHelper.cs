using System;
using System.Reflection;

namespace TinyInstaller.Helpers
{
    internal class AppHelper
    {
        internal static readonly string configFile = "PackagesConfig.json";

        internal static readonly string SampleConfig = @"{
  ""Packages"": [
    {
      ""Name"": ""Sample App1"",
      ""Description"": ""This is description for Sample App1"",
      ""File"": ""MyApp1\\setup.exe"",
      ""Args"": """"
    },
    {
      ""Name"": ""Sample App2"",
      ""Description"": ""This is description for Sample App2"",
      ""File"": ""MyApp2\\install.exe"",
      ""Args"": ""/silent""
    },
    {
      ""Name"": ""Sample App3"",
      ""Description"": ""This is description for Sample App3"",
      ""File"": ""MyApp1\\setup.msi"",
      ""Args"": ""/quiet /norestart""
    }
  ]
}";

        internal static string BaseDirectory { get; } = AppDomain.CurrentDomain.BaseDirectory;
        internal static string ConfigFile { get => configFile; }
        public static string Name { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public static string VersionString { get; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}