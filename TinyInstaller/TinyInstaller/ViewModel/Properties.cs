using System.Windows.Input;
using TinyInstaller.Common;
using TinyInstaller.Helpers;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private Page activePage = Page.LoadingView;
        private string ActivePagePropertyName = "ActivePage";
        private bool window_CanClose = true;

        public Page ActivePage
        {
            get => activePage;
            private set
            {
                activePage = value;
                OnPropertyChanged(ActivePagePropertyName);
            }
        }

        public string AppName { get => AppHelper.Name; }
        public string AppVersion { get => AppHelper.VersionString; }
        public IInvoker LocalizationHelper { get; private set; }
        public MainWindow MainWindow { get; private set; }
        public IGenericInvoker<Page> StartupTestsHelper { get; private set; }

        public bool Window_CanClose
        {
            get => window_CanClose;
            private set
            {
                window_CanClose = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}