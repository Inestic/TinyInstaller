using System;
using TinyInstaller.Interfaces;
using TinyInstaller.Models;

namespace TinyInstaller.Helpers
{
    internal class ModelBuilder : IModelBuilder
    {
        public ModelBase Build<TModel, TParameter>(TParameter parameter) where TModel : ModelBase, new()
        {
            if (typeof(TModel) == typeof(ConditionHasErrorsModel))
            {
                var model = new ConditionHasErrorsModel();
                model.Initialize(parameter);
                return model;
            }
            else if (typeof(TModel) == typeof(ConditionTryFixModel))
            {
                var model = new ConditionTryFixModel();
                model.Initialize(parameter);
                return model;
            }
            else
            {
                throw new Exception($"{typeof(TModel).Name} is unknow model type.");
            }
        }

        public ModelBase Build<TModel>() where TModel : ModelBase
        {
            if (typeof(TModel) == typeof(ReadyToInstallModel))
            {
                var model = new ReadyToInstallModel();
                model.Initialize();
                return model;
            }
            else if (typeof(TModel) == typeof(ConditionTryFixModel))
            {
                var model = new ConditionTryFixModel();
                model.Initialize();
                return model;
            }
            else
            {
                throw new Exception("Unknow model type.");
            }
        }
    }
}