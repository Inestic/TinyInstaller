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

        private AppConstants AppConstants { get; set; } = new AppConstants();
        private MainWindow MainWindow { get; set; }
        private IViewsModelsBuilder ViewsModelsBuilder { get; set; } = new ViewsModelsBuilder();
        public IConfigParser ConfigParser { get; set; } = new ConfigParser();

        internal IViewModel Build()
        {
            var vm = new MainViewModel(MainWindow, AppConstants, ViewsModelsBuilder, ConfigParser);
            vm.Initialize();
            return vm;
        }

        internal MainViewModelBuilder SetLocalization()
        {
            var localizator = new LocalizationsBuilder();
            localizator.Set();
            return this;
        }
    }
}