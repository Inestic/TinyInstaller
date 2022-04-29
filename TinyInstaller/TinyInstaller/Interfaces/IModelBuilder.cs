using TinyInstaller.Models;

namespace TinyInstaller.Interfaces
{
    internal interface IModelBuilder
    {
        ModelBase Build<TModel, TParameter>(TParameter parameter) where TModel : ModelBase, new();

        ModelBase Build<TModel>() where TModel : ModelBase;
    }
}