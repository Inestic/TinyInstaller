using System.Diagnostics;

namespace TinyInstaller.Helpers
{
    internal class ProcessHelper
    {
        internal static Process Start(string processName, string processArgs = null, ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal)
        {
            return Process.Start(new ProcessStartInfo()
            {
                FileName = processName,
                Arguments = processArgs,
                WindowStyle = windowStyle,
            });
        }
    }
}