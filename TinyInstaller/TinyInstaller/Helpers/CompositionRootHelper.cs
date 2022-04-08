using TinyInstaller.ViewModel;

namespace TinyInstaller.Helpers
{
    internal class CompositionRootHelper
    {
        internal static VM CreateVM(MainWindow mainWindow)
        {
            var localizationHelper = new LocalizationHelper();
            var conditionsHelper = new StartupConditionsHelper();

            return new VM(mainWindow, localizationHelper, conditionsHelper);
        }
    }
}