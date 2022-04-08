using System;
using System.ComponentModel;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class VM : INotifyPropertyChanged
    {
        internal VM(MainWindow mainWindow, ILocalizationHelper localizationHelper, IStartupConditionsHelper conditionHelper) : base()
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            LocalizationHelper = localizationHelper ?? throw new ArgumentNullException(nameof(localizationHelper));
            StartupConditionsHelper = conditionHelper ?? throw new ArgumentNullException(nameof(conditionHelper));

            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);

            Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
    }
}