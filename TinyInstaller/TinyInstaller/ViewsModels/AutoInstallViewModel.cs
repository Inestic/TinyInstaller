using System.Collections.Generic;
using TinyInstaller.Poco;

namespace TinyInstaller.ViewsModels
{
    internal class AutoInstallViewModel : ViewModelBase
    {
        public AutoInstallViewModel(IEnumerable<Package> parameter)
        {
            Packages = parameter;
        }

        public IEnumerable<Package> Packages { get; private set; }
    }
}