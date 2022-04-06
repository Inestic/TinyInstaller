using System.Windows.Input;
using TinyInstaller.Common;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private bool mainWindow_CanClose = true;

        public string AppName { get => AppHelper.AssemblyName.Name; }

        public string AppVersionString { get => AppHelper.AssemblyName.Version.ToString(); }

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