using System.Diagnostics;

namespace TinyInstaller.Helpers
{
    internal class ProcessHelper
    {
        private static ProcessStartInfo GetStartInfo(string process, string arg, ProcessWindowStyle windowStyle)
        {
            return new ProcessStartInfo()
            {
                FileName = process,
                Arguments = arg,
                WindowStyle = windowStyle
            };
        }

        internal static Process Run(string process, string arg = null, ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal)
        {
            var startInfo = GetStartInfo(process, arg, windowStyle);
            return Process.Start(startInfo);
        }
    }
}