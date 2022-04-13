﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        private void ConditionsHasError() => ActiveView = ActiveView.ConditionsHasErrors;

        private void InitializeCommands()
        {
            MainWindowCloseCommand = new RelayCommand(Command_MainWindowClose_Execute, Command_MainWindowClose_CanExecute);
            MainWindowMinimizeCommand = new RelayCommand(Command_MainWindowMinimize_Execute);
            MainWindowMinMaxCommand = new RelayCommand(Command_MainWindowMinMaxCommand_Execute);
            HyperLinkClickedCommand = new RelayCommand<string>(Command_HyperLinkClicked_Execute);
        }

        private void InitializeProperties(MainWindow mainWindow, ILocalizationHelper localizationHelper, IEnumerable<IStartupCondition> startupConditions)
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            LocalizationHelper = localizationHelper ?? throw new ArgumentNullException(nameof(localizationHelper));
            StartupConditions = startupConditions ?? throw new ArgumentNullException(nameof(startupConditions));

            LocalizationHelper.Invoke();
        }

        internal async void Invoke()
        {
            await Task.Run(() =>
            {
                InitializeCommands();
                InvokeStartupConditions();
            });
        }

        internal async void InvokeStartupConditions()
        {
            await Task.Run(() =>
            {
                //foreach (var condition in StartupConditions)
                //{
                //    try
                //    {
                //        condition.Invoke();
                //        if (!condition.IsSuccessfully)
                //            ConditionErrors.Add(condition);
                //    }
                //    catch (Exception)
                //    {
                //        ConditionsHasError();
                //        break;
                //    }
                //}

                //if (StartupConditions.All(condition => condition.IsSuccessfully))
                //    ActiveView = ActiveView.ReadyToInstall;
            });
        }
    }
}