using TinyInstaller.ViewsModels;

namespace TinyInstaller.Interfaces
{
    internal interface IViewsModelsBuilder
    {
        ViewModelBase Build<TViewModel, TParameter>(TParameter parameter) where TViewModel : ViewModelBase;

        ViewModelBase Build<TViewModel>() where TViewModel : ViewModelBase;
    }
}