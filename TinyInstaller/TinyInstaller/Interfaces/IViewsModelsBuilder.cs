using TinyInstaller.Models;

namespace TinyInstaller.Interfaces
{
    internal interface IModelsBuilder
    {
        ViewModelBase Build<TViewModel, TParameter>(TParameter parameter) where TViewModel : ViewModelBase;

        ViewModelBase Build<TViewModel>() where TViewModel : ViewModelBase;
    }
}