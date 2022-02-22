using System.IO;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;

namespace TinyInstaller.StartupTests
{
    internal class ConfigFileExist : IStartupTest
    {
        internal ConfigFileExist(string appDir, string configFile)
        {
            _appDir = appDir;
            _configFile = configFile;
        }

        private string _appDir { get; set; }
        private string _configFile { get; set; }

        public Page PageTag { get; set; } = Page.ConfigFileNotFoundTest;

        public void Run()
        {
            if (!File.Exists(Path.Combine(_appDir, _configFile)))
            {
                throw new StartupTestException(PageTag);
            }
        }
    }
}