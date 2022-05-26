using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TinyInstaller.Poco
{
    internal class Package : INotifyPropertyChanged
    {
        private bool isChecked;

        public bool AutoInstall { get; set; }
        public bool IsChecked 
        { 
            get => isChecked; 
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }
        public int ExitCode { get; set; }
        public string Description { get; set; }
        public string ExecutableArgs { get; set; }
        public string ExecutableFile { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public uint Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}