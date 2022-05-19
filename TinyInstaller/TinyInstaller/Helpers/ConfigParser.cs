using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;
using TinyInstaller.Poco;
using TinyInstaller.ViewsModels;

namespace TinyInstaller.Helpers
{
    internal class ConfigParser : IConfigParser
    {
        private bool IsAutoInstallMode(IEnumerable<Package> packages)
        {
            return packages.Any(package => package.AutoInstall);
        }

        private bool PackagesIsValid(IEnumerable<Package> packages, string rootFolder)
        {
            return packages.All(package => package.Title != string.Empty
                                            && package.Version != string.Empty
                                            && File.Exists(Path.Combine(rootFolder, package.ExecutableFile)));
        }

        public async Task<ViewModelBase> ParseAsync(IViewsModelsBuilder modelsBuilder, string config, string packagesFolder) =>
                            await Task.Run(() =>
            {
                try
                {
                    var configContent = File.Exists(config) ? File.ReadAllText(config) : throw new FileNotFoundException();
                    var packages = JsonSerializer.Deserialize<PackageCollection>(configContent).Packages ?? throw new ConfigNotValidExceptions();

                    if (!PackagesIsValid(packages, packagesFolder))
                        throw new ConfigNotValidExceptions();

                    return IsAutoInstallMode(packages)
                            ? modelsBuilder.Build<AutoInstallViewModel, IEnumerable<Package>>(packages.Where(package => package.AutoInstall))
                            : modelsBuilder.Build<InstallReadyViewModel, IEnumerable<Package>>(packages);
                }
                catch (FileNotFoundException)
                {
                    return modelsBuilder.Build<ConfigNotFoundViewModel>();
                }
                catch (ConfigNotValidExceptions)
                {
                    return modelsBuilder.Build<ConfigNotValidViewModel>();
                }
                catch (Exception e)
                {
                    return modelsBuilder.Build<UnknowErrorViewModel, string>(e.Message);
                }
            });
    }
}