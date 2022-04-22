using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using TinyInstaller.Interfaces;

namespace TinyInstaller.Helpers
{
    internal class Localizator : ILocalized
    {
        private const string EN_NAME = "EN";
        private const string RU_NAME = "RU";
        private static Uri EN_URI = new Uri("pack://application:,,,/Localizations/EN.xaml");
        private static Uri RU_URI = new Uri("pack://application:,,,/Localizations/RU.xaml");
        private Dictionary<string, Uri> Localizations = new() { { EN_NAME, EN_URI }, { RU_NAME, RU_URI }, };

        public void Invoke()
        {
            var HasRuCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpper() == RU_NAME;
            var localization = new ResourceDictionary() { Source = Localizations[HasRuCulture ? RU_NAME : EN_NAME] };
            Application.Current.Resources.MergedDictionaries.Add(localization);
        }
    }
}