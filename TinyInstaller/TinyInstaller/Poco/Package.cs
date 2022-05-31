using System.ComponentModel;
using System.Runtime.CompilerServices;
using TinyInstaller.Common;

namespace TinyInstaller.Poco
{
    internal class Package : INotifyPropertyChanged
    {
        private bool isChecked;
        private PackageStatus status = PackageStatus.NotInstalled;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool AutoInstall { get; set; }
        public string Description { get; set; }
        public string ExecutableArgs { get; set; }
        public string ExecutableFile { get; set; }
        public int ExitCode { get; set; }
        public uint Id { get; set; }

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }

        public PackageStatus Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public string Title { get; set; }
        public string Version { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}