using TinyInstaller.Common;

namespace TinyInstaller.ViewModel
{
    internal partial class VM
    {
        public RelayCommand<string> HyperlinkClickedCommand { get; private set; }
        public RelayCommand WindowCloseCommand { get; private set; }
        public RelayCommand WindowMinimizeCommand { get; private set; }
    }
}