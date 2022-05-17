namespace TinyInstaller.Interfaces
{
    internal interface IConstantsValues
    {
        public string AppName { get; }
        public string AppVersion { get; }
        public string BaseDirectory { get; }
        public string ConfigFile { get; }
    }
}