using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TinyInstaller.Common;
using TinyInstaller.Helpers;
using TinyInstaller.Interfaces;
using TinyInstaller.Models;
using TinyInstaller.Poco;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private InstallationStatus installationStatus;
        private uint installedCorrectly = default;
        private uint installedIncorrectly = default;
        private string installingPackage;
        private int installQueue;
        private bool mainWindow_CanClose = true;
        private ViewModelBase model;
        private IEnumerable<Package> packages;
        private ObservableCollection<Package> willInstalled = new();
        public AppConstants AppConstants { get; private set; }
        public string AppName => AppConstants.AppName;
        public string AppVersion => AppConstants.AppVersion;
        public IConfigParser ConfigParser { get; private set; }
        public RelayCommand CreateConfigCommand { get; private set; }
        public RelayCommand<string> HyperLinkClickedCommand { get; private set; }

        public InstallationStatus InstallationStatus
        {
            get => installationStatus;
            set
            {
                installationStatus = value;
                OnPropertyChanged();
            }
        }

        public uint InstalledCorrectly
        {
            get => installedCorrectly;
            set
            {
                installedCorrectly = value;
                OnPropertyChanged();
            }
        }

        public uint InstalledIncorrectly
        {
            get => installedIncorrectly;
            set
            {
                installedIncorrectly = value;
                OnPropertyChanged();
            }
        }

        public string InstallingPackage
        {
            get => installingPackage;
            set
            {
                installingPackage = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand InstallPackagesCommand { get; private set; }

        public int InstallQueue
        {
            get => installQueue;
            set
            {
                installQueue = value;
                OnPropertyChanged();
            }
        }

        public MainWindow MainWindow { get; private set; }

        public bool MainWindow_CanClose
        {
            get => mainWindow_CanClose;
            private set
            {
                mainWindow_CanClose = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public RelayCommand MainWindowCloseCommand { get; private set; }
        public RelayCommand MainWindowMinimizeCommand { get; private set; }
        public RelayCommand MainWindowMinMaxCommand { get; private set; }

        public ViewModelBase Model
        {
            get => model;
            private set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        public IModelsBuilder ModelsBuilder { get; private set; }

        public IEnumerable<Package> Packages
        {
            get => packages;
            private set
            {
                packages = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Package> SwitchClickedCommand { get; private set; }

        public ObservableCollection<Package> WillInstalled
        {
            get => willInstalled;
            private set
            {
                willInstalled = value;
                OnPropertyChanged();
            }
        }
    }
}