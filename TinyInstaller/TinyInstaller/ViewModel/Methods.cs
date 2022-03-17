using System;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        //TODO: Check the error description links in the "Links.xaml" file.

        private void HyperlinkClickedCommand_Execute(string url) => ProcessHelper.Start("explorer", url);

        private void InitializeCommands()
        {
            WindowCloseCommand = new RelayCommand(WindowCloseCommand_Execute, WindowCloseCommand_CanExecute);
            WindowMinimizeCommand = new RelayCommand(WindowMinimizeCommand_Execute);
            HyperlinkClickedCommand = new RelayCommand<string>(HyperlinkClickedCommand_Execute);
        }

        private void InitializeProperties(MainWindow mainWindow)
        {
            ActivePage = Page.LoadingView;
            MainWindow = mainWindow;
            Window_CanClose = true;
        }

        private async void StartupTestsInvokeAsync()
        {
            await Task.Run(() =>
            {
                var startupTestsHelper = new StartupTestsHelper();
                ActivePage = startupTestsHelper.Run();
            });
        }

        private bool WindowCloseCommand_CanExecute(object obj) => Window_CanClose;

        private void WindowCloseCommand_Execute(object obj) => MainWindow.Close();

        private void WindowMinimizeCommand_Execute(object obj) => MainWindow.WindowState = System.Windows.WindowState.Minimized;
    }
}