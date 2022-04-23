using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.DAL
{
    public class ConfigProvider
    {
        public IConfigurationRoot Config { get; private set; }
        public ConfigProvider()
        {
            var builder = new ConfigurationBuilder();

            //Locates location of db info
            builder.AddUserSecrets<AppDbContext>();
            Config = builder.Build();
        }
    }
}
