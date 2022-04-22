namespace TinyInstaller.ViewModel
{
    internal partial class MainViewModel
    {
        internal MainViewModel Initialize()
        {
            Localizator.Invoke();
            return this;
        }
    }
}