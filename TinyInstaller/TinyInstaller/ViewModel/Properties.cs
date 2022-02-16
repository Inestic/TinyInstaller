using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        public string AppName { get => AppHelper.Name; }
        public string AppVersion { get => AppHelper.VersionString; }
        public MainWindow MainWindow { get; private set; }

        public bool Window_CanClose { get; private set; }
    }
}