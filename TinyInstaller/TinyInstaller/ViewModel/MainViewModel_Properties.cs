using System.Reflection;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private ILocalized Localizator { get; set; }
        public string AppName { get => Assembly.GetExecutingAssembly().GetName().Name; }
        public string AppVersion { get => Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        public MainWindow MainWindow { get; private set; }
    }
}