using TinyInstaller.Common;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private void InitializeCommands()
        {
            WindowCloseCommand = new RelayCommand(WindowCloseCommand_Execute, WindowCloseCommand_CanExecute);
        }

        private void InitializeProperties(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            Window_CanClose = true;
        }

        private bool WindowCloseCommand_CanExecute(object obj) => Window_CanClose;

        private void WindowCloseCommand_Execute(object obj) => MainWindow.Close();
    }
}