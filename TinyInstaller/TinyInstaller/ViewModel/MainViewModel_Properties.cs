using System.Windows.Input;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;
using TinyInstaller.Models;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private bool mainWindow_CanClose = true;
        private ModelBase model;

        public string AppName => AppValues.AppName;
        public IConstantsValues AppValues { get; private set; }
        public string AppVersion => AppValues.AppVersion;
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

        public ModelBase Model
        {
            get => model;
            private set
            {
                model = value;
                OnPropertyChanged();
            }
        }
    }
}