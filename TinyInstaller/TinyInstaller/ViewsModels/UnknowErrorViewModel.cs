namespace TinyInstaller.ViewsModels
{
    internal class UnknowErrorViewModel : ViewModelBase
    {
        public UnknowErrorViewModel(string parameter)
        {
            ErrorMessage = parameter;
        }

        public string ErrorMessage { get; private set; }
    }
}