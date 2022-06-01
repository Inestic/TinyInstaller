using System;
using TinyInstaller.Interfaces;
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
            else if (typeof(TViewModel) == typeof(InstallReadyModel))
                return new InstallReadyModel();
            else if (typeof(TViewModel) == typeof(AutoInstallModel))
                return new AutoInstallModel();
            else
                throw new Exception($"{typeof(TViewModel).Name} is unknow model type.");
        }

        public ViewModelBase Build<TViewModel, TParameter>(TParameter parameter) where TViewModel : ViewModelBase
        {
            if (typeof(TViewModel) == typeof(UnknowErrorModel))
                return new UnknowErrorModel(parameter as string);
            else
                throw new Exception($"{typeof(TViewModel).Name} is unknow model type.");
        }
    }
}