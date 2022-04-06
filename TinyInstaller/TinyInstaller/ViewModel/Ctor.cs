using System;
using System.ComponentModel;

namespace TinyInstaller.ViewModel
{
    internal partial class VM : INotifyPropertyChanged
    {
        public VM(MainWindow mainWindow) : base()
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            InitializeCommands();
            InitializeProperties();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
    }
}