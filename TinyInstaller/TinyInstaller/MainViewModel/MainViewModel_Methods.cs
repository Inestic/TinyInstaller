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
            CreateConfigCommand = new RelayCommand(Command_CreateConfig_Execute);
            HyperLinkClickedCommand = new RelayCommand<string>(Command_HyperLinkClicked_Execute);
            InstallPackagesCommand = new RelayCommand(Command_InstallPackages_Execute);
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
            SwitchClickedCommand = new RelayCommand<Package>(Command_SwitchClickedCommand_Execute);
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