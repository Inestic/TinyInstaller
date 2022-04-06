using System.Reflection;

namespace TinyInstaller.Common
{
    internal class AppHelper
    {
        internal static AssemblyName AssemblyName = Assembly.GetExecutingAssembly().GetName();
    }
}