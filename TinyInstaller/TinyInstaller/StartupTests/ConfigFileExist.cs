using System.IO;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;

namespace TinyInstaller.StartupTests
{
    internal class ConfigFileExist : IStartupTest
    {
        private string _appDir;

        private string _configFile;

        internal ConfigFileExist(string appDir, string configFile)
        {
            _appDir = appDir;
            _configFile = configFile;
        }

        public Page PageTag { get; set; } = Page.ConfigFileNotFoundView;

        public void Run()
        {
            if (!File.Exists(Path.Combine(_appDir, _configFile)))
            {
                throw new StartupTestException(PageTag);
            }
        }
    }
}