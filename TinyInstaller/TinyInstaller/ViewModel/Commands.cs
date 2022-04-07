using System.Windows;
using TinyInstaller.Common;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        public RelayCommand MainWindowCloseCommand { get; private set; }
        public RelayCommand MainWindowMinimizeCommand { get; private set; }
        public RelayCommand MainWindowMinMaxCommand { get; private set; }

        private bool Command_MainWindowClose_CanExecute(object args) => MainWindow_CanClose;

        private void Command_MainWindowClose_Execute(object args) => MainWindow.Close();

        private void Command_MainWindowMinimize_Execute(object args) => MainWindow.WindowState = WindowState.Minimized;

        private void Command_MainWindowMinMaxCommand_Execute(object args)
        {
            var state = MainWindow.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            MainWindow.WindowState = state;
        }
    }
}