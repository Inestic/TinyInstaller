using System;
using System.Collections.Generic;
using TinyInstaller.Interfaces;
using TinyInstaller.Poco;
using TinyInstaller.ViewsModels;

namespace TinyInstaller.Helpers
{
    internal class ViewsModelsBuilder : IViewsModelsBuilder
    {
        public ViewModelBase Build<TViewModel>() where TViewModel : ViewModelBase
        {
            if (typeof(TViewModel) == typeof(ConfigNotFoundViewModel))
                return new ConfigNotFoundViewModel();
            else if (typeof(TViewModel) == typeof(ConfigNotValidViewModel))
                return new ConfigNotValidViewModel();
            else
                throw new Exception($"{typeof(TViewModel).Name} is unknow model type.");
        }

        public ViewModelBase Build<TViewModel, TParameter>(TParameter parameter) where TViewModel : ViewModelBase
        {
            if (typeof(TViewModel) == typeof(UnknowErrorViewModel))
                return new UnknowErrorViewModel(parameter as string);

            if (typeof(TViewModel) == typeof(InstallReadyViewModel))
                return new InstallReadyViewModel(parameter as IEnumerable<Package>);

            if (typeof(TViewModel) == typeof(AutoInstallViewModel))
                return new AutoInstallViewModel(parameter as IEnumerable<Package>);
            else
                throw new Exception($"{typeof(TViewModel).Name} is unknow model type.");
        }
    }
}