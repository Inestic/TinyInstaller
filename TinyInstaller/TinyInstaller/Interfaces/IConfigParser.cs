using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyInstaller.Models;
using TinyInstaller.Poco;

namespace TinyInstaller.Interfaces
{
    internal interface IConfigParser
    {
        event EventHandler<IEnumerable<Package>> IsAutoInstall;

        event EventHandler<IEnumerable<Package>> IsSuccessfulParsed;

        Task<ViewModelBase> ParseAsync(IModelsBuilder modelsBuilder, string config, string packagesFolder);
    }
}