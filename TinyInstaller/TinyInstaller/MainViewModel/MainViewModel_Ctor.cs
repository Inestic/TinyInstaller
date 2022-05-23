using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TinyInstaller.Helpers;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel : INotifyPropertyChanged, IViewModel
    {
        public MainViewModel(MainWindow mainWindow, AppConstants appConstants, IModelsBuilder modelsBuilder, IConfigParser configParser)
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            AppConstants = appConstants ?? throw new ArgumentNullException(nameof(appConstants));
            ModelsBuilder = modelsBuilder ?? throw new ArgumentNullException(nameof(modelsBuilder));
            ConfigParser = configParser ?? throw new ArgumentNullException(nameof(configParser));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}