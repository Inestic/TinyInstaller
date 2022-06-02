using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TinyInstaller.Common;
using TinyInstaller.Interfaces;
using TinyInstaller.Models;
using TinyInstaller.Poco;

namespace TinyInstaller.Helpers
{
    internal class ConfigParser : IConfigParser
    {
        public event EventHandler<IEnumerable<Package>> IsAutoInstall;

        public event EventHandler<IEnumerable<Package>> IsSuccessfulParsed;

        private bool IsAutoInstallMode(IEnumerable<Package> packages)
        {
            return packages.Any(package => package.AutoInstall);
        }

        private void OnAutoInstall(IEnumerable<Package> packages) => IsAutoInstall?.Invoke(this, packages);

        private void OnSuccessfulParsed(IEnumerable<Package> packages) => IsSuccessfulParsed?.Invoke(this, packages);

        private bool PackagesIsValid(IEnumerable<Package> packages, string rootFolder)
        {
            return packages.All(package => package.Title != string.Empty
                                            && package.Version != string.Empty
                                            && File.Exists(Path.Combine(rootFolder, package.ExecutableFile)));
        }

        private void SetPackageId(IEnumerable<Package> packages)
        {
            uint count = 1;

            foreach (var package in packages)
            {
                package.Id = count;
                count++;
            }
        }

        public async Task<ViewModelBase> ParseAsync(IModelsBuilder modelsBuilder, string config, string packagesFolder)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var configContent = File.Exists(config) ? File.ReadAllText(config) : throw new FileNotFoundException();
                    var packages = JsonSerializer.Deserialize<PackageCollection>(configContent).Packages ?? throw new ConfigNotValidExceptions();

                    if (!PackagesIsValid(packages, packagesFolder))
                        throw new ConfigNotValidExceptions();

                    SetPackageId(packages);

                    if (IsAutoInstallMode(packages))
                    {
                        OnAutoInstall(packages.Where(package => package.AutoInstall));
                        return modelsBuilder.Build<AutoInstallModel>();
                    }

                    OnSuccessfulParsed(packages);
                    return modelsBuilder.Build<InstallReadyModel>();
                }
                catch (FileNotFoundException)
                {
                    return modelsBuilder.Build<ConfigNotFoundModel>();
                }
                catch (ConfigNotValidExceptions)
                {
                    return modelsBuilder.Build<ConfigNotValidModel>();
                }
                catch (Exception e)
                {
                    return modelsBuilder.Build<UnknowErrorModel, string>(e.Message);
                }
            });
        }
    }
}