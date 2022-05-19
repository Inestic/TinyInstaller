using System.Threading.Tasks;
using TinyInstaller.ViewsModels;

namespace TinyInstaller.Interfaces
{
    internal interface IConfigParser
    {
        Task<ViewModelBase> ParseAsync(IViewsModelsBuilder modelsBuilder, string config, string packagesFolder);
    }
}