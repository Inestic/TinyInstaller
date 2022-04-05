using System.IO;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        public RelayCommand CreateConfigurationFileCommand { get; private set; }
        public RelayCommand<string> HyperlinkClickedCommand { get; private set; }
        public RelayCommand WindowCloseCommand { get; private set; }
        public RelayCommand WindowMinimizeCommand { get; private set; }

        private bool Command_CreateConfigurationFile_CanExecute(object obj) => !File.Exists(Path.Combine(AppHelper.BaseDirectory, AppHelper.ConfigFile));

        private async void Command_CreateConfigurationFile_ExecuteAsync(object obj)
        {
            await Task.Run(() =>
            {
                var configFilePath = Path.Combine(AppHelper.BaseDirectory, AppHelper.ConfigFile);
                File.WriteAllText(configFilePath, AppHelper.SampleConfig);
                ActivePage = StartupTestsHelper.Invoke();
            });
        }

        private async void Command_HyperlinkClicked_ExecuteAsync(string url) => await Task.Run(() => ProcessHelper.Start("explorer", url));

        private bool Command_WindowClose_CanExecute(object obj) => Window_CanClose;

        private void Command_WindowClose_Execute(object obj) => MainWindow.Close();

        private void Command_WindowMinimize_Execute(object obj) => MainWindow.WindowState = System.Windows.WindowState.Minimized;
    }
}