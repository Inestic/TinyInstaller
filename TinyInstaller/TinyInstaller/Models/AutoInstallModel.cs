using System.Collections.Generic;
using TinyInstaller.Poco;

namespace TinyInstaller.Models
{
    internal class AutoInstallModel : ViewModelBase
    {
        public AutoInstallModel(IEnumerable<Package> parameter)
        {
            Packages = parameter;
        }

        public IEnumerable<Package> Packages { get; private set; }
    }
}