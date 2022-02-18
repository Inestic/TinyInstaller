using System.Windows.Input;
using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private bool window_CanClose;
        public string AppName { get => AppHelper.Name; }
        public string AppVersion { get => AppHelper.VersionString; }
        public MainWindow MainWindow { get; private set; }

        public bool Window_CanClose
        {
            get => window_CanClose;
            set
            {
                window_CanClose = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}