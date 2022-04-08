using System.Collections.Generic;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;

namespace TinyInstaller.Helpers
{
    internal class StartupConditionsHelper : IStartupConditionsHelper
    {
        public IEnumerable<IStartupCondition> Conditions => new List<IStartupCondition>();

        public IEnumerable<IStartupCondition> HasErrors => new List<IStartupCondition>();

        public Views Invoke()
        {
            return Views.StartupConditions;
        }
    }
}