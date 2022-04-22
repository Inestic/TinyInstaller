using System.Collections.Generic;
using TinyInstaller.Interfaces;
using TinyInstaller.ViewModel;

namespace TinyInstaller.Helpers
{
    internal class MainViewModelBuilder
    {
        public MainViewModelBuilder()
        {
        }

        public MainViewModelBuilder(MainWindow mainWindow) : this()
        {
            MainWindow = mainWindow;
        }

        private ILocalized Localizator { get; set; }
        private MainWindow MainWindow { get; set; }
        public IEnumerable<IStartupCondition> StartupConditions { get; private set; }

        internal MainViewModelBuilder AddLocalizations()
        {
            Localizator = new Localizator();
            return this;
        }

        internal MainViewModelBuilder AddStartupConditions()
        {
            StartupConditions = new List<IStartupCondition>();
            return this;
        }

        internal MainViewModel Build() => new MainViewModel(MainWindow, Localizator);
    }
}