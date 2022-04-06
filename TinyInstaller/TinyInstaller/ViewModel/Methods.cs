using TinyInstaller.Common;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private void InitializeCommands()
        {
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
        }

        private void InitializeProperties()
        {
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
        }
    }
}