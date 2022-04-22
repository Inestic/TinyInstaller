using System.ComponentModel;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
        }

        public MainViewModel(MainWindow mainWindow, ILocalized localizator) : this()
        {
            Localizator = localizator;
            MainWindow = mainWindow;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
    }
}