using TinyInstaller.Common;

namespace TinyInstaller.Interfaces
{
    internal interface IStartupTest
    {
        internal Page PageTag { get; set; }

        void Run();
    }
}