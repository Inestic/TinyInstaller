using System.ComponentModel;

namespace TinyInstaller.ViewModel
{
    internal partial class VM : INotifyPropertyChanged
    {
        public VM(MainWindow mainWindow) : base()
        {
            InitializeProperties(mainWindow);
            InitializeCommands();
            StartupTestsInvokeAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
    }
}