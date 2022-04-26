using System;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Models;

namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        private void InitializeCommands()
        {
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
            HyperLinkClickedCommand = new RelayCommand<string>(Command_HyperLinkClicked_Execute);
        }

        private void InvokeStartupConditions()
        {
            Task.Run(() =>
            {
                foreach (var condition in StartupConditions)
                {
                    try
                    {
                        condition.Invoke();
                    }
                    catch (Exception e)
                    {
                        Model = ModelBuilder.Build<ConditionHasErrorsModel, string>(e.Message);
                    }
                }
            });
        }

        internal void Initialize()
        {
            InitializeCommands();
            InvokeStartupConditions();
        }
    }
}