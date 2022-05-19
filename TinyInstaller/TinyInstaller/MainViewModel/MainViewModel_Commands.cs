using System.Windows;
using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private void Command_HyperLinkClicked_Execute(string arg) => ProcessHelper.Run("explorer", arg);

        private bool Command_MainWindowClose_CanExecute(object arg) => MainWindow_CanClose;

        private void Command_MainWindowClose_Execute(object arg) => MainWindow.Close();

        private void Command_MainWindowMinimize_Execute(object arg) => MainWindow.WindowState = WindowState.Minimized;

        private void Command_MainWindowMinMaxCommand_Execute(object arg)
        {
            var state = MainWindow.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            MainWindow.WindowState = state;
        }
    }
}