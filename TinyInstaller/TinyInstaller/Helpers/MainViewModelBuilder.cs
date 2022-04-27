﻿using System;
using System.Collections.Generic;
using TinyInstaller.Interfaces;
using TinyInstaller.StartupConditions;
using TinyInstaller.ViewModel;

namespace TinyInstaller.Helpers
{
    internal class MainViewModelBuilder
    {
        public MainViewModelBuilder()
        {
        }

        public MainViewModelBuilder(MainWindow mainWindow) : this()
        {
            MainWindow = mainWindow;
        }

        private MainWindow MainWindow { get; set; }
        public IModelBuilder ModelBuilder { get; private set; }
        public IEnumerable<IStartupCondition> StartupConditions { get; private set; }

        internal MainViewModelBuilder AddStartupConditions()
        {
            StartupConditions = new List<IStartupCondition>()
            {
                new ConfigFileExist(AppDir: AppDomain.CurrentDomain.BaseDirectory, ConfigFile: "PackagesConfig.json"),
            };

            return this;
        }

        internal MainViewModel Build()
        {
            var vm = new MainViewModel(MainWindow, StartupConditions, ModelBuilder);
            vm.Initialize();
            return vm;
        }

        internal MainViewModelBuilder SetLocalizations()
        {
            var localizator = new Localizator();
            localizator.SetLocalization();
            return this;
        }

        internal MainViewModelBuilder SetModelBuilder()
        {
            ModelBuilder = new ModelBuilder();
            return this;
        }
    }
}