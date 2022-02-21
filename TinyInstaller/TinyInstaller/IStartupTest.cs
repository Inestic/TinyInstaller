using TinyInstaller.Common;

namespace TinyInstaller
{
    internal interface IStartupTest
    {
        internal Page PageTag { get; set; }

        void Run();
    }
}