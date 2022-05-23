using System;
using System.Collections.Generic;
using TinyInstaller.Models;
using TinyInstaller.Poco;

namespace TinyInstaller.Interfaces
{
    internal interface IConfigParser
    {
        event EventHandler<IEnumerable<Package>> IsAutoInstall;

        event EventHandler<IEnumerable<Package>> IsSuccessfulParsed;

        ViewModelBase Parse(IModelsBuilder modelsBuilder, string config, string packagesFolder);
    }
}