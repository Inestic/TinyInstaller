using System.Collections.Generic;
using TinyInstaller.Poco;

namespace TinyInstaller.ViewsModels
{
    internal class InstallReadyViewModel : ViewModelBase
    {
        public InstallReadyViewModel(IEnumerable<Package> parameter)
        {
            Packages = parameter;
        }

        public IEnumerable<Package> Packages { get; private set; }
    }
}