using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PersistUnitTest
{
    /// <summary>
    /// Base builder of application configuration
    /// </summary>
    public class ConfigurationBuilder
    {
        public IConfiguration Configuration { get; private set; }

        public ConfigurationBuilder(string envName, bool correctCurrentDir = true)
        {
            if (correctCurrentDir) 
            {
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            }
            Configuration = BuildConfiguration(envName);
        }

        /// <summary>
        /// Read configuration files and build application configuration
        /// </summary>
        /// <param name="envName"></param>
        /// <returns></returns>
        protected virtual IConfiguration BuildConfiguration(string envName)
        {
            IConfigurationBuilder builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            if (!String.IsNullOrEmpty(envName))
            {
                string cfgName = $"appsettings.{envName}.json";
                builder.AddJsonFile(cfgName, optional: true, reloadOnChange: true);
            }

            return builder.Build();
        }

    }
}
