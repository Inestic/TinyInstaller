using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;
using TinyInstaller.Poco;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private void InitializeCommands()
        {
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
            HyperLinkClickedCommand = new RelayCommand<string>(Command_HyperLinkClicked_Execute);
        }

        public void Initialize()
        {
            InitializeCommands();
            InitializeEvents();
            Task.Run(async () => await InitializeModelAsync());
        }

        private async Task InitializeModelAsync()
        {
            Model = await ConfigParser.ParseAsync(ModelsBuilder, AppConstants.ConfigFile, AppConstants.PackagesFolder);
        }

        private void InitializeEvents()
        {
            ConfigParser.IsSuccessfulParsed += ConfigSuccessfulParsed;
            ConfigParser.IsAutoInstall += ConfigIsAutoInstallMode;
        }

        private void ConfigIsAutoInstallMode(object sender, IEnumerable<Package> packages)
        {
            MainWindow_CanClose = false;
            Packages = packages.Where(package => package.AutoInstall);
        }

        private void ConfigSuccessfulParsed(object sender, IEnumerable<Package> packages)
        {
            Packages = packages;
        }
    }
}