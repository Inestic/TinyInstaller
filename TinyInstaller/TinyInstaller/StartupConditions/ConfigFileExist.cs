﻿using System;
using System.IO;
using System.Windows;
using TinyInstaller.Interfaces;

namespace TinyInstaller.StartupConditions
{
    internal class ConfigFileExist : IStartupCondition
    {
        private string appDir;
        private string configFile;

        public ConfigFileExist(string AppDir, string ConfigFile)
        {
            appDir = AppDir ?? throw new ArgumentNullException(nameof(AppDir));
            configFile = ConfigFile ?? throw new ArgumentNullException(nameof(ConfigFile));
        }

        public string Description { get => (string)Application.Current.Resources["Localization.StartupCondition.ConfigFileExist.Description"]; }
        public bool IsSuccessfully { get; set; } = default;
        public string Name { get => (string)Application.Current.Resources["Localization.StartupCondition.ConfigFileExist.Name"]; }

        public bool Invoke() => File.Exists(Path.Combine(appDir, configFile));

        public void TryFix()
        {
            if (!File.Exists(Path.Combine(appDir, configFile)))
                File.Create(Path.Combine(appDir, configFile));
        }
    }
}