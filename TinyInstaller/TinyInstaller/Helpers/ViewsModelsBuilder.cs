using System;
using System.Collections.Generic;
using TinyInstaller.Interfaces;
using TinyInstaller.Poco;
using TinyInstaller.Models;

namespace TinyInstaller.Helpers
{
    internal class ViewsModelsBuilder : IModelsBuilder
    {
        public ViewModelBase Build<TViewModel>() where TViewModel : ViewModelBase
        {
            if (typeof(TViewModel) == typeof(ConfigNotFoundModel))
                return new ConfigNotFoundModel();
            else if (typeof(TViewModel) == typeof(ConfigNotValidModel))
                return new ConfigNotValidModel();
            else
                throw new Exception($"{typeof(TViewModel).Name} is unknow model type.");
        }

        public ViewModelBase Build<TViewModel, TParameter>(TParameter parameter) where TViewModel : ViewModelBase
        {
            if (typeof(TViewModel) == typeof(UnknowErrorModel))
                return new UnknowErrorModel(parameter as string);

            if (typeof(TViewModel) == typeof(InstallReadyModel))
                return new InstallReadyModel(parameter as IEnumerable<Package>);

            if (typeof(TViewModel) == typeof(AutoInstallModel))
                return new AutoInstallModel(parameter as IEnumerable<Package>);
            else
                throw new Exception($"{typeof(TViewModel).Name} is unknow model type.");
        }
    }
}