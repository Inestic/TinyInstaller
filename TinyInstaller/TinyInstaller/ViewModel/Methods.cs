using System;
using System.IO;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private bool CreateConfigurationFileCommandAsync_CanExecute(object obj) => !File.Exists(Path.Combine(AppHelper.BaseDirectory, AppHelper.ConfigFile));

        private void CreateConfigurationFileCommandAsync_Execute(object obj)
        {
            throw new NotImplementedException();
        }

        private void HyperlinkClickedCommand_Execute(string url) => ProcessHelper.Start("explorer", url);

        private void InitializeCommands()
        {
            WindowCloseCommand = new RelayCommand(WindowCloseCommand_Execute, WindowCloseCommand_CanExecute);
            WindowMinimizeCommand = new RelayCommand(WindowMinimizeCommand_Execute);
            HyperlinkClickedCommand = new RelayCommand<string>(HyperlinkClickedCommand_Execute);
            CreateConfigurationFileCommand = new RelayCommand(CreateConfigurationFileCommandAsync_Execute, CreateConfigurationFileCommandAsync_CanExecute);
        }

        private void InitializeProperties(MainWindow mainWindow)
        {
            ActivePage = Page.LoadingView;
            MainWindow = mainWindow;
            StartupTestsHelper = new StartupTestsHelper();
            Window_CanClose = true;
        }

        private async void StartupTestsInvokeAsync()
        {
            await Task.Run(() =>
            {
                ActivePage = StartupTestsHelper.Run();
            });
        }

        private bool WindowCloseCommand_CanExecute(object obj) => Window_CanClose;

        private void WindowCloseCommand_Execute(object obj) => MainWindow.Close();

        private void WindowMinimizeCommand_Execute(object obj) => MainWindow.WindowState = System.Windows.WindowState.Minimized;
    }
}