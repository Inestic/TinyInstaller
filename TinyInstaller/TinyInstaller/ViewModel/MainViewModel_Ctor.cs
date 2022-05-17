using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(MainWindow mainWindow, IConstantsValues constantsValues)
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            AppValues = constantsValues ?? throw new ArgumentNullException(nameof(constantsValues));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}