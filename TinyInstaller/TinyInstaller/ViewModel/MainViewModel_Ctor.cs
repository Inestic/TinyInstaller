using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(MainWindow mainWindow, IEnumerable<IStartupCondition> startupConditions, IModelBuilder modelBuilder)
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            ModelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));
            StartupConditions = startupConditions ?? throw new ArgumentNullException(nameof(startupConditions));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}