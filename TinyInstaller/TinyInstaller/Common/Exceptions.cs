using System;

namespace TinyInstaller.Common
{
    internal class StartupTestException : Exception
    {
        public StartupTestException(Page pageTag) : base()
        {
            PageTag = pageTag;
        }

        public Page PageTag { get; set; }
    }
}