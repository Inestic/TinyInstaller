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
              ""Title"": ""7-Zip"",
              ""Description"": ""7-Zip is a free and open-source file archiver"",
              ""ExecutableFile"": ""7 Zip\\7z2107-x64.msi"",
              ""ExecutableArgs"": ""/qb"",
              ""ExitCode"": 0,
              ""Version"": ""21.07""
          },
          {
              ""AutoInstall"": false,
              ""Title"": ""Brave Browser Dev"",
              ""Description"": ""Secure, fast, private web browser with Adblocker"",
              ""ExecutableFile"": ""Brave Browser\\BraveBrowserStandaloneSilentDevSetup.exe"",
              ""ExecutableArgs"": """",
              ""ExitCode"": 0,
              ""Version"": ""1.40.81""
          },
          {
              ""AutoInstall"": false,
              ""Title"": ""VLC Media Player"",
              ""Description"": ""VLC is a free and open source cross-platform multimedia player"",
              ""ExecutableFile"": ""VLC\\vlc-3.0.17.4-win64.exe"",
              ""ExecutableArgs"": ""/S"",
              ""ExitCode"": 0,
              ""Version"": ""3.0""
          }
        ]
      }";

        private readonly Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;
        private readonly string appName = Assembly.GetExecutingAssembly().GetName().Name;
        private const string packagesFolder = "Packages";
        private const string configFile = "PackagesConfig.json";

        public string AppName => appName;
        public string AppVersion => $"{appVersion.Major}.{appVersion.Minor}.{appVersion.Build}";
        public byte AutoInstallCountdown => 30;
        public string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
        public string ConfigExample => configExample;
        public string ConfigFile => configFile;
        public string PackagesFolder => packagesFolder;
    }
}