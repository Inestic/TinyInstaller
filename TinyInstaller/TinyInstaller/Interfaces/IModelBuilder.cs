namespace TinyInstaller.Interfaces
{
    internal interface IModelBuilder
    {
        IModel Build<TModel, TParameter>(TParameter parameter);
    }
}