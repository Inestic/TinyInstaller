using System.IO;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Helpers;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private bool Command_CreateConfigurationFile_CanExecute(object obj) => !File.Exists(Path.Combine(AppHelper.BaseDirectory, AppHelper.ConfigFile));

        private async void Command_CreateConfigurationFile_ExecuteAsync(object obj)
        { }

        private async void Command_HyperlinkClicked_ExecuteAsync(string url) => await Task.Run(() => ProcessHelper.Start("explorer", url));

        private bool Command_WindowClose_CanExecute(object obj) => Window_CanClose;

        private void Command_WindowClose_Execute(object obj) => MainWindow.Close();

        private void Command_WindowMinimize_Execute(object obj) => MainWindow.WindowState = System.Windows.WindowState.Minimized;

        private void InitializeCommands()
        {
            CreateConfigurationFileCommand = new RelayCommand(Command_CreateConfigurationFile_ExecuteAsync, Command_CreateConfigurationFile_CanExecute);
            HyperlinkClickedCommand = new RelayCommand<string>(Command_HyperlinkClicked_ExecuteAsync);
            WindowCloseCommand = new RelayCommand(Command_WindowClose_Execute, Command_WindowClose_CanExecute);
            WindowMinimizeCommand = new RelayCommand(Command_WindowMinimize_Execute);
        }

        private void InitializeProperties(MainWindow mainWindow, IVoidInvoked localizationHelper, IInvoked<Page> testsHelper)
        {
            MainWindow = mainWindow;
            LocalizationHelper = localizationHelper;
            StartupTestsHelper = testsHelper;
        }

        private async Task PropertiesInvokeAsync()
        {
            await Task.Run(() =>
            {
                LocalizationHelper.Invoke();
                ActivePage = StartupTestsHelper.Invoke();
            });
        }
    }
}