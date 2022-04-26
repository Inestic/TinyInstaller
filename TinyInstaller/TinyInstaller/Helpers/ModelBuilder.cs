using System;
using TinyInstaller.Interfaces;
using TinyInstaller.Models;

namespace TinyInstaller.Helpers
{
    internal class ModelBuilder : IModelBuilder
    {
        public IModel Build<TModel, TParameter>(TParameter parameter)
        {
            if (typeof(TModel) == typeof(ConditionHasErrorsModel))
            {
                var model = new ConditionHasErrorsModel();
                model.Initialize(parameter as string);
                return model;
            }
            else
            {
                throw new Exception("Unknow model type.");
            }
        }
    }
}