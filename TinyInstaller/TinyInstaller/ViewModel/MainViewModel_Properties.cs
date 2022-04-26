using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private bool mainWindow_CanClose = true;
        private IModel model;

        public string AppName { get => Assembly.GetExecutingAssembly().GetName().Name; }
        public string AppVersion { get => Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
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

        public IModel Model
        {
            get => model;
            private set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        public IModelBuilder ModelBuilder { get; private set; }
        public IEnumerable<IStartupCondition> StartupConditions { get; private set; }
    }
}