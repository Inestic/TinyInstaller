namespace TinyInstaller.Models
{
    internal class UnknowErrorModel : ViewModelBase
    {
        public UnknowErrorModel(string parameter)
        {
            ErrorMessage = parameter;
        }

        public string ErrorMessage { get; private set; }
    }
}