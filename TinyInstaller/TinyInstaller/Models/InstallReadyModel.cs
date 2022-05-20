using System.Collections.Generic;
using TinyInstaller.Poco;

namespace TinyInstaller.Models
{
    internal class InstallReadyModel : ViewModelBase
    {
        public InstallReadyModel(IEnumerable<Package> parameter)
        {
            Packages = parameter;
        }

        public IEnumerable<Package> Packages { get; private set; }
    }
}