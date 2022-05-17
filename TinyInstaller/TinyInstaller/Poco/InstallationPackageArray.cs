using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TinyInstaller.Poco
{
    public class InstallationPackage : IJsonOnDeserialized
    {
        public string Description { get; set; }
        public string ExecutableArgs { get; set; }
        public string ExecutableFile { get; set; }
        public int ExitCode { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }

        void IJsonOnDeserialized.OnDeserialized()
        {
            var properties = GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                                 .Where(prop => prop.Name != nameof(Description));

            foreach (var property in properties)
            {
                if (property.GetValue(this) == null
                    || (string)property.GetValue(this) == string.Empty)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }

    public class InstallationPackageArray
    {
        public IEnumerable<InstallationPackage> Packages { get; set; }
    }
}