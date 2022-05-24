namespace TinyInstaller.Poco
{
    internal class Package
    {
        public bool AutoInstall { get; set; }
        public string Description { get; set; }
        public string ExecutableArgs { get; set; }
        public string ExecutableFile { get; set; }
        public int ExitCode { get; set; }
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
    }
}