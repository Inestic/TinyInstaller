using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;
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
            _ = Task.Run(() =>
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
                        return;
                    }
                }

                Model = StartupConditions.All(c => c.IsSuccessfully) ? ModelBuilder.Build<ReadyToInstallModel>()
                                                                     : ModelBuilder.Build<ConditionTryFixModel, IEnumerable<IStartupCondition>>(StartupConditions.Where(c => !c.IsSuccessfully));
            });
        }

        internal void Initialize()
        {
            InitializeCommands();
            InvokeStartupConditions();
        }
    }
}