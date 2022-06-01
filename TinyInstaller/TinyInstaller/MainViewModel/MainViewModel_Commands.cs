using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TinyInstaller.Common;
using TinyInstaller.Helpers;
using TinyInstaller.Models;
using TinyInstaller.Poco;

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

        private async void Command_HyperLinkClicked_Execute(string link) => await Task.Run(() => Process.Start("explorer", link));

        private async void Command_InstallPackages_Execute(object arg)
        {
            MainWindow_CanClose = false;
            InstallationStatus = InstallationStatus.Executed;
            await InstallPackageAsync();
            WillInstalled.Clear();
            InstallationStatus = InstallationStatus.Completed;
            MainWindow_CanClose = true;
        }

        private bool Command_MainWindowClose_CanExecute(object arg) => MainWindow_CanClose;

        private void Command_MainWindowClose_Execute(object arg) => MainWindow.Close();

        private void Command_MainWindowMinimize_Execute(object arg) => MainWindow.WindowState = WindowState.Minimized;

        private void Command_MainWindowMinMaxCommand_Execute(object arg)
        {
            var state = MainWindow.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            MainWindow.WindowState = state;
        }

        private void Command_SwitchClickedCommand_Execute(Package package)
        {
            InstallationStatus = InstallationStatus.Idle;

            if (package.IsChecked ^= true)
            {
                WillInstalled.Add(package);
                return;
            }

            _ = WillInstalled.Remove(package);
        }
    }
}