using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TinyInstaller.Models;
using TinyInstaller.Poco;

namespace TinyInstaller.Interfaces
{
    internal interface IConfigParser
    {
        Task<ViewModelBase> ParseAsync(IModelsBuilder modelsBuilder, string config, string packagesFolder);
        event EventHandler<IEnumerable<Package>> IsSuccessfulParsed;
        event EventHandler<IEnumerable<Package>> IsAutoInstall;
    }
}