using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Poco;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private void InitializeCommands()
        {
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
            HyperLinkClickedCommand = new RelayCommand<string>(Command_HyperLinkClicked_Execute);
        }

        private void ParseJsonConfig()
        {
            _ = Task.Run(() =>
            {
                try
                {
                    var json = File.ReadAllText(AppValues.ConfigFile);
                    var a = JsonSerializer.Deserialize<InstallationPackageArray>(json);
                }
                catch (FileNotFoundException e)
                {
                    //return file not found model
                    throw;
                }
                catch (JsonException e)
                {
                    //return json data read model
                    throw;
                }
                catch (Exception e)
                {
                    //return unknow error model
                    throw;
                }
            });
        }

        internal void Initialize()
        {
            InitializeCommands();
            ParseJsonConfig();
        }
    }
}