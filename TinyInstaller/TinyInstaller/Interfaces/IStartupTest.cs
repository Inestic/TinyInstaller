using TinyInstaller.Common;

namespace TinyInstaller.Interfaces
{
    internal interface IStartupTest
    {
        Page PageTag { get; set; }

        void Run();
    }
}