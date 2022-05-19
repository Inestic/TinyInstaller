using System.Collections.Generic;

namespace TinyInstaller.Poco
{
    internal class PackageCollection
    {
        public IEnumerable<Package> Packages { get; set; }
    }
}