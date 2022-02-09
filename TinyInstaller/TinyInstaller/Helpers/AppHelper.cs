using System.Reflection;

namespace TinyInstaller.Helpers
{
    internal class AppHelper
    {
        public static string Name { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public static string VersionString { get; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}