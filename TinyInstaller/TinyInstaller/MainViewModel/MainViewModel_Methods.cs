using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Poco;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private void ConfigIsAutoInstallMode(object sender, IEnumerable<Package> packages)
        {
            MainWindow_CanClose = false;
            Packages = packages.Where(package => package.AutoInstall);
        }

        private void ConfigSuccessfulParsed(object sender, IEnumerable<Package> packages)
        {
            Packages = packages;
        }

        private void InitializeCommands()
        {
            CreateConfigCommand = new RelayCommand(Command_CreateConfig_Execute);
            HyperLinkClickedCommand = new RelayCommand<string>(Command_HyperLinkClicked_Execute);
            InstallPackagesCommand = new RelayCommand(Command_InstallPackages_Execute);
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
            SwitchClickedCommand = new RelayCommand<Package>(Command_SwitchClickedCommand_Execute);
        }

        private void InitializeEvents()
        {
            ConfigParser.IsSuccessfulParsed += ConfigSuccessfulParsed;
            ConfigParser.IsAutoInstall += ConfigIsAutoInstallMode;
        }

        private async Task InstallPackageAsync()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < WillInstalled.Count; i++)
                {
                    var package = WillInstalled[i];
                    InstallingPackage = $"{package.Title} {package.Version}";
                    InstallQueue = WillInstalled.Count - (i + 1);

                    try
                    {
                        var file = $@"{AppConstants.BaseDirectory}{AppConstants.PackagesFolder}\{package.ExecutableFile}";
                        var startInfo = new ProcessStartInfo(fileName: file, arguments: package.ExecutableArgs) { UseShellExecute=true };
                        var process = Process.Start(startInfo);
                        process.WaitForExit();

                        if (process.ExitCode == package.ExitCode)
                        {
                            package.Status = PackageStatus.Success;
                            InstalledCorrectly++;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        package.Status = PackageStatus.HasError;
                        InstalledIncorrectly++;
                    }
                    finally
                    {
                        Task.Delay(1000).Wait();
                    }
                }
            });
        }

        private void SetModelFromConfig()
        {
            Model = ConfigParser.Parse(ModelsBuilder, AppConstants.ConfigFile, AppConstants.PackagesFolder);
        }

        public void Initialize()
        {
            InitializeCommands();
            InitializeEvents();
            SetModelFromConfig();
        }
    }
}