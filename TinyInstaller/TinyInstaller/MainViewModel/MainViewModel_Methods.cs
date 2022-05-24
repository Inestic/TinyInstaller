using System.Collections.Generic;
using System.Linq;
using TinyInstaller.Common;
using TinyInstaller.Poco;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private void ConfigIsAutoInstallMode(object sender, IEnumerable<Package> packages)
        {
            MainWindow_CanClose = false;
            Packages = packages.Where(package => package.AutoInstall);
        }

        private void ConfigSuccessfulParsed(object sender, IEnumerable<Package> packages)
        {
            Packages = packages;
        }

        private void InitializeCommands()
        {
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
            HyperLinkClickedCommand = new RelayCommand<string>(Command_HyperLinkClicked_Execute);
            CreateConfigCommand = new RelayCommand(Command_CreateConfig_Execute);
        }

        private void InitializeEvents()
        {
            ConfigParser.IsSuccessfulParsed += ConfigSuccessfulParsed;
            ConfigParser.IsAutoInstall += ConfigIsAutoInstallMode;
        }

        private void SetModelFromConfig()
        {
            Model = ConfigParser.Parse(ModelsBuilder, AppConstants.ConfigFile, AppConstants.PackagesFolder);
        }

        public void Initialize()
        {
            InitializeCommands();
            InitializeEvents();
            SetModelFromConfig();
        }
    }
}