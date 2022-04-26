using TinyInstaller.Interfaces;

namespace TinyInstaller.Models
{
    internal class ConditionHasErrorsModel : IModel
    {
        private string errorDescription;

        public string ErrorDescription
        {
            get { return errorDescription; }
            set { errorDescription = value; }
        }

        public void Initialize<TParameter>(TParameter parameter) => ErrorDescription = parameter as string;
    }
}