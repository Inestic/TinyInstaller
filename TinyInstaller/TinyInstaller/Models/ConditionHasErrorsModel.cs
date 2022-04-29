namespace TinyInstaller.Models
{
    internal class ConditionHasErrorsModel : ModelBase
    {
        private string errorDescription;

        public string ErrorDescription
        {
            get => errorDescription;
            private set => errorDescription = value;
        }

        public new void Initialize<TParameter>(TParameter parameter) => ErrorDescription = parameter as string;
    }
}