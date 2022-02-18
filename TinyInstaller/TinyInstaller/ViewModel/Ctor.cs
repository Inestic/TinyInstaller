namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        public VM(MainWindow mainWindow) : base()
        {
            InitializeProperties(mainWindow);
            InitializeCommands();
            InitializeDataAsync();
        }
    }
}