using System.Collections.Generic;
using TinyInstaller.Interfaces;

namespace TinyInstaller.Models
{
    internal class ConditionTryFixModel : ModelBase
    {
        public IEnumerable<IStartupCondition> ConditionsToFix { get; private set; }

        public new void Initialize<TParameter>(TParameter parameter)
        {
            ConditionsToFix = parameter as IEnumerable<IStartupCondition>;
        }
    }
}