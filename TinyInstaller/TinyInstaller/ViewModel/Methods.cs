using System.Threading.Tasks;
using TinyInstaller.Common;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private void InitializeCommands()
        {
            WindowCloseCommand = new RelayCommand(WindowCloseCommand_Execute, WindowCloseCommand_CanExecute);
            WindowMinimizeCommand = new RelayCommand(WindowMinimizeCommand_Execute);
        }

        private async void InitializeDataAsync()
        {
            await Task.Run(() =>
            {
            });
        }

        private void InitializeProperties(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            Window_CanClose = true;
        }

        private bool WindowCloseCommand_CanExecute(object obj) => Window_CanClose;

        private void WindowCloseCommand_Execute(object obj) => MainWindow.Close();

        private void WindowMinimizeCommand_Execute(object obj) => MainWindow.WindowState = System.Windows.WindowState.Minimized;
    }
}