using System.Collections.Generic;
using TinyInstaller.Common;

namespace TinyInstaller.Interfaces
{
    internal interface IStartupConditionsHelper
    {
        IEnumerable<IStartupCondition> Conditions { get; }

        IEnumerable<IStartupCondition> HasErrors { get; }

        Views Invoke();
    }
}