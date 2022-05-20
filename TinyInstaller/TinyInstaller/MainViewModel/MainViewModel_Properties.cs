using System.Collections.Generic;
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
        private ViewModelBase model;
        private IEnumerable<Package> packages;
        private bool mainWindow_CanClose = true;

        public AppConstants AppConstants { get; private set; }
        public IConfigParser ConfigParser { get; private set; }
        public IEnumerable<Package> Packages 
        { 
            get => packages; 
            private set
            {
                packages = value;
                OnPropertyChanged();
            }
        }
        public MainWindow MainWindow { get; private set; }
        public RelayCommand<string> HyperLinkClickedCommand { get; private set; }
        public string AppName => AppConstants.AppName;
        public string AppVersion => AppConstants.AppVersion;
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
    }
}