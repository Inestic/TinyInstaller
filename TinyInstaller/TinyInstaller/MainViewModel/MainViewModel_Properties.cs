using System.Windows.Input;
using TinyInstaller.Common;
using TinyInstaller.Helpers;
using TinyInstaller.Interfaces;
using TinyInstaller.ViewsModels;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private bool mainWindow_CanClose = true;
        private ViewModelBase viewModel;

        public AppConstants AppConstants { get; private set; }
        public string AppName => AppConstants.AppName;
        public string AppVersion => AppConstants.AppVersion;
        public IConfigParser ConfigParser { get; private set; }
        public RelayCommand<string> HyperLinkClickedCommand { get; private set; }
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

        public ViewModelBase ViewModel
        {
            get => viewModel;
            private set
            {
                viewModel = value;
                OnPropertyChanged();
            }
        }

        public IViewsModelsBuilder ViewsModelsBuilder { get; private set; }
    }
}