using System.Collections.Generic;
using TinyInstaller.Interfaces;
using TinyInstaller.ViewModel;

namespace TinyInstaller.Helpers
{
    internal class CompositionRootHelper
    {
        private static readonly ILocalizationHelper localizationHelper = new LocalizationHelper();
        private static readonly List<IStartupCondition> startupConditions = new();

        internal static VM CreateVM(MainWindow mainWindow) => new(mainWindow, localizationHelper, startupConditions);
    }
}