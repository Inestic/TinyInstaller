using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
