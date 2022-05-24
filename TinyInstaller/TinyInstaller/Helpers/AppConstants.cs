using System;
using System.Reflection;

namespace TinyInstaller.Helpers
{
    internal class AppConstants
    {
        private const string configExample = @"{
  ""Packages"": [
    {
      ""AutoInstall"": false,
      ""Title"": ""7 Zip"",
      ""Description"": ""7-Zip is a free and open-source file archiver"",
      ""ExecutableFile"": ""7 Zip\\7z2107-x64.msi"",
      ""ExecutableArgs"": ""/qn /norestart /g 1033"",
      ""ExitCode"": 0,
      ""Version"": ""21.07""
    },
	{
      ""AutoInstall"": false,
      ""Title"": ""Brave Browser"",
      ""Description"": ""Secure, fast, private web browser with Adblocker"",
      ""ExecutableFile"": ""Brave Browser\\BraveBrowserSetup.exe"",
      ""ExecutableArgs"": ""--install --silent"",
      ""ExitCode"": 0,
      ""Version"": ""1.3""
    },
    {
      ""AutoInstall"": false,
      ""Title"": ""VLC Media Player"",
      ""Description"": ""VLC is a free and open source cross-platform multimedia player"",
      ""ExecutableFile"": ""VLC\\vlc-3.0.17.4-win64.exe"",
      ""ExecutableArgs"": ""/L=1033 /S"",
      ""ExitCode"": 0,
      ""Version"": ""3.0""
    }
  ]
}";

        private const string configFile = "PackagesConfig.json";
        private const string packagesFolder = "Packages";

        public string AppName => Assembly.GetExecutingAssembly().GetName().Name;
        public string AppVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public string ConfigExample => configExample;
        public string ConfigFile => configFile;
        public string PackagesFolder => packagesFolder;
    }
}