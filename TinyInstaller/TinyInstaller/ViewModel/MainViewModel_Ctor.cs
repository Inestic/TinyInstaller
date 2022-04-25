using System;
using System.Collections.Generic;
using System.ComponentModel;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(MainWindow mainWindow, IEnumerable<IStartupCondition> startupConditions)
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            StartupConditions = startupConditions ?? throw new ArgumentNullException(nameof(startupConditions));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
    }
}