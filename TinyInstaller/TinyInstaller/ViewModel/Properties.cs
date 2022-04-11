using System.Collections.Generic;
using System.Windows.Input;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private Views activeView = Views.StartupConditions;
        private bool mainWindow_CanClose = true;

        private IEnumerable<IStartupCondition> StartupConditions { get; set; }

        public Views ActiveView
        {
            get
            {
                return activeView;
            }
            private set
            {
                activeView = value;
                OnPropertyChanged(ACTIVE_VIEW_PROPERTY_NAME);
            }
        }

        public string AppName { get => AppHelper.AssemblyName.Name; }

        public string AppVersionString { get => AppHelper.AssemblyName.Version.ToString(); }

        public List<IStartupCondition> ConditionErrors { get; private set; }

        public ILocalizationHelper LocalizationHelper { get; private set; }

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
    }
}