using System;
using System.IO;
using System.Text;
using System.Windows;
using TinyInstaller.Helpers;
using TinyInstaller.Models;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private void Command_CreateConfig_Execute(object arg)
        {
            var configFile = $@"{AppConstants.BaseDirectory}{AppConstants.ConfigFile}";
            var packagesFolder = $@"{AppConstants.BaseDirectory}{AppConstants.PackagesFolder}";

            try
            {
                if (!File.Exists(configFile))
                    File.WriteAllText(configFile, AppConstants.ConfigExample, Encoding.UTF8);

                if (!Directory.Exists(packagesFolder))
                    Directory.CreateDirectory(packagesFolder);

                SetModelFromConfig();
            }
            catch (Exception e)
            {
                Model = ModelsBuilder.Build<UnknowErrorModel, string>(e.Message);
            }
        }

        private void Command_HyperLinkClicked_Execute(string link) => ProcessHelper.Run("explorer", link);

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