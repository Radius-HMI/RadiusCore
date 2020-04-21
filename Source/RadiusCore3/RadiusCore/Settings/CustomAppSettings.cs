using Microsoft.Extensions.Configuration;
using System.IO;

namespace RadiusCore.Settings
{
    public class CustomAppSettings
    {
        public static IConfiguration Settings { get; }
        static CustomAppSettings()
        {
            Settings = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory() + "/Settings/")
                    .AddJsonFile("CustomAppSettings.json")
                    .Build();
        }
    }
}
