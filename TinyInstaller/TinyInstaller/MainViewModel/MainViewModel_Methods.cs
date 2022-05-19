using TinyInstaller.Common;

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

        public async void Initialize()
        {
            InitializeCommands();
            ViewModel = await ConfigParser.ParseAsync(ViewsModelsBuilder, AppConstants.ConfigFile, AppConstants.PackagesFolder);
        }
    }
}