using System;
using System.ComponentModel;
using TinyInstaller.Helpers;

namespace TinyInstaller.ViewModel
{
    internal partial class VM : INotifyPropertyChanged
    {
        public VM(MainWindow mainWindow, LocalizationHelper localizationHelper, StartupTestsHelper startupTestsHelper) : base()
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            LocalizationHelper = localizationHelper ?? throw new ArgumentNullException(nameof(localizationHelper));
            StartupTestsHelper = startupTestsHelper ?? throw new ArgumentNullException(nameof(startupTestsHelper));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
    }
}