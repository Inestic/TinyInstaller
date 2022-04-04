using System.ComponentModel;
using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class VM : INotifyPropertyChanged
    {
        public VM(MainWindow mainWindow, LocalizationHelper localizationHelper, StartupTestsHelper testsHelper) : base()
        {
            InitializeProperties(mainWindow, localizationHelper, testsHelper);
            InitializeCommands();
            _ = PropertiesInvokeAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
    }
}