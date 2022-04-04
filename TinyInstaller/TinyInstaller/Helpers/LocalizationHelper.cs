using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using TinyInstaller.Interfaces;

namespace TinyInstaller.Helpers
{
    internal class LocalizationHelper : IVoidInvoked
    {
        private const string EN_NAME = "EN";
        private const string RU_NAME = "RU";
        private static Uri EN_URI = new Uri("pack://application:,,,/Localizations/EN.xaml");
        private static Uri RU_URI = new Uri("pack://application:,,,/Localizations/RU.xaml");

        internal Dictionary<string, Uri> Localizations { get; private set; } = new Dictionary<string, Uri>
        {
            {EN_NAME, EN_URI},
            {RU_NAME, RU_URI},
        };

        public void Invoke()
        {
            var isRuCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpper() == RU_NAME;
            var dictionary = new ResourceDictionary() { Source = Localizations[isRuCulture ? RU_NAME : EN_NAME] };
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}