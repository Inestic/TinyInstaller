using System.Collections.Generic;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;
using TinyInstaller.StartupTests;

namespace TinyInstaller.Helpers
{
    internal class StartupTestsHelper
    {
        private List<IStartupTest> startupTests = new List<IStartupTest>()
        {
            new ConfigFileExist(appDir: AppHelper.BaseDirectory, configFile: AppHelper.ConfigFile)
        };

        internal Page Run()
        {
            try
            {
                startupTests.ForEach(test => test.Run());
                return Page.ReadyToInstallView;
            }
            catch (StartupTestException e)
            {
                return e.PageTag;
            }
        }
    }
}