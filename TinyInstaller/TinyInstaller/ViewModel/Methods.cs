using System.Threading.Tasks;
using TinyInstaller.Common;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private void InitializeCommands()
        {
            CreateConfigurationFileCommand = new RelayCommand(Command_CreateConfigurationFile_ExecuteAsync, Command_CreateConfigurationFile_CanExecute);
            HyperlinkClickedCommand = new RelayCommand<string>(Command_HyperlinkClicked_ExecuteAsync);
            WindowCloseCommand = new RelayCommand(Command_WindowClose_Execute, Command_WindowClose_CanExecute);
            WindowMinimizeCommand = new RelayCommand(Command_WindowMinimize_Execute);
        }

        private async Task PropertiesInvokeAsync()
        {
            await Task.Run(() =>
            {
                LocalizationHelper.Invoke();
                ActivePage = StartupTestsHelper.Invoke();
            });
        }

        internal void Initialize()
        {
            InitializeCommands();
            _ = PropertiesInvokeAsync();
        }
    }
}