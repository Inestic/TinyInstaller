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

        private MainWindow MainWindow { get; set; }
        public IConstantsValues AppConstants { get; private set; } = new AppConstants();

        internal MainViewModel Build()
        {
            var vm = new MainViewModel(MainWindow, AppConstants);
            vm.Initialize();
            return vm;
        }

        internal MainViewModelBuilder SetLocalization()
        {
            var localizator = new Localizator();
            localizator.SetLocalization();
            return this;
        }
    }
}